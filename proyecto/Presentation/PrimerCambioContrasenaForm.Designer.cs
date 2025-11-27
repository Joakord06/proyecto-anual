using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation
{
    partial class PrimerCambioContrasenaForm
    {
        private IContainer components = null;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnAccept;
        private Label lblNew;
        private Label lblConfirm;

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
            this.components = new Container();
            this.txtNewPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();
            this.btnAccept = new Button();
            this.lblNew = new Label();
            this.lblConfirm = new Label();
            this.SuspendLayout();
            
            
            
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(12, 18);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(106, 15);
            this.lblNew.Text = "Nueva contraseÃ±a:";
            
            
            
            this.txtNewPassword.Location = new System.Drawing.Point(12, 36);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(260, 23);
            this.txtNewPassword.UseSystemPasswordChar = true;
            
            
            
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(12, 72);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(105, 15);
            this.lblConfirm.Text = "Confirmar contraseÃ±a:";
            
            
            
            this.txtConfirmPassword.Location = new System.Drawing.Point(12, 90);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(260, 23);
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            
            
            
            this.btnAccept.Location = new System.Drawing.Point(12, 130);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 30);
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new EventHandler(this.btnAccept_Click);
            
            
            
            this.ClientSize = new System.Drawing.Size(290, 180);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrimerCambioContrasenaForm";
            this.Text = "Primer cambio de contraseÃ±a";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

