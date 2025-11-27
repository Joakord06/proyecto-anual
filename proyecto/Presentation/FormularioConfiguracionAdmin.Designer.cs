using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation
{
    partial class AdminConfigForm
    {
        private IContainer components = null;
        private Label lblMinLength;
        private NumericUpDown numMinLength;
        private Label lblQuestions;
        private NumericUpDown numQuestions;
        private GroupBox grpRules;
        private CheckBox chkUpperLower;
        private CheckBox chkDigits;
        private CheckBox chkSpecial;
        private CheckBox chkDisallowPrev;
        private CheckBox chkDisallowPersonal;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMinLength = new Label();
            numMinLength = new NumericUpDown();
            lblQuestions = new Label();
            numQuestions = new NumericUpDown();
            grpRules = new GroupBox();
            chkUpperLower = new CheckBox();
            chkDigits = new CheckBox();
            chkSpecial = new CheckBox();
            chkDisallowPrev = new CheckBox();
            chkDisallowPersonal = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            pnlNav = new Panel();
            btnNavConfig = new Button();
            btnNavUsers = new Button();
            pnlContent = new Panel();
            pnlUsers = new Panel();
            dgvUsers = new DataGridView();
            lblNewUser = new Label();
            txtNewUsername = new TextBox();
            txtNewEmail = new TextBox();
            txtNewPassword = new TextBox();
            cmbRole = new ComboBox();
            btnCreateUser = new Button();
            ((ISupportInitialize)numMinLength).BeginInit();
            ((ISupportInitialize)numQuestions).BeginInit();
            grpRules.SuspendLayout();
            pnlNav.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlUsers.SuspendLayout();
            ((ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblMinLength
            // 
            lblMinLength.AutoSize = true;
            lblMinLength.Location = new Point(12, 12);
            lblMinLength.Name = "lblMinLength";
            lblMinLength.Size = new Size(222, 20);
            lblMinLength.TabIndex = 0;
            lblMinLength.Text = "Longitud mínima de contraseña:";
            // 
            // numMinLength
            // 
            numMinLength.Location = new Point(240, 12);
            numMinLength.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            numMinLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMinLength.Name = "numMinLength";
            numMinLength.Size = new Size(80, 27);
            numMinLength.TabIndex = 1;
            numMinLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuestions
            // 
            lblQuestions.AutoSize = true;
            lblQuestions.Location = new Point(12, 52);
            lblQuestions.Name = "lblQuestions";
            lblQuestions.Size = new Size(151, 20);
            lblQuestions.TabIndex = 2;
            lblQuestions.Text = "Preguntas requeridas:";
            // 
            // numQuestions
            // 
            numQuestions.Location = new Point(240, 48);
            numQuestions.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numQuestions.Name = "numQuestions";
            numQuestions.Size = new Size(80, 27);
            numQuestions.TabIndex = 3;
            // 
            // grpRules
            // 
            grpRules.Controls.Add(chkUpperLower);
            grpRules.Controls.Add(chkDigits);
            grpRules.Controls.Add(chkSpecial);
            grpRules.Controls.Add(chkDisallowPrev);
            grpRules.Controls.Add(chkDisallowPersonal);
            grpRules.Location = new Point(12, 92);
            grpRules.Name = "grpRules";
            grpRules.Size = new Size(436, 140);
            grpRules.TabIndex = 4;
            grpRules.TabStop = false;
            grpRules.Text = "Reglas de contraseña";
            // 
            // chkUpperLower
            // 
            chkUpperLower.AutoSize = true;
            chkUpperLower.Location = new Point(12, 22);
            chkUpperLower.Name = "chkUpperLower";
            chkUpperLower.Size = new Size(244, 24);
            chkUpperLower.TabIndex = 0;
            chkUpperLower.Text = "Requerir mayúsculas/minúsculas";
            // 
            // chkDigits
            // 
            chkDigits.AutoSize = true;
            chkDigits.Location = new Point(12, 46);
            chkDigits.Name = "chkDigits";
            chkDigits.Size = new Size(137, 24);
            chkDigits.TabIndex = 1;
            chkDigits.Text = "Requerir dígitos";
            // 
            // chkSpecial
            // 
            chkSpecial.AutoSize = true;
            chkSpecial.Location = new Point(12, 70);
            chkSpecial.Name = "chkSpecial";
            chkSpecial.Size = new Size(230, 24);
            chkSpecial.TabIndex = 2;
            chkSpecial.Text = "Requerir caracteres especiales";
            // 
            // chkDisallowPrev
            // 
            chkDisallowPrev.AutoSize = true;
            chkDisallowPrev.Location = new Point(12, 94);
            chkDisallowPrev.Name = "chkDisallowPrev";
            chkDisallowPrev.Size = new Size(216, 24);
            chkDisallowPrev.TabIndex = 3;
            chkDisallowPrev.Text = "Prohibir contraseñas previas";
            // 
            // chkDisallowPersonal
            // 
            chkDisallowPersonal.AutoSize = true;
            chkDisallowPersonal.Location = new Point(12, 116);
            chkDisallowPersonal.Name = "chkDisallowPersonal";
            chkDisallowPersonal.Size = new Size(247, 24);
            chkDisallowPersonal.TabIndex = 4;
            chkDisallowPersonal.Text = "Prohibir uso de datos personales";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(253, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(357, 274);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlNav
            // 
            pnlNav.Controls.Add(btnNavConfig);
            pnlNav.Controls.Add(btnNavUsers);
            pnlNav.Location = new Point(12, 12);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(200, 480);
            pnlNav.TabIndex = 0;
            // 
            // btnNavConfig
            // 
            btnNavConfig.Location = new Point(12, 16);
            btnNavConfig.Name = "btnNavConfig";
            btnNavConfig.Size = new Size(176, 36);
            btnNavConfig.TabIndex = 0;
            btnNavConfig.Text = "Configuración";
            // 
            // btnNavUsers
            // 
            btnNavUsers.Location = new Point(12, 64);
            btnNavUsers.Name = "btnNavUsers";
            btnNavUsers.Size = new Size(176, 36);
            btnNavUsers.TabIndex = 1;
            btnNavUsers.Text = "Gestión de usuarios";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(lblMinLength);
            pnlContent.Controls.Add(numMinLength);
            pnlContent.Controls.Add(lblQuestions);
            pnlContent.Controls.Add(numQuestions);
            pnlContent.Controls.Add(grpRules);
            pnlContent.Controls.Add(pnlUsers);
            pnlContent.Location = new Point(220, 12);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(460, 480);
            pnlContent.TabIndex = 1;
            // 
            // pnlUsers
            // 
            pnlUsers.Controls.Add(dgvUsers);
            pnlUsers.Controls.Add(lblNewUser);
            pnlUsers.Controls.Add(txtNewUsername);
            pnlUsers.Controls.Add(txtNewEmail);
            pnlUsers.Controls.Add(txtNewPassword);
            pnlUsers.Controls.Add(btnCancel);
            pnlUsers.Controls.Add(btnSave);
            pnlUsers.Controls.Add(cmbRole);
            pnlUsers.Controls.Add(btnCreateUser);
            pnlUsers.Dock = DockStyle.Fill;
            pnlUsers.Location = new Point(0, 0);
            pnlUsers.Name = "pnlUsers";
            pnlUsers.Size = new Size(460, 480);
            pnlUsers.TabIndex = 7;
            pnlUsers.Visible = false;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ColumnHeadersHeight = 29;
            dgvUsers.Dock = DockStyle.Top;
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(460, 200);
            dgvUsers.TabIndex = 0;
            // 
            // dgvQuestions (lista de preguntas de seguridad)
            // 
            var dgvQuestions = new DataGridView();
            dgvQuestions.Name = "dgvQuestions";
            dgvQuestions.Dock = DockStyle.Bottom;
            dgvQuestions.Height = 140;
            dgvQuestions.ReadOnly = true;
            dgvQuestions.AllowUserToAddRows = false;
            dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pnlUsers.Controls.Add(dgvQuestions);
            // 
            // lblNewUser
            // 
            lblNewUser.Location = new Point(0, 186);
            lblNewUser.Name = "lblNewUser";
            lblNewUser.Size = new Size(100, 23);
            lblNewUser.TabIndex = 1;
            lblNewUser.Text = "Crear usuario:";
            // 
            // lblQuestion
            // 
            var lblQuestion = new Label();
            lblQuestion.Location = new Point(0, 320);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(140, 23);
            lblQuestion.Text = "Pregunta:";
            pnlUsers.Controls.Add(lblQuestion);

            var txtNewQuestion = new TextBox();
            txtNewQuestion.Name = "txtNewQuestion";
            txtNewQuestion.Location = new Point(0, 344);
            txtNewQuestion.Size = new Size(260, 27);
            pnlUsers.Controls.Add(txtNewQuestion);

            var lblAnswer = new Label();
            lblAnswer.Location = new Point(0, 376);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(140, 23);
            lblAnswer.Text = "Respuesta (visible):";
            pnlUsers.Controls.Add(lblAnswer);

            var txtNewAnswer = new TextBox();
            txtNewAnswer.Name = "txtNewAnswer";
            txtNewAnswer.Location = new Point(0, 400);
            txtNewAnswer.Size = new Size(260, 27);
            pnlUsers.Controls.Add(txtNewAnswer);

            var btnAddQuestion = new Button();
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Text = "Agregar pregunta";
            btnAddQuestion.Location = new Point(280, 344);
            btnAddQuestion.Size = new Size(140, 30);
            pnlUsers.Controls.Add(btnAddQuestion);

            var btnDeleteQuestion = new Button();
            btnDeleteQuestion.Name = "btnDeleteQuestion";
            btnDeleteQuestion.Text = "Eliminar pregunta";
            btnDeleteQuestion.Location = new Point(280, 384);
            btnDeleteQuestion.Size = new Size(140, 30);
            pnlUsers.Controls.Add(btnDeleteQuestion);
            // 
            // txtNewUsername
            // 
            txtNewUsername.Location = new Point(0, 208);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.PlaceholderText = "Usuario";
            txtNewUsername.Size = new Size(140, 27);
            txtNewUsername.TabIndex = 2;
            // 
            // txtNewEmail
            // 
            txtNewEmail.Location = new Point(150, 208);
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.PlaceholderText = "Email";
            txtNewEmail.Size = new Size(160, 27);
            txtNewEmail.TabIndex = 3;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(0, 240);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PlaceholderText = "Contraseña";
            txtNewPassword.Size = new Size(140, 27);
            txtNewPassword.TabIndex = 4;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // cmbRole
            // 
            cmbRole.Items.AddRange(new object[] { "User", "Admin" });
            cmbRole.Location = new Point(150, 240);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(121, 28);
            cmbRole.TabIndex = 5;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(140, 287);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(100, 30);
            btnCreateUser.TabIndex = 6;
            btnCreateUser.Text = "Crear";
            // 
            // AdminConfigForm
            // 
            ClientSize = new Size(700, 520);
            Controls.Add(pnlNav);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminConfigForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configuración del sistema";
            ((ISupportInitialize)numMinLength).EndInit();
            ((ISupportInitialize)numQuestions).EndInit();
            grpRules.ResumeLayout(false);
            grpRules.PerformLayout();
            pnlNav.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlUsers.ResumeLayout(false);
            pnlUsers.PerformLayout();
            ((ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlNav;
        private Button btnNavConfig;
        private Button btnNavUsers;
        private Panel pnlContent;
        private Panel pnlUsers;
        private DataGridView dgvUsers;
        private Label lblNewUser;
        private TextBox txtNewUsername;
        private TextBox txtNewEmail;
        private TextBox txtNewPassword;
        private ComboBox cmbRole;
        private Button btnCreateUser;
    }
}
