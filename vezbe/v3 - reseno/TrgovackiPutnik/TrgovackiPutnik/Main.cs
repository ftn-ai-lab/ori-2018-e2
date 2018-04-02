using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrgovackiPutnik
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        GenetskiAlgoritam ga = new GenetskiAlgoritam();
        private void btnAlgoritam_Click(object sender, EventArgs e)
        {
            Console.WriteLine("-------------------------");
            Jedinka resenje = ga.genetskiAlgoritam(gradoviPanel1);
            lblOcena.Text = "Ocena:" + ga.najbolja.fitness(ga.gradovi);
            gradoviPanel1.resenje = resenje;
            gradoviPanel1.Refresh();
        }

        private void btnInicijalizacija_Click(object sender, EventArgs e)
        {
            ga = new GenetskiAlgoritam();
            ga.inicijalizacija(gradoviPanel1);
            btnIteracija_Click(null, null);
        }

        private void btnIteracija_Click(object sender, EventArgs e)
        {
            ga.jednaIteracija(gradoviPanel1);
            lblIteracija.Text = "Itaracija:" + ga.iteracija;
            lblOcena.Text = "Ocena:" + ga.najbolja.fitness(ga.gradovi);
        }
    }
}
