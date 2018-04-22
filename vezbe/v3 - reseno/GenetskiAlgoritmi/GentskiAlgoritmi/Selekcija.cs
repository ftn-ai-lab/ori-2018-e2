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
    public partial class Selekcija : Form
    {
        public Selekcija()
        {
            InitializeComponent();
            btnPopulacija_Click(null, null);
        }

        private void btnPopulacija_Click(object sender, EventArgs e)
        {
            int brojVrsta = 10;
            Jedinka[] populacija = new Jedinka[brojVrsta];
            try
            {
                double maxX = Convert.ToDouble(tbMaxX.Text);
                double minX = Convert.ToDouble(tbMinX.Text);
                Random rnd = new Random();
                for (int i = 0; i < brojVrsta; i++)
                {
                    double x = minX + (maxX - minX) * rnd.NextDouble();
                    populacija[i] = new Jedinka(x, minX, maxX);
                    populacija[i].ocena = GenetskiAlgoritam.funkcija(x);
                }
                // odrediti ocenuP
                double minOcena = populacija[0].ocena;
                double maxOcena = populacija[0].ocena;
                for (int i = 0; i < brojVrsta; i++)
                {
                    minOcena = Math.Min(minOcena, populacija[i].ocena);
                    maxOcena = Math.Max(maxOcena, populacija[i].ocena);
                }
                // skaliranje minOcena = 0 maxOcena = 100
                double a = 100 / (maxOcena - minOcena);
                double b = -a * minOcena;
                double ukupno = 0;
                for (int i = 0; i < brojVrsta; i++)
                {
                    double ocenaP = (float)(a * populacija[i].ocena + b);
                    populacija[i].ocenaP = ocenaP / 100.0;
                    ukupno += populacija[i].ocenaP;
                }
                suma_ocena = ukupno;

                populacijaPanel1.populacija = populacija;
                populacijaPanel1.Refresh();
            }
            catch (Exception ex)
            {
                statusBar.Text = "Greška!";
            }
        }

        private void btnSelekcija_Click(object sender, EventArgs e)
        {
            int roditelj1 = selekcija(populacijaPanel1.populacija);
            int roditelj2 = selekcija(populacijaPanel1.populacija);
            populacijaPanel1.mark1 = roditelj1;
            populacijaPanel1.mark2 = roditelj2;
            populacijaPanel1.Refresh();
        }

        double suma_ocena = 0;
        Random rand = new Random();
        int selekcija(Jedinka[] gen)
        {
            int retVal = 0;
            double t = suma_ocena * rand.NextDouble();
            double s = 0.0;
            double sp = 0.0;
            for (int i = 0; i < populacijaPanel1.populacija.Length; i++)
            {
                sp = s;
                s += gen[i].ocenaP;
                if ((sp <= t) && (t < s))
                {
                    retVal = i;
                    break;
                }
            }
            return retVal;
        }



    }
}
