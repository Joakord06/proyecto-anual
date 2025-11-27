// ...existing code...
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Presentation
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCurrent;
        private TextBox txtUsuario;
        private Label lblNew;
        private TextBox txtNuevaPassword;
        private Label lblConfirm;
        private TextBox txtConfirmarPassword;
        private Button btnChange;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblCurrent = new Label();
            txtUsuario = new TextBox();
            lblNew = new Label();
            txtNuevaPassword = new TextBox();
            lblConfirm = new Label();
            txtConfirmarPassword = new TextBox();
            btnChange = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(20, 20);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(62, 20);
            lblCurrent.TabIndex = 0;
            lblCurrent.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(160, 16);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(240, 27);
            txtUsuario.TabIndex = 1;
            txtUsuario.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new Point(20, 60);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(130, 20);
            lblNew.TabIndex = 2;
            lblNew.Text = "Nueva contraseña:";
            // 
            // txtNuevaPassword
            // 
            txtNuevaPassword.Location = new Point(160, 56);
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.Size = new Size(240, 27);
            txtNuevaPassword.TabIndex = 3;
            txtNuevaPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(20, 100);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(154, 20);
            lblConfirm.TabIndex = 4;
            lblConfirm.Text = "Confirmar contraseña:";
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.Location = new Point(160, 96);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Size = new Size(240, 27);
            txtConfirmarPassword.TabIndex = 5;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            // 
            // btnChange
            // 
            btnChange.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnChange.Location = new Point(240, 140);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 28);
            btnChange.TabIndex = 6;
            btnChange.Text = "Cambiar";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(325, 140);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 28);
            btnClose.TabIndex = 7;
            btnClose.Text = "Cerrar";
            // 
            // ChangePasswordForm
            // 
            ClientSize = new Size(420, 200);
            Controls.Add(lblCurrent);
            Controls.Add(txtUsuario);
            Controls.Add(lblNew);
            Controls.Add(txtNuevaPassword);
            Controls.Add(lblConfirm);
            Controls.Add(txtConfirmarPassword);
            Controls.Add(btnChange);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cambiar contraseña";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
// ...existing code...