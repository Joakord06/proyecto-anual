using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DataAccess.Entities;
using LayeredApp.Business.Services;
namespace Presentation
{
    public partial class FormularioCambioContrasena : Form
    {
        private UserService _userService;


        
        public FormularioCambioContrasena(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }


        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string currentPassword = txtCurrentPassword.Text;
            string nuevaPassword = txtNuevaPassword.Text;
            string confirmarPassword = txtConfirmarPassword.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(nuevaPassword))
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nuevaPassword != confirmarPassword)
            {
                MessageBox.Show("Las contraseÃ±as no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            var user = _userService.GetUserByUsername(usuario);
            if (user == null)
            {
                MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mensajeError;
            bool resultado = _userService.ChangePassword(user.Id, currentPassword, nuevaPassword, out mensajeError);

            if (resultado)
            {
                MessageBox.Show("ContraseÃ±a actualizada correctamente", "Ã‰xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

