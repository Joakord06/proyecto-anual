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
            this.components = new Container();
            this.lblMinLength = new Label();
            this.numMinLength = new NumericUpDown();
            this.lblQuestions = new Label();
            this.numQuestions = new NumericUpDown();
            this.grpRules = new GroupBox();
            this.chkUpperLower = new CheckBox();
            this.chkDigits = new CheckBox();
            this.chkSpecial = new CheckBox();
            this.chkDisallowPrev = new CheckBox();
            this.chkDisallowPersonal = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            ((ISupportInitialize)(this.numMinLength)).BeginInit();
            ((ISupportInitialize)(this.numQuestions)).BeginInit();
            this.grpRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // numMinLength
            // 
            this.lblMinLength.AutoSize = true;
            this.lblMinLength.Location = new System.Drawing.Point(16, 16);
            this.lblMinLength.Name = "lblMinLength";
            this.lblMinLength.Size = new System.Drawing.Size(180, 15);
            this.lblMinLength.Text = "Longitud mínima de contraseña:";

            this.numMinLength.Location = new System.Drawing.Point(220, 12);
            this.numMinLength.Minimum = 1;
            this.numMinLength.Maximum = 128;
            this.numMinLength.Name = "numMinLength";
            this.numMinLength.Size = new System.Drawing.Size(80, 23);
            // 
            // numQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Location = new System.Drawing.Point(16, 52);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(140, 15);
            this.lblQuestions.Text = "Preguntas requeridas:";

            this.numQuestions.Location = new System.Drawing.Point(220, 48);
            this.numQuestions.Minimum = 0;
            this.numQuestions.Maximum = 10;
            this.numQuestions.Name = "numQuestions";
            this.numQuestions.Size = new System.Drawing.Size(80, 23);
            // 
            // chkUpperLower
            // 
            this.grpRules.Location = new System.Drawing.Point(16, 88);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(360, 120);
            this.grpRules.Text = "Reglas de contraseña";

            this.chkUpperLower.AutoSize = true;
            this.chkUpperLower.Location = new System.Drawing.Point(12, 22);
            this.chkUpperLower.Name = "chkUpperLower";
            this.chkUpperLower.Size = new System.Drawing.Size(160, 19);
            this.chkUpperLower.Text = "Requerir mayúsculas/minúsculas";
            // 
            // chkDigits
            // 
            this.chkDigits.AutoSize = true;
            this.chkDigits.Location = new System.Drawing.Point(12, 46);
            this.chkDigits.Name = "chkDigits";
            this.chkDigits.Size = new System.Drawing.Size(97, 19);
            this.chkDigits.Text = "Requerir dígitos";
            // 
            // chkSpecial
            // 
            this.chkSpecial.AutoSize = true;
            this.chkSpecial.Location = new System.Drawing.Point(12, 70);
            this.chkSpecial.Name = "chkSpecial";
            this.chkSpecial.Size = new System.Drawing.Size(160, 19);
            this.chkSpecial.Text = "Requerir caracteres especiales";
            // 
            // chkDisallowPrev
            // 
            this.chkDisallowPrev.AutoSize = true;
            this.chkDisallowPrev.Location = new System.Drawing.Point(12, 94);
            this.chkDisallowPrev.Name = "chkDisallowPrev";
            this.chkDisallowPrev.Size = new System.Drawing.Size(190, 19);
            this.chkDisallowPrev.Text = "Prohibir contraseñas previas";
            // 
            // chkDisallowPersonal
            // 
            this.chkDisallowPersonal.AutoSize = true;
            this.chkDisallowPersonal.Location = new System.Drawing.Point(12, 116);
            this.chkDisallowPersonal.Name = "chkDisallowPersonal";
            this.chkDisallowPersonal.Size = new System.Drawing.Size(180, 19);
            this.chkDisallowPersonal.Text = "Prohibir uso de datos personales";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(276, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(356, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            // 
            // AdminConfigForm
            // 
            // add checkboxes into groupbox
            this.grpRules.Controls.Add(this.chkUpperLower);
            this.grpRules.Controls.Add(this.chkDigits);
            this.grpRules.Controls.Add(this.chkSpecial);
            this.grpRules.Controls.Add(this.chkDisallowPrev);
            this.grpRules.Controls.Add(this.chkDisallowPersonal);

            this.ClientSize = new System.Drawing.Size(480, 265);
            this.Controls.Add(this.lblMinLength);
            this.Controls.Add(this.numMinLength);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.numQuestions);
            this.Controls.Add(this.grpRules);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminConfigForm";
            this.Text = "Configuración del sistema";
            this.StartPosition = FormStartPosition.CenterParent;
            this.grpRules.ResumeLayout(false);
            this.grpRules.PerformLayout();
            ((ISupportInitialize)(this.numMinLength)).EndInit();
            ((ISupportInitialize)(this.numQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
