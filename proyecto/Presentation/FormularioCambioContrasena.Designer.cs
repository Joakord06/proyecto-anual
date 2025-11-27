// ...existing code...
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Presentation
{
    partial class FormularioCambioContrasena
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
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
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNew = new Label();
            txtNuevaPassword = new TextBox();
            lblConfirm = new Label();
            txtConfirmarPassword = new TextBox();
            btnChange = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(20, 20);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(160, 16);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(240, 27);
            txtUsuario.TabIndex = 1;
            txtUsuario.UseSystemPasswordChar = false;

            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new Point(20, 48);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(140, 20);
            lblCurrentPassword.TabIndex = 2;
            lblCurrentPassword.Text = "Contraseña actual:";

            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(160, 44);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(240, 27);
            txtCurrentPassword.TabIndex = 3;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new Point(20, 88);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(130, 20);
            lblNew.TabIndex = 4;
            lblNew.Text = "Nueva contraseña:";
            // 
            // txtNuevaPassword
            // 
            txtNuevaPassword.Location = new Point(160, 84);
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.Size = new Size(240, 27);
            txtNuevaPassword.TabIndex = 5;
            txtNuevaPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(20, 124);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(154, 20);
            lblConfirm.TabIndex = 6;
            lblConfirm.Text = "Confirmar contraseña:";
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.Location = new Point(160, 120);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Size = new Size(240, 27);
            txtConfirmarPassword.TabIndex = 7;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            // 
            // btnChange
            // 
            btnChange.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnChange.Location = new Point(240, 160);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 28);
            btnChange.TabIndex = 8;
            btnChange.Text = "Cambiar";
            btnChange.Click += new EventHandler(this.btnCambiar_Click);
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(325, 160);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 28);
            btnClose.TabIndex = 7;
            btnClose.Text = "Cerrar";
            // 
            // ChangePasswordForm
            // 
            ClientSize = new Size(420, 200);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblCurrentPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblNew);
            Controls.Add(txtNuevaPassword);
            Controls.Add(lblConfirm);
            Controls.Add(txtConfirmarPassword);
            Controls.Add(btnChange);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormularioCambioContrasena";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cambiar contraseña";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
// ...existing code...
