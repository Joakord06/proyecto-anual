using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    partial class FormPreguntasSeguridad
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblInfo;
        private Label lblQ1;
        private TextBox txtQ1;
        private Label lblA1;
        private TextBox txtA1;
        private Label lblQ2;
        private TextBox txtQ2;
        private Label lblA2;
        private TextBox txtA2;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblInfo = new Label();
            this.lblQ1 = new Label();
            this.txtQ1 = new TextBox();
            this.lblA1 = new Label();
            this.txtA1 = new TextBox();
            this.lblQ2 = new Label();
            this.txtQ2 = new TextBox();
            this.lblA2 = new Label();
            this.txtA2 = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.Text = "Preguntas de seguridad";
            this.ClientSize = new Size(520, 260);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            this.lblInfo.Text = "Configura tus preguntas de seguridad (serÃ¡n usadas para recuperar contraseÃ±a).";
            this.lblInfo.Location = new Point(12, 12);
            this.lblInfo.Size = new Size(496, 30);

            this.lblQ1.Text = "Pregunta 1:";
            this.lblQ1.Location = new Point(12, 54);
            this.txtQ1.Location = new Point(100, 50);
            this.txtQ1.Size = new Size(408, 23);

            this.lblA1.Text = "Respuesta 1:";
            this.lblA1.Location = new Point(12, 86);
            this.txtA1.Location = new Point(100, 82);
            this.txtA1.Size = new Size(408, 23);
            this.txtA1.UseSystemPasswordChar = true;

            this.lblQ2.Text = "Pregunta 2:";
            this.lblQ2.Location = new Point(12, 118);
            this.txtQ2.Location = new Point(100, 114);
            this.txtQ2.Size = new Size(408, 23);

            this.lblA2.Text = "Respuesta 2:";
            this.lblA2.Location = new Point(12, 150);
            this.txtA2.Location = new Point(100, 146);
            this.txtA2.Size = new Size(408, 23);
            this.txtA2.UseSystemPasswordChar = true;

            this.btnSave.Text = "Guardar";
            this.btnSave.Location = new Point(340, 200);
            this.btnSave.Size = new Size(80, 30);
            this.btnSave.Click += BtnSave_Click;

            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(428, 200);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.DialogResult = DialogResult.Cancel;

            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblQ1);
            this.Controls.Add(this.txtQ1);
            this.Controls.Add(this.lblA1);
            this.Controls.Add(this.txtA1);
            this.Controls.Add(this.lblQ2);
            this.Controls.Add(this.txtQ2);
            this.Controls.Add(this.lblA2);
            this.Controls.Add(this.txtA2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
        }
    }
}

