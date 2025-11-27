using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
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

            string mensajeError;
            bool resultado = _userService.ChangePassword(usuario, nuevaPassword, confirmarPassword, out mensajeError);

            if (resultado)
            {
                MessageBox.Show("Contraseña actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}