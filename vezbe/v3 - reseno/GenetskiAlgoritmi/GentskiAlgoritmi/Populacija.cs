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
    public partial class Populacija : Form
    {
        public Populacija()
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
                    ukupno += ocenaP;
                    populacija[i].ocenaP = ocenaP/100.0;
                    //Debug.WriteLine("Za X : " + populacija[i].x + ", ocena je : " + populacija[i].ocena + " i ocenaP je " + populacija[i].ocenaP);
                }

                populacijaPanel1.populacija = populacija;
                populacijaPanel1.Refresh();
            }
            catch (Exception ex)
            {
                statusBar.Text = "Greška!";
            }
        }

        private void populacijaPanel1_Load(object sender, EventArgs e)
        {

        }

    }
}
