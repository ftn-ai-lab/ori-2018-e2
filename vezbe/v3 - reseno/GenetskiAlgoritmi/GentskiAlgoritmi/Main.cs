using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GentskiAlgoritmi
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnKodiranje_Click(object sender, EventArgs e)
        {
            Kodiranje kodiranje = new Kodiranje();
            kodiranje.Show();
        }

        private void btnPopulacija_Click(object sender, EventArgs e)
        {
            Populacija populacija = new Populacija();
            populacija.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Selekcija selekcija = new Selekcija();
            selekcija.Show();
        }

        private void btnAlgoritam_Click(object sender, EventArgs e)
        {
            GenetskiAlgoritam ga = new GenetskiAlgoritam();
            double rX = ga.algoritam();
            double rY = GenetskiAlgoritam.funkcija(rX);
            label4.Text = "Resenje: f(" + rX.ToString("#0.000") + ")=" + rY.ToString("#0.000");
        }
    }
}
