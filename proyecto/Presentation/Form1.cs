using System;
using System.Linq;
using System.Windows.Forms;
using LayeredApp.Business.Services;

namespace Presentation
{
    public partial class Form1 : Form
    {
        private readonly UserService _userService;

        public Form1()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtPassword.Text;
            var u = _userService.Login(user, pass);
            if (u == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }
            if (u.IsFirstLogin)
            {
                // abrir formulario para cambio obligatorio (pasar user id)
                var first = new FirstTimeChangePasswordForm(u.Id, _userService);
                first.ShowDialog();
                return;
            }
            MessageBox.Show($"Bienvenido {u.Username}");
            // abrir main según rol...
        }

        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgot = new ForgotPasswordForm(_userService);
            forgot.ShowDialog();
        }

        private void btnOpenChangePassword_Click(object sender, EventArgs e)
        {
            var form = new ChangePasswordForm(_userService);
            form.ShowDialog();
        }
    }
}
