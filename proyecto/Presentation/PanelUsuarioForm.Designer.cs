using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    partial class PanelUsuarioForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Label lblUsername;
        private Label lblRole;
        private Button btnChangePassword;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new Label();
            this.lblUsername = new Label();
            this.lblRole = new Label();
            this.btnChangePassword = new Button();
            this.btnLogout = new Button();

            // PanelUsuarioForm
            this.Text = "Panel de usuario";
            this.ClientSize = new Size(420, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            // lblWelcome
            this.lblWelcome.Text = "Bienvenido";
            this.lblWelcome.Font = new Font(this.lblWelcome.Font.FontFamily, 12, FontStyle.Bold);
            this.lblWelcome.Location = new Point(12, 12);
            this.lblWelcome.Size = new Size(396, 28);

            // lblUsername
            this.lblUsername.Text = "Usuario: --";
            this.lblUsername.Location = new Point(12, 52);
            this.lblUsername.AutoSize = true;

            // lblRole
            this.lblRole.Text = "Rol: --";
            this.lblRole.Location = new Point(12, 80);
            this.lblRole.AutoSize = true;

            // btnChangePassword
            this.btnChangePassword.Text = "Cambiar contraseña";
            this.btnChangePassword.Location = new Point(12, 120);
            this.btnChangePassword.Size = new Size(140, 30);
            this.btnChangePassword.Click += BtnChangePassword_Click;

            // btnManageQuestions
            var btnManageQuestions = new Button();
            btnManageQuestions.Text = "Preguntas seguridad";
            btnManageQuestions.Location = new Point(160, 120);
            btnManageQuestions.Size = new Size(140, 30);
            btnManageQuestions.Click += BtnManageQuestions_Click;
            this.Controls.Add(btnManageQuestions);

            // btnLogout
            this.btnLogout.Text = "Cerrar sesión";
            this.btnLogout.Location = new Point(300, 120);
            this.btnLogout.Size = new Size(108, 30);
            this.btnLogout.Click += BtnLogout_Click;

            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnLogout);
        }
    }
}
