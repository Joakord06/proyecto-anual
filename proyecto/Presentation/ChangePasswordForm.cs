using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DataAccess.Entities;
using LayeredApp.Business.Services;

namespace Presentation
{
    public partial class ChangePasswordForm : Form
    {
        private readonly UserService _userService;

        public ChangePasswordForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string securityAnswer = txtSecurityAnswer.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            var user = _userService.GetUserByUsername(username);
            if (user == null)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            // Verificar respuesta de seguridad
            if (!string.Equals(user.SecurityAnswer, securityAnswer, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Respuesta de seguridad incorrecta.");
                return;
            }

            // Concatenar usuario + contraseña y encriptar
            string combined = username + newPassword;
            user.Password = ComputeSha256Hash(combined);

            _userService.UpdateUserPassword(user);

            MessageBox.Show("Contraseña cambiada correctamente.");
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtNewPassword.Text = GenerateRandomPassword();
            txtConfirmPassword.Text = txtNewPassword.Text;
        }

        private string GenerateRandomPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var random = new Random();
            var password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            return new string(password);
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
