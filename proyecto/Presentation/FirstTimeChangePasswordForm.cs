using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredApp.Business.Services;

namespace Presentation
{
    public partial class FirstTimeChangePasswordForm : Form
    {
        private readonly int _userId;
        private readonly UserService _userService;

        public FirstTimeChangePasswordForm(int userId, UserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            var qs = _userService.GetSystemConfig(); // number of questions known via config; we fetch from repo via service methods if needed
            // For simplicity: load all questions for user and display as labels+textboxes in the form
            // (implementation of dynamic UI omitted; assume designer has txtAnswer1, txtAnswer2 etc)
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPassword.Text;
            string confirm = txtConfirmPassword.Text;
            if (newPass != confirm) { MessageBox.Show("Las contraseñas no coinciden"); return; }
            if (_userService.ChangePasswordFirstTime(_userId, newPass, out var reason))
            {
                MessageBox.Show("Contraseña establecida. Ya podés ingresar.");
                this.Close();
            }
            else MessageBox.Show(reason);
        }
    }
}
