using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation
{
    partial class AdminConfigForm
    {
        private IContainer components = null;
        private NumericUpDown numMinLength;
        private NumericUpDown numQuestions;
        private CheckBox chkUpperLower;
        private CheckBox chkDigits;
        private CheckBox chkSpecial;
        private CheckBox chkDisallowPrev;
        private CheckBox chkDisallowPersonal;
        private Button btnSave;

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
            this.numMinLength = new NumericUpDown();
            this.numQuestions = new NumericUpDown();
            this.chkUpperLower = new CheckBox();
            this.chkDigits = new CheckBox();
            this.chkSpecial = new CheckBox();
            this.chkDisallowPrev = new CheckBox();
            this.chkDisallowPersonal = new CheckBox();
            this.btnSave = new Button();
            ((ISupportInitialize)(this.numMinLength)).BeginInit();
            ((ISupportInitialize)(this.numQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // numMinLength
            // 
            this.numMinLength.Location = new System.Drawing.Point(16, 16);
            this.numMinLength.Minimum = 1;
            this.numMinLength.Maximum = 128;
            this.numMinLength.Name = "numMinLength";
            this.numMinLength.Size = new System.Drawing.Size(120, 23);
            // 
            // numQuestions
            // 
            this.numQuestions.Location = new System.Drawing.Point(16, 56);
            this.numQuestions.Minimum = 0;
            this.numQuestions.Maximum = 10;
            this.numQuestions.Name = "numQuestions";
            this.numQuestions.Size = new System.Drawing.Size(120, 23);
            // 
            // chkUpperLower
            // 
            this.chkUpperLower.AutoSize = true;
            this.chkUpperLower.Location = new System.Drawing.Point(160, 18);
            this.chkUpperLower.Name = "chkUpperLower";
            this.chkUpperLower.Size = new System.Drawing.Size(145, 19);
            this.chkUpperLower.Text = "Requerir mayúsc/minúsc";
            // 
            // chkDigits
            // 
            this.chkDigits.AutoSize = true;
            this.chkDigits.Location = new System.Drawing.Point(160, 44);
            this.chkDigits.Name = "chkDigits";
            this.chkDigits.Size = new System.Drawing.Size(97, 19);
            this.chkDigits.Text = "Requerir dígitos";
            // 
            // chkSpecial
            // 
            this.chkSpecial.AutoSize = true;
            this.chkSpecial.Location = new System.Drawing.Point(160, 70);
            this.chkSpecial.Name = "chkSpecial";
            this.chkSpecial.Size = new System.Drawing.Size(126, 19);
            this.chkSpecial.Text = "Requerir especiales";
            // 
            // chkDisallowPrev
            // 
            this.chkDisallowPrev.AutoSize = true;
            this.chkDisallowPrev.Location = new System.Drawing.Point(16, 96);
            this.chkDisallowPrev.Name = "chkDisallowPrev";
            this.chkDisallowPrev.Size = new System.Drawing.Size(190, 19);
            this.chkDisallowPrev.Text = "No permitir contraseñas previas";
            // 
            // chkDisallowPersonal
            // 
            this.chkDisallowPersonal.AutoSize = true;
            this.chkDisallowPersonal.Location = new System.Drawing.Point(16, 122);
            this.chkDisallowPersonal.Name = "chkDisallowPersonal";
            this.chkDisallowPersonal.Size = new System.Drawing.Size(163, 19);
            this.chkDisallowPersonal.Text = "No permitir datos personales";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // AdminConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 210);
            this.Controls.Add(this.numMinLength);
            this.Controls.Add(this.numQuestions);
            this.Controls.Add(this.chkUpperLower);
            this.Controls.Add(this.chkDigits);
            this.Controls.Add(this.chkSpecial);
            this.Controls.Add(this.chkDisallowPrev);
            this.Controls.Add(this.chkDisallowPersonal);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminConfigForm";
            this.Text = "Configuración del sistema";
            ((ISupportInitialize)(this.numMinLength)).EndInit();
            ((ISupportInitialize)(this.numQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
