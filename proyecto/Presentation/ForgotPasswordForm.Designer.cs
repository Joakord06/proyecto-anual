using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation
{
    partial class ForgotPasswordForm
    {
        private IContainer components = null;
        private TextBox txtUsername;
        private Button btnLoadQuestions;
        private Label lblQ1;
        private TextBox txtAnswer1;
        private TextBox txtAnswer2;
        private Button btnSubmitAnswers;

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
            this.txtUsername = new TextBox();
            this.btnLoadQuestions = new Button();
            this.lblQ1 = new Label();
            this.txtAnswer1 = new TextBox();
            this.txtAnswer2 = new TextBox();
            this.btnSubmitAnswers = new Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 23);
            // 
            // btnLoadQuestions
            // 
            this.btnLoadQuestions.Location = new System.Drawing.Point(220, 10);
            this.btnLoadQuestions.Name = "btnLoadQuestions";
            this.btnLoadQuestions.Size = new System.Drawing.Size(120, 26);
            this.btnLoadQuestions.Text = "Cargar preguntas";
            this.btnLoadQuestions.UseVisualStyleBackColor = true;
            this.btnLoadQuestions.Click += new EventHandler(this.btnLoadQuestions_Click);
            // 
            // lblQ1
            // 
            this.lblQ1.AutoSize = true;
            this.lblQ1.Location = new System.Drawing.Point(12, 50);
            this.lblQ1.Name = "lblQ1";
            this.lblQ1.Size = new System.Drawing.Size(0, 15);
            // 
            // txtAnswer1
            // 
            this.txtAnswer1.Location = new System.Drawing.Point(12, 70);
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.Size = new System.Drawing.Size(328, 23);
            // 
            // txtAnswer2
            // 
            this.txtAnswer2.Location = new System.Drawing.Point(12, 100);
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.Size = new System.Drawing.Size(328, 23);
            // 
            // btnSubmitAnswers
            // 
            this.btnSubmitAnswers.Location = new System.Drawing.Point(12, 140);
            this.btnSubmitAnswers.Name = "btnSubmitAnswers";
            this.btnSubmitAnswers.Size = new System.Drawing.Size(120, 30);
            this.btnSubmitAnswers.Text = "Enviar respuestas";
            this.btnSubmitAnswers.UseVisualStyleBackColor = true;
            this.btnSubmitAnswers.Click += new EventHandler(this.btnSubmitAnswers_Click);
            // 
            // ForgotPasswordForm
            // 
            this.ClientSize = new System.Drawing.Size(360, 190);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnLoadQuestions);
            this.Controls.Add(this.lblQ1);
            this.Controls.Add(this.txtAnswer1);
            this.Controls.Add(this.txtAnswer2);
            this.Controls.Add(this.btnSubmitAnswers);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ForgotPasswordForm";
            this.Text = "Recuperar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
