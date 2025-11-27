using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredApp.Business.Services;

namespace Presentation
{
    public partial class RecuperarContrasenaForm : Form
    {
        private readonly UserService _userService;
        private int _userId;
        private IDictionary<int, string> _answers = new Dictionary<int, string>();

        public RecuperarContrasenaForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnLoadQuestions_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var user = _userService.GetUserByUsername(username);
            if (user == null) { MessageBox.Show("Usuario no encontrado"); return; }
            _userId = user.Id;
            
            var qs = new DataAccess.Repositories.UserRepository().GetSecurityQuestions(_userId).ToArray();
            if (qs.Length == 0) { MessageBox.Show("No hay preguntas registradas"); return; }
            lblQ1.Text = qs[0].Question;
            
        }

        private void btnSubmitAnswers_Click(object sender, EventArgs e)
        {
            
            var answers = new Dictionary<int, string>();
            
            var qs = new DataAccess.Repositories.UserRepository().GetSecurityQuestions(_userId).ToArray();
            if (qs.Length > 0) answers[qs[0].Id] = txtAnswer1.Text.Trim();
            if (qs.Length > 1) answers[qs[1].Id] = txtAnswer2.Text.Trim();

            var (tempPass, sent) = _userService.ResetPasswordBySecurity(txtUsername.Text.Trim(), answers);
            if (string.IsNullOrEmpty(tempPass))
            {
                MessageBox.Show("Respuestas incorrectas o error.");
                return;
            }
            MessageBox.Show(sent ? "Se enviÃ³ la contraseÃ±a temporal al correo." : $"ContraseÃ±a temporal: {tempPass}");
            this.Close();
        }
    }
}

