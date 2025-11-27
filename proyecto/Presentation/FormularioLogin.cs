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
                    var first = new PrimerCambioContrasenaForm(u.Id, _userService);
                first.StartPosition = FormStartPosition.CenterParent;
                first.ShowDialog(this);
                return;
            }
            // Abrir panel según rol
            if (string.Equals(u.Role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                var admin = new AdminConfigForm();
                admin.StartPosition = FormStartPosition.CenterParent;
                admin.ShowDialog(this);
            }
            else
            {
                // map to DTO and open user panel
                try
                {
                    var dto = LayeredApp.Business.Mappers.EntityMapper.ToDto(u);
                        var userPanel = new PanelUsuarioForm(dto, _userService);
                    userPanel.StartPosition = FormStartPosition.CenterParent;
                    userPanel.ShowDialog(this);
                }
                catch
                {
                    MessageBox.Show($"Bienvenido {u.Username}");
                }
            }
        }

        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                var forgot = new RecuperarContrasenaForm(_userService);
            forgot.StartPosition = FormStartPosition.CenterParent;
            forgot.ShowDialog(this);
        }

        private void btnOpenChangePassword_Click(object sender, EventArgs e)
        {
                var form = new FormularioCambioContrasena(_userService);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }
    }
}
