using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LayeredApp.Business.Services;

namespace Presentation
{
    public partial class FormPreguntasSeguridad : Form
    {
        private readonly UserService _userService;
        private readonly int _userId;

        public FormPreguntasSeguridad(int userId, UserService userService)
        {
            _userId = userId;
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            InitializeComponent();
            LoadExisting();
        }

        private void LoadExisting()
        {
            try
            {
                var qs = _userService.GetSecurityQuestionsForUser(_userId).ToArray();
                if (qs.Length > 0)
                {
                    txtQ1.Text = qs[0].Question;
                }
                if (qs.Length > 1)
                {
                    txtQ2.Text = qs[1].Question;
                }
            }
            catch {  }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            var list = new List<(string Question, string AnswerPlain)>();
            if (!string.IsNullOrWhiteSpace(txtQ1.Text) && !string.IsNullOrWhiteSpace(txtA1.Text))
                list.Add((txtQ1.Text.Trim(), txtA1.Text.Trim()));
            if (!string.IsNullOrWhiteSpace(txtQ2.Text) && !string.IsNullOrWhiteSpace(txtA2.Text))
                list.Add((txtQ2.Text.Trim(), txtA2.Text.Trim()));

            if (list.Count == 0)
            {
                MessageBox.Show("Agrega al menos una pregunta y respuesta.");
                return;
            }

            try
            {
                _userService.SaveSecurityQuestions(_userId, list);
                MessageBox.Show("Preguntas guardadas.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando preguntas: " + ex.Message);
            }
        }
    }
}

