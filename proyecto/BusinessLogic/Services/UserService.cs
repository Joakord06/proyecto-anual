using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DataAccess.Entities;
using DataAccess.Repositories;
using LayeredApp.Business.Interfaces;

namespace LayeredApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repo = new UserRepository();
        private readonly ConfigRepository _cfgRepo = new ConfigRepository();
        private readonly EmailService _email = new EmailService();

        // ---------------- utilities ----------------
        private static string HashUserPassword(string username, string password)
        {
            string combined = username + password;
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(combined));
            var sb = new StringBuilder();
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        private static string HashAnswer(string answer)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(answer.Trim().ToLower()));
            var sb = new StringBuilder();
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        private static string GenerateRandomPassword(int length = 10)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789!@#$%^&*";
            using var rng = RandomNumberGenerator.Create();
            var buf = new byte[4];
            var res = new char[length];
            for (int i = 0; i < length; i++)
            {
                rng.GetBytes(buf);
                uint r = BitConverter.ToUInt32(buf, 0);
                res[i] = chars[(int)(r % (uint)chars.Length)];
            }
            return new string(res);
        }

        // -------------- policies ----------------
        private bool ValidatePasswordPolicy(string username, string candidate, SystemConfig cfg, IEnumerable<string>? personalParts, out string reason)
        {
            reason = "";
            if (candidate.Length < cfg.MinPasswordLength) { reason = $"Mínimo {cfg.MinPasswordLength} caracteres."; return false; }
            if (cfg.RequireUpperLower && !(candidate.Any(char.IsUpper) && candidate.Any(char.IsLower))) { reason = "Debe contener mayúsculas y minúsculas."; return false; }
            if (cfg.RequireDigits && !candidate.Any(char.IsDigit)) { reason = "Debe contener números."; return false; }
            if (cfg.RequireSpecial && !candidate.Any(c => "!@#$%^&*()_-+=[]{};:,.<>?/|".Contains(c))) { reason = "Debe contener un carácter especial."; return false; }
            if (cfg.DisallowPersonalData && personalParts != null)
            {
                var lower = candidate.ToLower();
                foreach (var p in personalParts) if (!string.IsNullOrWhiteSpace(p) && lower.Contains(p.ToLower())) { reason = "No puede contener datos personales."; return false; }
            }
            return true;
        }

        // ---------- interface methods ------------
        public User? Login(string username, string plainPassword)
        {
            var u = _repo.GetUserByUsername(username);
            if (u == null) return null;
            string h = HashUserPassword(username, plainPassword);
            return h == u.PasswordHash ? u : null;
        }

        public User? GetUserByUsername(string username) => _repo.GetUserByUsername(username);

        public SystemConfig GetSystemConfig() => _cfgRepo.GetConfig();

        public void CreateUserWithQuestions(User user, IEnumerable<(string Question, string AnswerPlain)> questions)
        {
            // generate first password
            string firstPlain = GenerateRandomPassword();
            user.PasswordHash = HashUserPassword(user.Username, firstPlain);
            user.IsFirstLogin = true;
            // hash answers and build list
            var qList = questions.Select(q => (q.Question, AnswerHash: HashAnswer(q.AnswerPlain))).ToList();
            _repo.AddUser(user, qList.Select(x => (x.Question, x.AnswerHash)));
            // send email with initial password if email exists
            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                _email.Send(user.Email, "Tu cuenta - contraseña inicial", $"Usuario: {user.Username}\nContraseña inicial: {firstPlain}");
            }
        }

        public (string password, bool sent) ResetPasswordBySecurity(string username, IDictionary<int, string> answers)
        {
            var user = _repo.GetUserByUsername(username);
            if (user == null) return (string.Empty, false);
            var questions = _repo.GetQuestionsForUser(user.Id);
            // verify answers: answers dict keyed by questionId -> plain answer
            foreach (var q in questions)
            {
                if (!answers.TryGetValue(q.Id, out var provided)) return (string.Empty, false);
                if (HashAnswer(provided) != q.AnswerHash) return (string.Empty, false);
            }
            // generate temp password and set
            string temp = GenerateRandomPassword();
            string hash = HashUserPassword(user.Username, temp);
            _repo.ResetPasswordToHash(user.Id, hash);
            // send email if available
            bool sent = false;
            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                _email.Send(user.Email, "Recuperación de contraseña", $"Tu contraseña temporal: {temp}");
                sent = true;
            }
            return (temp, sent);
        }

        public bool ChangePasswordFirstTime(int userId, string newPlain, out string reason)
        {
            reason = "";
            var user = _repo.GetUserById(userId);
            if (user == null) { reason = "Usuario no encontrado"; return false; }
            var cfg = _cfgRepo.GetConfig();
            if (!ValidatePasswordPolicy(user.Username, newPlain, cfg, new[] { user.Username }, out reason)) return false;
            string newHash = HashUserPassword(user.Username, newPlain);
            if (cfg.DisallowPreviousPasswords)
            {
                var hist = _repo.GetPasswordHistoryHashes(userId);
                if (hist.Contains(newHash)) { reason = "No puede usar una contraseña anterior"; return false; }
            }
            _repo.UpdateUserPasswordHash(userId, newHash);
            return true;
        }

        public bool ChangePassword(int userId, string oldPlain, string newPlain, out string reason)
        {
            reason = "";
            var user = _repo.GetUserById(userId);
            if (user == null) { reason = "Usuario no encontrado"; return false; }
            string oldHash = HashUserPassword(user.Username, oldPlain);
            if (oldHash != user.PasswordHash) { reason = "Contraseña actual incorrecta"; return false; }
            var cfg = _cfgRepo.GetConfig();
            if (!ValidatePasswordPolicy(user.Username, newPlain, cfg, new[] { user.Username }, out reason)) return false;
            string newHash = HashUserPassword(user.Username, newPlain);
            if (cfg.DisallowPreviousPasswords)
            {
                var hist = _repo.GetPasswordHistoryHashes(userId);
                if (hist.Contains(newHash)) { reason = "No puede usar una contraseña anterior"; return false; }
            }
            _repo.InsertPasswordHistory(userId, user.PasswordHash);
            _repo.UpdateUserPasswordHash(userId, newHash);
            return true;
        }
    }
}
