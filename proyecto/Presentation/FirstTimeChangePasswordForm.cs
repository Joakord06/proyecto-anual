// ...existing code...
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    partial class AdminConfigForm
    {
        private System.ComponentModel.IContainer components = null;
        private NumericUpDown numMinLength;
        private NumericUpDown numQuestions;
        private CheckBox chkUpperLower;
        private CheckBox chkDigits;
        private CheckBox chkSpecial;
        private CheckBox chkDisallowPrev;
        private CheckBox chkDisallowPersonal;
        private Button btnSave;
        private Button btnCancel;
        private Label lblMinLength;
        private Label lblQuestions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.numMinLength = new NumericUpDown();
            this.numQuestions = new NumericUpDown();
            this.chkUpperLower = new CheckBox();
            this.chkDigits = new CheckBox();
            this.chkSpecial = new CheckBox();
            this.chkDisallowPrev = new CheckBox();
            this.chkDisallowPersonal = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblMinLength = new Label();
            this.lblQuestions = new Label();

            // AdminConfigForm
            this.Text = "Configuración - Administrador";
            this.ClientSize = new Size(420, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // lblMinLength
            this.lblMinLength.Text = "Longitud mínima contraseña:";
            this.lblMinLength.Location = new Point(12, 18);
            this.lblMinLength.AutoSize = true;

            // numMinLength
            this.numMinLength.Location = new Point(220, 14);
            this.numMinLength.Minimum = 4;
            this.numMinLength.Maximum = 128;
            this.numMinLength.Value = 8;

            // lblQuestions
            this.lblQuestions.Text = "Preguntas requeridas:";
            this.lblQuestions.Location = new Point(12, 54);
            this.lblQuestions.AutoSize = true;

            // numQuestions
            this.numQuestions.Location = new Point(220, 50);
            this.numQuestions.Minimum = 0;
            this.numQuestions.Maximum = 10;
            this.numQuestions.Value = 2;

            // chkUpperLower
            this.chkUpperLower.Text = "Requerir mayúsculas/minúsculas";
            this.chkUpperLower.Location = new Point(12, 90);
            this.chkUpperLower.AutoSize = true;

            // chkDigits
            this.chkDigits.Text = "Requerir dígitos";
            this.chkDigits.Location = new Point(12, 120);
            this.chkDigits.AutoSize = true;

            // chkSpecial
            this.chkSpecial.Text = "Requerir caracteres especiales";
            this.chkSpecial.Location = new Point(12, 150);
            this.chkSpecial.AutoSize = true;

            // chkDisallowPrev
            this.chkDisallowPrev.Text = "Prohibir contraseñas previas";
            this.chkDisallowPrev.Location = new Point(12, 180);
            this.chkDisallowPrev.AutoSize = true;

            // chkDisallowPersonal
            this.chkDisallowPersonal.Text = "Prohibir datos personales";
            this.chkDisallowPersonal.Location = new Point(12, 210);
            this.chkDisallowPersonal.AutoSize = true;

            // btnSave
            this.btnSave.Text = "Guardar";
            this.btnSave.Location = new Point(232, 250);
            this.btnSave.Size = new Size(80, 30);
            this.btnSave.Click += btnSave_Click;

            // btnCancel
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(318, 250);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.DialogResult = DialogResult.Cancel;

            // Compose
            this.Controls.Add(this.lblMinLength);
            this.Controls.Add(this.numMinLength);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.numQuestions);
            this.Controls.Add(this.chkUpperLower);
            this.Controls.Add(this.chkDigits);
            this.Controls.Add(this.chkSpecial);
            this.Controls.Add(this.chkDisallowPrev);
            this.Controls.Add(this.chkDisallowPersonal);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
        }
    }
}
// ...existing code...using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredApp.Business.Services;

namespace Presentation
{
    public partial class FirstTimeChangePasswordForm : Form
    {
        private readonly int _userId;
        private readonly UserService _userService;

        public FirstTimeChangePasswordForm(int userId, UserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            var qs = _userService.GetSystemConfig(); // number of questions known via config; we fetch from repo via service methods if needed
            // For simplicity: load all questions for user and display as labels+textboxes in the form
            // (implementation of dynamic UI omitted; assume designer has txtAnswer1, txtAnswer2 etc)
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPassword.Text;
            string confirm = txtConfirmPassword.Text;
            if (newPass != confirm) { MessageBox.Show("Las contraseñas no coinciden"); return; }
            if (_userService.ChangePasswordFirstTime(_userId, newPass, out var reason))
            {
                MessageBox.Show("Contraseña establecida. Ya podés ingresar.");
                this.Close();
            }
            else MessageBox.Show(reason);
        }
    }
}
