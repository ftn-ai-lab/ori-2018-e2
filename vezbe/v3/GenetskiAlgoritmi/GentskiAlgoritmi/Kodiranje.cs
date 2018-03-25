using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GentskiAlgoritmi
{
    public partial class Kodiranje : Form
    {

        private Jedinka jedinka = new Jedinka();
        Random rnd = new Random();
        
        public Kodiranje()
        {
            InitializeComponent();
            jedinka = new Jedinka(5, 0, 65535);
            jedinkaPanel1.jedinka = jedinka;
            jedinkaPanel1.Refresh();
            tbMaxInt.Text = ""+jedinka.MAX_INT;
            tbMaxString.Text = "" + Jedinka.MAXSTRING;
            tbMaxX.Text = "" + jedinka.MAX_X;
            tbMinX.Text = "" + jedinka.MIN_X;
            tbX.Text = "" + jedinka.x;
            kodiranjePanel1.jedinka = jedinka;
            kodiranjePanel1.Refresh();
        }

        private void btnKodiranje_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO 1: Dopuniti metodu
                jedinkaPanel1.Refresh();
                double dekodiranoX = jedinka.bin2double(jedinka.chromosome);
                tbDekodiranoX.Text = "" +dekodiranoX.ToString("#0.000");
                kodiranjePanel1.jedinka = jedinka;
                kodiranjePanel1.Refresh();
                statusBar.Text = "";
            }
            catch (Exception ex) {
                statusBar.Text = "Greška!";
            }
        }

        private void kodiranjePanel1_JedinkaPromenjena(Jedinka jedinka, double xNovo)
        {
            tbX.Text = "" + xNovo.ToString("#0.00");
            btnKodiranje_Click(null, null);
        }

    }
}
