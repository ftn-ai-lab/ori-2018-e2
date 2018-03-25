namespace TrgovackiPutnik
{
    partial class Main
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
            this.btnAlgoritam = new System.Windows.Forms.Button();
            this.btnInicijalizacija = new System.Windows.Forms.Button();
            this.btnIteracija = new System.Windows.Forms.Button();
            this.lblIteracija = new System.Windows.Forms.Label();
            this.gradoviPanel1 = new TrgovackiPutnik.GradoviPanel();
            this.lblOcena = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAlgoritam
            // 
            this.btnAlgoritam.Location = new System.Drawing.Point(421, 343);
            this.btnAlgoritam.Name = "btnAlgoritam";
            this.btnAlgoritam.Size = new System.Drawing.Size(120, 50);
            this.btnAlgoritam.TabIndex = 0;
            this.btnAlgoritam.Text = "Algoritam";
            this.btnAlgoritam.UseVisualStyleBackColor = true;
            this.btnAlgoritam.Click += new System.EventHandler(this.btnAlgoritam_Click);
            // 
            // btnInicijalizacija
            // 
            this.btnInicijalizacija.Location = new System.Drawing.Point(12, 343);
            this.btnInicijalizacija.Name = "btnInicijalizacija";
            this.btnInicijalizacija.Size = new System.Drawing.Size(120, 50);
            this.btnInicijalizacija.TabIndex = 2;
            this.btnInicijalizacija.Text = "Inicijalizacija";
            this.btnInicijalizacija.UseVisualStyleBackColor = true;
            this.btnInicijalizacija.Click += new System.EventHandler(this.btnInicijalizacija_Click);
            // 
            // btnIteracija
            // 
            this.btnIteracija.Location = new System.Drawing.Point(138, 343);
            this.btnIteracija.Name = "btnIteracija";
            this.btnIteracija.Size = new System.Drawing.Size(120, 50);
            this.btnIteracija.TabIndex = 3;
            this.btnIteracija.Text = "Jedna iteracija";
            this.btnIteracija.UseVisualStyleBackColor = true;
            this.btnIteracija.Click += new System.EventHandler(this.btnIteracija_Click);
            // 
            // lblIteracija
            // 
            this.lblIteracija.AutoSize = true;
            this.lblIteracija.Location = new System.Drawing.Point(274, 352);
            this.lblIteracija.Name = "lblIteracija";
            this.lblIteracija.Size = new System.Drawing.Size(53, 13);
            this.lblIteracija.TabIndex = 4;
            this.lblIteracija.Text = "Itaracija:0";
            // 
            // gradoviPanel1
            // 
            this.gradoviPanel1.Location = new System.Drawing.Point(9, 12);
            this.gradoviPanel1.Name = "gradoviPanel1";
            this.gradoviPanel1.Size = new System.Drawing.Size(532, 315);
            this.gradoviPanel1.TabIndex = 1;
            // 
            // lblOcena
            // 
            this.lblOcena.AutoSize = true;
            this.lblOcena.Location = new System.Drawing.Point(274, 380);
            this.lblOcena.Name = "lblOcena";
            this.lblOcena.Size = new System.Drawing.Size(42, 13);
            this.lblOcena.TabIndex = 5;
            this.lblOcena.Text = "Ocena:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 415);
            this.Controls.Add(this.lblOcena);
            this.Controls.Add(this.lblIteracija);
            this.Controls.Add(this.btnIteracija);
            this.Controls.Add(this.btnInicijalizacija);
            this.Controls.Add(this.gradoviPanel1);
            this.Controls.Add(this.btnAlgoritam);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAlgoritam;
        private GradoviPanel gradoviPanel1;
        private System.Windows.Forms.Button btnInicijalizacija;
        private System.Windows.Forms.Button btnIteracija;
        private System.Windows.Forms.Label lblIteracija;
        private System.Windows.Forms.Label lblOcena;
    }
}

