using System;
using System.Windows.Forms;
using LayeredApp.Business.Services;
using LayeredApp.Business.DTOs;

namespace Presentation
{
    public partial class PanelUsuarioForm : Form
    {
        private readonly UserDto _user;
        private readonly UserService _userService;

        public PanelUsuarioForm(UserDto user, UserService userService)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblUsername.Text = $"Usuario: {_user.Username}";
            lblRole.Text = $"Rol: {_user.Role}";
            lblWelcome.Text = $"Bienvenido, {_user.Username}";
        }

        private void BtnChangePassword_Click(object? sender, EventArgs e)
        {
            using var f = new FormularioCambioContrasena(_userService);
            f.ShowDialog(this);
        }

        private void BtnManageQuestions_Click(object? sender, EventArgs e)
        {
            using var f = new FormPreguntasSeguridad(_user.Id, _userService);
            f.ShowDialog(this);
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
