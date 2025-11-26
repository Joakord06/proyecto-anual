using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using DataAccess.Repositories;

namespace Presentation
{
    public partial class AdminConfigForm : Form
    {
        private readonly ConfigRepository _cfgRepo = new ConfigRepository();

        public AdminConfigForm()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void LoadConfig()
        {
            var c = _cfgRepo.GetConfig();
            numMinLength.Value = c.MinPasswordLength;
            numQuestions.Value = c.QuestionsToAnswer;
            chkUpperLower.Checked = c.RequireUpperLower;
            chkDigits.Checked = c.RequireDigits;
            chkSpecial.Checked = c.RequireSpecial;
            chkDisallowPrev.Checked = c.DisallowPreviousPasswords;
            chkDisallowPersonal.Checked = c.DisallowPersonalData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var c = new DataAccess.Entities.SystemConfig
            {
                MinPasswordLength = (int)numMinLength.Value,
                QuestionsToAnswer = (int)numQuestions.Value,
                RequireUpperLower = chkUpperLower.Checked,
                RequireDigits = chkDigits.Checked,
                RequireSpecial = chkSpecial.Checked,
                DisallowPreviousPasswords = chkDisallowPrev.Checked,
                DisallowPersonalData = chkDisallowPersonal.Checked
            };
            _cfgRepo.SaveConfig(c);
            MessageBox.Show("Configuración guardada.");
        }
    }
}
