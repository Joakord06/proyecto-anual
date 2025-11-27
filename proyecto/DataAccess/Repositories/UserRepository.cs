using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DataAccess.Entities;
using DataAccess.Helpers;


namespace DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString = ConfigProvider.GetConnectionString("GestionProyecto");

        public User? GetUserById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string q = "SELECT Id, Username, PasswordHash, Email, IsFirstLogin, Role, CreatedAt FROM Users WHERE Id=@id";
            using var cmd = new SqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var r = cmd.ExecuteReader();
            if (r.Read())
                return new User
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Username = r["Username"].ToString()!,
                    PasswordHash = r["PasswordHash"].ToString()!,
                    Email = r["Email"] as string,
                    IsFirstLogin = Convert.ToBoolean(r["IsFirstLogin"]),
                    Role = r["Role"].ToString() ?? "User",
                    CreatedAt = Convert.ToDateTime(r["CreatedAt"])
                };
            return null;
        }

        public User? GetUserByUsername(string username)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string q = "SELECT Id, Username, PasswordHash, Email, IsFirstLogin, Role, CreatedAt FROM Users WHERE Username=@username";
            using var cmd = new SqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@username", username);
            using var r = cmd.ExecuteReader();
            if (r.Read())
                return new User
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Username = r["Username"].ToString()!,
                    PasswordHash = r["PasswordHash"].ToString()!,
                    Email = r["Email"] as string,
                    IsFirstLogin = Convert.ToBoolean(r["IsFirstLogin"]),
                    Role = r["Role"].ToString() ?? "User",
                    CreatedAt = Convert.ToDateTime(r["CreatedAt"])
                };
            return null;
        }

        public IEnumerable<SecurityQuestion> GetSecurityQuestions(int userId)
        {
            var list = new List<SecurityQuestion>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string q = "SELECT Id, UserId, Question, AnswerHash FROM SecurityQuestions WHERE UserId=@userId";
            using var cmd = new SqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new SecurityQuestion
                {
                    Id = Convert.ToInt32(r["Id"]),
                    UserId = Convert.ToInt32(r["UserId"]),
                    Question = r["Question"].ToString()!,
                    AnswerHash = r["AnswerHash"].ToString()!
                });
            }
            return list;
        }

        public void AddUser(User user, IEnumerable<(string Question, string AnswerHash)> questions)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                string q = @"INSERT INTO Users (Username, PasswordHash, Email, IsFirstLogin, Role) 
                             VALUES (@username,@password,@email,@isFirst,@role);
                             SELECT CAST(SCOPE_IDENTITY() as int);";
                using var cmd = new SqlCommand(q, conn, tx);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.PasswordHash);
                cmd.Parameters.AddWithValue("@email", (object?)user.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@isFirst", user.IsFirstLogin);
                cmd.Parameters.AddWithValue("@role", user.Role);
                int userId = (int)cmd.ExecuteScalar()!;
                // insert questions
                foreach (var (Question, AnswerHash) in questions)
                {
                    using var qcmd = new SqlCommand("INSERT INTO SecurityQuestions (UserId, Question, AnswerHash) VALUES (@userId,@q,@a)", conn, tx);
                    qcmd.Parameters.AddWithValue("@userId", userId);
                    qcmd.Parameters.AddWithValue("@q", Question);
                    qcmd.Parameters.AddWithValue("@a", AnswerHash);
                    qcmd.ExecuteNonQuery();
                }
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public void UpdateUserPasswordHash(int userId, string newHash)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            // Insert history first
            using (var cmdHist = new SqlCommand("INSERT INTO PasswordHistory (UserId, PasswordHash) VALUES (@userId,@hash)", conn))
            {
                cmdHist.Parameters.AddWithValue("@userId", userId);
                cmdHist.Parameters.AddWithValue("@hash", newHash); // store old/new as desired; here we store new for record
                cmdHist.ExecuteNonQuery();
            }
            using var cmd = new SqlCommand("UPDATE Users SET PasswordHash=@hash, IsFirstLogin=0 WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@hash", newHash);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public IEnumerable<string> GetPasswordHistoryHashes(int userId)
        {
            var list = new List<string>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT PasswordHash FROM PasswordHistory WHERE UserId=@userId ORDER BY CreatedAt DESC", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            using var r = cmd.ExecuteReader();
            while (r.Read()) list.Add(r["PasswordHash"].ToString()!);
            return list;
        }

        public void ResetPasswordToHash(int userId, string newHash)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("UPDATE Users SET PasswordHash=@hash, IsFirstLogin=1 WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@hash", newHash);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public (int Id, string Question, string AnswerHash)[] GetQuestionsForUser(int userId)
        {
            var q = new List<(int, string, string)>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT Id, Question, AnswerHash FROM SecurityQuestions WHERE UserId=@userId", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            using var r = cmd.ExecuteReader();
            while (r.Read()) q.Add((Convert.ToInt32(r["Id"]), r["Question"].ToString()!, r["AnswerHash"].ToString()!));
            return q.Select(t => (t.Item1, t.Item2, t.Item3)).ToArray();
        }

        public void InsertPasswordHistory(int userId, string hash)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("INSERT INTO PasswordHistory (UserId, PasswordHash) VALUES (@userId,@hash)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.ExecuteNonQuery();
        }
    }
}
