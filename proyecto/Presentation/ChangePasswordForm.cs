using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DataAccess.Entities;
using LayeredApp.Business.Services;

using System;
using System.Windows.Forms;


namespace Presentation
{
    public partial class ChangePasswordForm : Form
    {
        private UserService _userService;


        // Constructor que recibe el servicio
        public ChangePasswordForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }


        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string nuevaPassword = txtNuevaPassword.Text;
            string confirmarPassword = txtConfirmarPassword.Text;


            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(nuevaPassword))
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (nuevaPassword != confirmarPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Pedir la contraseña actual en un diálogo modal seguro
            string? actual = PromptForCurrentPassword();
            if (actual == null) return; // usuario canceló

            var user = _userService.GetUserByUsername(usuario);
            if (user == null)
            {
                MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_userService.ChangePassword(user.Id, actual, nuevaPassword, out var reason))
            {
                MessageBox.Show("Contraseña actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show($"No se pudo cambiar la contraseña: {reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Muestra un diálogo modal sencillo para ingresar la contraseña actual.
        // Devuelve la contraseña ingresada o null si el usuario cancela.
        private string? PromptForCurrentPassword()
        {
            using (var frm = new Form())
            {
                frm.Text = "Contraseña actual";
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ClientSize = new Size(360, 120);
                frm.MinimizeBox = false;
                frm.MaximizeBox = false;

                var lbl = new Label() { Left = 12, Top = 12, Text = "Ingrese su contraseña actual:", AutoSize = true };
                var txt = new TextBox() { Left = 12, Top = 36, Width = 332, UseSystemPasswordChar = true };
                var btnOk = new Button() { Text = "Aceptar", Left = 180, Width = 80, Top = 72, DialogResult = DialogResult.OK };
                var btnCancel = new Button() { Text = "Cancelar", Left = 268, Width = 80, Top = 72, DialogResult = DialogResult.Cancel };

                frm.Controls.Add(lbl);
                frm.Controls.Add(txt);
                frm.Controls.Add(btnOk);
                frm.Controls.Add(btnCancel);
                frm.AcceptButton = btnOk;
                frm.CancelButton = btnCancel;

                var dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK) return txt.Text;
                return null;
            }
        }
    }
}