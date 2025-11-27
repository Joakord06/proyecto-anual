using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredApp.Business.Services;

namespace Presentation
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly UserService _userService;
        private int _userId;
        private IDictionary<int, string> _answers = new Dictionary<int, string>();

        public ForgotPasswordForm(UserService userService)
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
            // load questions into UI (simplified: assume fixed 2 labels and textboxes)
            var qs = new DataAccess.Repositories.UserRepository().GetSecurityQuestions(_userId).ToArray();
            if (qs.Length == 0) { MessageBox.Show("No hay preguntas registradas"); return; }
            lblQ1.Text = qs[0].Question;
            // if more questions exist fill others...
        }

        private void btnSubmitAnswers_Click(object sender, EventArgs e)
        {
            // Build answers dict based on the textboxes (example)
            var answers = new Dictionary<int, string>();
            // assume we have question ids stored or retrieved again:
            var qs = new DataAccess.Repositories.UserRepository().GetSecurityQuestions(_userId).ToArray();
            if (qs.Length > 0) answers[qs[0].Id] = txtAnswer1.Text.Trim();
            if (qs.Length > 1) answers[qs[1].Id] = txtAnswer2.Text.Trim();

            var (tempPass, sent) = _userService.ResetPasswordBySecurity(txtUsername.Text.Trim(), answers);
            if (string.IsNullOrEmpty(tempPass))
            {
                MessageBox.Show("Respuestas incorrectas o error.");
                return;
            }
            MessageBox.Show(sent ? "Se envió la contraseña temporal al correo." : $"Contraseña temporal: {tempPass}");
            this.Close();
        }
    }
}
