using System.Windows.Forms;

namespace Presentation
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtSecurityAnswer;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblSecurityAnswer;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnGenerate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtSecurityAnswer = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblSecurityAnswer = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.Text = "Usuario:";
            this.lblUsername.Location = new System.Drawing.Point(20, 20);
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(140, 20);
            this.txtUsername.Size = new System.Drawing.Size(200, 23);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Text = "Nueva Contraseña:";
            this.lblNewPassword.Location = new System.Drawing.Point(20, 60);
            this.lblNewPassword.Size = new System.Drawing.Size(120, 23);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(140, 60);
            this.txtNewPassword.Size = new System.Drawing.Size(200, 23);
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Text = "Confirmar Contraseña:";
            this.lblConfirmPassword.Location = new System.Drawing.Point(20, 100);
            this.lblConfirmPassword.Size = new System.Drawing.Size(150, 23);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(180, 100);
            this.txtConfirmPassword.Size = new System.Drawing.Size(160, 23);
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblSecurityAnswer
            // 
            this.lblSecurityAnswer.Text = "Respuesta Seguridad:";
            this.lblSecurityAnswer.Location = new System.Drawing.Point(20, 140);
            this.lblSecurityAnswer.Size = new System.Drawing.Size(150, 23);
            // 
            // txtSecurityAnswer
            // 
            this.txtSecurityAnswer.Location = new System.Drawing.Point(180, 140);
            this.txtSecurityAnswer.Size = new System.Drawing.Size(160, 23);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Text = "Cambiar Contraseña";
            this.btnChangePassword.Location = new System.Drawing.Point(20, 190);
            this.btnChangePassword.Size = new System.Drawing.Size(150, 30);
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Text = "Generar Aleatoria";
            this.btnGenerate.Location = new System.Drawing.Point(180, 190);
            this.btnGenerate.Size = new System.Drawing.Size(150, 30);
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ChangePasswordForm
            // 
            this.ClientSize = new System.Drawing.Size(360, 250);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtSecurityAnswer);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblSecurityAnswer);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnGenerate);
            this.Text = "Cambiar Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
