namespace GentskiAlgoritmi
{
    partial class Selekcija
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
            this.btnPopulacija = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSelekcija = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMaxX = new System.Windows.Forms.TextBox();
            this.tbMinX = new System.Windows.Forms.TextBox();
            this.populacijaPanel1 = new GentskiAlgoritmi.PopulacijaPanel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPopulacija
            // 
            this.btnPopulacija.Location = new System.Drawing.Point(225, 313);
            this.btnPopulacija.Name = "btnPopulacija";
            this.btnPopulacija.Size = new System.Drawing.Size(142, 38);
            this.btnPopulacija.TabIndex = 21;
            this.btnPopulacija.Text = "Kreiraj populaciju";
            this.btnPopulacija.UseVisualStyleBackColor = true;
            this.btnPopulacija.Click += new System.EventHandler(this.btnPopulacija_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Hromozomi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Redni broj";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(701, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBar
            // 
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSelekcija
            // 
            this.btnSelekcija.Location = new System.Drawing.Point(564, 313);
            this.btnSelekcija.Name = "btnSelekcija";
            this.btnSelekcija.Size = new System.Drawing.Size(125, 38);
            this.btnSelekcija.TabIndex = 23;
            this.btnSelekcija.Text = "Selekcija";
            this.btnSelekcija.UseVisualStyleBackColor = true;
            this.btnSelekcija.Click += new System.EventHandler(this.btnSelekcija_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "MAX_X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "MIN_X";
            // 
            // tbMaxX
            // 
            this.tbMaxX.Location = new System.Drawing.Point(119, 330);
            this.tbMaxX.Name = "tbMaxX";
            this.tbMaxX.Size = new System.Drawing.Size(100, 22);
            this.tbMaxX.TabIndex = 25;
            this.tbMaxX.Text = "100";
            // 
            // tbMinX
            // 
            this.tbMinX.Location = new System.Drawing.Point(13, 330);
            this.tbMinX.Name = "tbMinX";
            this.tbMinX.Size = new System.Drawing.Size(100, 22);
            this.tbMinX.TabIndex = 24;
            this.tbMinX.Text = "0";
            // 
            // populacijaPanel1
            // 
            this.populacijaPanel1.Location = new System.Drawing.Point(10, 29);
            this.populacijaPanel1.Name = "populacijaPanel1";
            this.populacijaPanel1.Size = new System.Drawing.Size(679, 278);
            this.populacijaPanel1.TabIndex = 16;
            // 
            // Selekcija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 376);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbMaxX);
            this.Controls.Add(this.tbMinX);
            this.Controls.Add(this.btnSelekcija);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPopulacija);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.populacijaPanel1);
            this.Name = "Selekcija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selekcija";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPopulacija;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private PopulacijaPanel populacijaPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBar;
        private System.Windows.Forms.Button btnSelekcija;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMaxX;
        private System.Windows.Forms.TextBox tbMinX;
    }
}