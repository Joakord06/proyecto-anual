 
using System;
using System.Windows.Forms;
using LayeredApp.Business.Services;

namespace Presentation
{
    public partial class PrimerCambioContrasenaForm : Form
    {
        private readonly int _userId;
        private readonly UserService _userService;

        public PrimerCambioContrasenaForm(int userId, UserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            // If system requires security questions on first login, load them here.
            // Currently the designer contains only new/confirm password fields.
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var newPass = txtNewPassword.Text ?? string.Empty;
            var confirm = txtConfirmPassword.Text ?? string.Empty;
            if (newPass != confirm)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }

            if (_userService.ChangePasswordFirstTime(_userId, newPass, out var reason))
            {
                MessageBox.Show("Contraseña establecida. Ya podés ingresar.");
                this.Close();
            }
            else
            {
                MessageBox.Show(reason);
            }
        }
    }
}
