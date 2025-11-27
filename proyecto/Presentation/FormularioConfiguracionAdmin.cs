using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using DataAccess.Repositories;

namespace Presentation
{
    public partial class AdminConfigForm : Form
    {
        private readonly ConfigRepository _cfgRepo = new ConfigRepository();
        private readonly DataAccess.Repositories.UserRepository _userRepo = new DataAccess.Repositories.UserRepository();

        // controls added dynamically in designer
        private ComboBox cmbView => this.Controls.Find("cmbView", true).FirstOrDefault() as ComboBox;
        private Panel pnlUsers => this.Controls.Find("pnlUsers", true).FirstOrDefault() as Panel;
        private DataGridView dgvUsers => pnlUsers?.Controls.Find("dgvUsers", true).FirstOrDefault() as DataGridView;
        private TextBox txtNewUsername => pnlUsers?.Controls.Find("txtNewUsername", true).FirstOrDefault() as TextBox;
        private TextBox txtNewEmail => pnlUsers?.Controls.Find("txtNewEmail", true).FirstOrDefault() as TextBox;
        private TextBox txtNewPassword => pnlUsers?.Controls.Find("txtNewPassword", true).FirstOrDefault() as TextBox;
        private ComboBox cmbRole => pnlUsers?.Controls.Find("cmbRole", true).FirstOrDefault() as ComboBox;
        private Button btnCreateUser => pnlUsers?.Controls.Find("btnCreateUser", true).FirstOrDefault() as Button;

        public AdminConfigForm()
        {
            InitializeComponent();
            LoadConfig();
            WireDynamicControls();
        }

        private void WireDynamicControls()
        {
            if (cmbView != null) cmbView.SelectedIndexChanged += CmbView_SelectedIndexChanged;
            if (btnCreateUser != null) btnCreateUser.Click += BtnCreateUser_Click;
        }

        private void CmbView_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbView == null || pnlUsers == null) return;
            pnlUsers.Visible = cmbView.SelectedIndex == 1; // 0 = Config, 1 = Users
            // reload users when showing panel
            if (pnlUsers.Visible) LoadUsers();
        }

        private void LoadUsers()
        {
            if (dgvUsers == null) return;
            dgvUsers.DataSource = null;
            var users = _userRepo.GetAllUsers();
            // simple projection to anonymous objects
            dgvUsers.DataSource = users.Select(u => new { u.Id, u.Username, u.Email, u.Role, u.IsFirstLogin, u.CreatedAt }).ToList();
            dgvUsers.AutoResizeColumns();
        }

        private void BtnCreateUser_Click(object? sender, EventArgs e)
        {
            if (txtNewUsername == null || txtNewPassword == null || cmbRole == null) return;
            var username = txtNewUsername.Text?.Trim();
            var email = txtNewEmail?.Text?.Trim();
            var pwd = txtNewPassword.Text ?? string.Empty;
            var role = cmbRole.SelectedItem?.ToString() ?? "User";
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pwd))
            {
                MessageBox.Show("Usuario y contraseña son obligatorios.");
                return;
            }
            // compute hash username+password
            string hash;
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(username + pwd));
                var sb = new System.Text.StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                hash = sb.ToString();
            }
            var user = new DataAccess.Entities.User
            {
                Username = username,
                PasswordHash = hash,
                Email = string.IsNullOrWhiteSpace(email) ? null : email,
                IsFirstLogin = true,
                Role = role
            };
            try
            {
                _userRepo.AddUser(user, new (string, string)[0]);
                MessageBox.Show("Usuario creado.");
                // clear fields
                txtNewUsername.Text = "";
                txtNewEmail.Text = "";
                txtNewPassword.Text = "";
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creando usuario: {ex.Message}");
            }
        }

        private void LoadConfig()
        {
            var c = _cfgRepo.GetConfig();
            numMinLength.Value = c.MinPasswordLength;
            numQuestions.Value = c.QuestionsToAnswer;
            chkUpperLower.Checked = c.RequireUpperLower;
            chkDigits.Checked = c.RequireDigits;
            chkSpecial.Checked = c.RequireSpecial;
            chkDisallowPrev.Checked = c.DisallowPreviousPasswords;
            chkDisallowPersonal.Checked = c.DisallowPersonalData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var c = new DataAccess.Entities.SystemConfig
            {
                MinPasswordLength = (int)numMinLength.Value,
                QuestionsToAnswer = (int)numQuestions.Value,
                RequireUpperLower = chkUpperLower.Checked,
                RequireDigits = chkDigits.Checked,
                RequireSpecial = chkSpecial.Checked,
                DisallowPreviousPasswords = chkDisallowPrev.Checked,
                DisallowPersonalData = chkDisallowPersonal.Checked
            };
            _cfgRepo.SaveConfig(c);
            MessageBox.Show("Configuración guardada.");
        }
    }
}
