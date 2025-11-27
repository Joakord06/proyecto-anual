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

        // designer fields (declared in the Designer partial class)

        public AdminConfigForm()
        {
            InitializeComponent();
            LoadConfig();
            WireDynamicControls();
        }

        private void WireDynamicControls()
        {
            if (btnNavConfig != null) btnNavConfig.Click += (s, e) => ShowConfig();
            if (btnNavUsers != null) btnNavUsers.Click += (s, e) => ShowUsers();
            if (btnCreateUser != null) btnCreateUser.Click += BtnCreateUser_Click;
            // wire selection and question buttons
            if (dgvUsers != null) dgvUsers.SelectionChanged += (s, e) => LoadQuestionsForSelectedUser();
            var btnAdd = this.Controls.Find("btnAddQuestion", true).FirstOrDefault() as Button;
            var btnDel = this.Controls.Find("btnDeleteQuestion", true).FirstOrDefault() as Button;
            if (btnAdd != null) btnAdd.Click += BtnAddQuestion_Click;
            if (btnDel != null) btnDel.Click += BtnDeleteQuestion_Click;
        }

        private int? GetSelectedUserId()
        {
            if (dgvUsers == null) return null;
            if (dgvUsers.SelectedRows.Count == 0) return null;
            var row = dgvUsers.SelectedRows[0];
            if (row.Cells["Id"] == null) return null;
            return Convert.ToInt32(row.Cells["Id"].Value);
        }

        private void LoadQuestionsForSelectedUser()
        {
            var uid = GetSelectedUserId();
            var dgvQ = this.Controls.Find("dgvQuestions", true).FirstOrDefault() as DataGridView;
            if (dgvQ == null) return;
            dgvQ.DataSource = null;
            if (uid == null) return;
            var qlist = _userRepo.GetQuestionsForUser(uid.Value);
            dgvQ.DataSource = qlist.Select(q => new { q.Id, q.Question }).ToList();
            dgvQ.AutoResizeColumns();
        }

        private static string HashAnswerPlain(string answer)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(answer.Trim().ToLower()));
            var sb = new System.Text.StringBuilder();
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        private void BtnAddQuestion_Click(object? sender, EventArgs e)
        {
            var uid = GetSelectedUserId();
            if (uid == null) { MessageBox.Show("Seleccione un usuario primero."); return; }
            var txtQ = this.Controls.Find("txtNewQuestion", true).FirstOrDefault() as TextBox;
            var txtA = this.Controls.Find("txtNewAnswer", true).FirstOrDefault() as TextBox;
            if (txtQ == null || txtA == null) return;
            var q = txtQ.Text?.Trim();
            var a = txtA.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(q) || string.IsNullOrWhiteSpace(a)) { MessageBox.Show("Pregunta y respuesta son obligatorias."); return; }
            var ah = HashAnswerPlain(a);
            try
            {
                _userRepo.AddSecurityQuestion(uid.Value, q, ah);
                MessageBox.Show("Pregunta agregada.");
                txtQ.Text = "";
                txtA.Text = "";
                LoadQuestionsForSelectedUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error agregando pregunta: {ex.Message}");
            }
        }

        private void BtnDeleteQuestion_Click(object? sender, EventArgs e)
        {
            var uid = GetSelectedUserId();
            if (uid == null) { MessageBox.Show("Seleccione un usuario primero."); return; }
            var dgvQ = this.Controls.Find("dgvQuestions", true).FirstOrDefault() as DataGridView;
            if (dgvQ == null || dgvQ.SelectedRows.Count == 0) { MessageBox.Show("Seleccione una pregunta para eliminar."); return; }
            var idObj = dgvQ.SelectedRows[0].Cells["Id"].Value;
            if (idObj == null) { MessageBox.Show("No se pudo determinar la pregunta seleccionada."); return; }
            int qid = Convert.ToInt32(idObj);
            try
            {
                _userRepo.DeleteSecurityQuestionById(qid);
                MessageBox.Show("Pregunta eliminada.");
                LoadQuestionsForSelectedUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando pregunta: {ex.Message}");
            }
        }

        private void ShowConfig()
        {
            if (pnlUsers != null)
            {
                pnlUsers.Visible = false;
            }
            this.grpRules.Visible = true;
            // ensure config controls are on top
            this.grpRules.BringToFront();
        }

        private void ShowUsers()
        {
            if (pnlUsers == null) return;
            // hide config and show users panel, bring it to front to avoid overlap
            this.grpRules.Visible = false;
            pnlUsers.Visible = true;
            pnlUsers.BringToFront();
            LoadUsers();
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
