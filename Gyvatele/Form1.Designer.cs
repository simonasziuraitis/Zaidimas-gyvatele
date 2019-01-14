namespace Gyvatele
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbZaidimoLaukas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRezultatas = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblZaidimoPabaiga = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbZaidimoLaukas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbZaidimoLaukas
            // 
            this.pbZaidimoLaukas.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbZaidimoLaukas.Location = new System.Drawing.Point(11, 132);
            this.pbZaidimoLaukas.Name = "pbZaidimoLaukas";
            this.pbZaidimoLaukas.Size = new System.Drawing.Size(577, 425);
            this.pbZaidimoLaukas.TabIndex = 0;
            this.pbZaidimoLaukas.TabStop = false;
            this.pbZaidimoLaukas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbZaidimoLaukas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rezultatas:";
            // 
            // lblRezultatas
            // 
            this.lblRezultatas.AutoSize = true;
            this.lblRezultatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRezultatas.Location = new System.Drawing.Point(319, 35);
            this.lblRezultatas.Name = "lblRezultatas";
            this.lblRezultatas.Size = new System.Drawing.Size(51, 55);
            this.lblRezultatas.TabIndex = 2;
            this.lblRezultatas.Text = "0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            // 
            // lblZaidimoPabaiga
            // 
            this.lblZaidimoPabaiga.AutoSize = true;
            this.lblZaidimoPabaiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZaidimoPabaiga.Location = new System.Drawing.Point(25, 173);
            this.lblZaidimoPabaiga.Name = "lblZaidimoPabaiga";
            this.lblZaidimoPabaiga.Size = new System.Drawing.Size(102, 37);
            this.lblZaidimoPabaiga.TabIndex = 3;
            this.lblZaidimoPabaiga.Text = "label2";
            this.lblZaidimoPabaiga.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 603);
            this.Controls.Add(this.lblZaidimoPabaiga);
            this.Controls.Add(this.lblRezultatas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbZaidimoLaukas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbZaidimoLaukas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbZaidimoLaukas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRezultatas;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblZaidimoPabaiga;
    }
}

