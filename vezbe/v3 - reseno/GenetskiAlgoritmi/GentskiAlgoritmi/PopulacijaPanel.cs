using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GentskiAlgoritmi
{
    public partial class PopulacijaPanel : UserControl
    {
        public PopulacijaPanel()
        {
            InitializeComponent();
            int brojVrsta = 10;
            populacija = new Jedinka[brojVrsta];
            Random rnd = new Random();
            double minX = 0;
            double maxX = 100;
            for (int i = 0; i < brojVrsta; i++)
            {
                double x = minX+(maxX-minX)*rnd.NextDouble();
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
            double b = -a*minOcena;
            double ukupno = 0;
            for (int i = 0; i < brojVrsta; i++)
            {
                double ocenaP = (float)(a * populacija[i].ocena + b);
                populacija[i].ocenaP = ocenaP/100.0;
                ukupno += populacija[i].ocenaP;
            }
            // procentualno
            //for (int i = 0; i < brojVrsta; i++)
            //{
            //    double ocenaP = populacija[i].ocenaP / ukupno ;
            //    populacija[i].ocenaP = ocenaP;
            //}
        }

        public Jedinka[] populacija = null;
        public int mark1 = -2;
        public int mark2 = -2;

        protected override void OnPaint(PaintEventArgs e)
        {
            int brojKolona = Jedinka.MAXSTRING;
            int brojVrsta = populacija.Length;
            
            base.OnPaint(e);

            Graphics gr = e.Graphics;

            Rectangle rec = this.ClientRectangle;

            // nacrtaj grid
            int width = rec.Width;
            int height = rec.Height;
            int ukupanBrojKolona = 2 +// redni broj
                                    brojKolona +
                                    3 + // za x
                                    3 +  // za f(x)
                                    4; // za selekciju

            int dx = (int)(width / ukupanBrojKolona);
            int dy = (int)(height / brojVrsta);

            Rectangle rPanel = new Rectangle(0, 0, dx * ukupanBrojKolona, dy * brojVrsta);
            gr.FillRectangle(Brushes.White, rPanel);            

            for (int j = 0; j < brojKolona; j++)
            {
                Color c = Color.FromArgb(40, Color.Gray);
                int xx = dx * (j+2);
                // pomeri sve za dve kolone
                int y0 = 0;
                int yH = dy*brojVrsta;
                gr.DrawLine(new Pen(c), xx, y0, xx, yH);
            }
            for (int i = 0; i < brojVrsta+1; i++)
            {
                Color c = Color.FromArgb(100, Color.Blue);
                int yy = dy * i;
                int x0 = 0;
                int xH = dx*ukupanBrojKolona;
                gr.DrawLine(new Pen(c), x0, yy, xH, yy);
                if (i == mark1 || i == mark2) {
                    gr.DrawLine(Pens.Red, x0, yy, xH, yy);
                }
                if (i-1 == mark1 || i-1 == mark2)
                {
                    gr.DrawLine(Pens.Red, x0, yy, xH, yy);
                }
            }

            for (int i = 0; i < brojVrsta; i++)
            {
                Jedinka jedinka = populacija[i];
                // ispisi redni broj
                int xx = (int)(dx / 2) + dx * 0;
                int yy = (int)(dy / 2) + dy * i;

                Font f = new Font(FontFamily.GenericSerif, 8);
                SizeF sf = gr.MeasureString("" + i, f);
                Brush br = Brushes.Blue;
                if (i == mark1)
                {
                    br = Brushes.Red;
                }
                else if (i == mark2)
                {
                    br = Brushes.Yellow;
                }
                gr.DrawString("" + i, f, br, xx - sf.Width / 2, yy - sf.Height / 2);


                for (int j = 0; j < brojKolona; j++)
                {
                    Rectangle r = new Rectangle(dx * (j+2) + 2, dy * i + 2, dx - 4, dy - 4);
                    Color cc1 = Color.FromArgb(40, Color.White);
                    int tt = jedinka.chromosome[j];
                    if(tt == 1)
                        cc1 = Color.FromArgb(100, Color.Black);
                    gr.FillRectangle(new SolidBrush(cc1), r);

                    xx = (int)(dx / 2) + dx * (j+2);
                    yy = (int)(dy / 2) + dy * i;

                    sf = gr.MeasureString("" + tt, f);
                    if (i == mark1 || i == mark2)
                    {
                        gr.DrawString("" + tt, f, Brushes.Red, xx - sf.Width / 2, yy - sf.Height / 2);
                    }
                    else {
                        gr.DrawString("" + tt, f, Brushes.Black, xx - sf.Width / 2, yy - sf.Height / 2);
                    }

                }

                // ispisi x
                xx = (int)(dx / 2) + dx * (2+brojKolona+1);// + 1 je da bude u sredini grupe od 3 celije
                yy = (int)(dy / 2) + dy * i;

                f = new Font(FontFamily.GenericSerif, 8);
                String xS = "" + jedinka.x.ToString("#0.00");
                sf = gr.MeasureString(xS, f);
                gr.DrawString(xS, f, Brushes.Red, xx - sf.Width / 2, yy - sf.Height / 2);

                // ispisi ocenu
                xx = (int)(dx / 2) + dx * (2 + brojKolona + 3);// + 3 je da bude u sredini grupe od 3 celije
                yy = (int)(dy / 2) + dy * i;

                f = new Font(FontFamily.GenericSerif, 8);
                String yS = "" + jedinka.ocena.ToString("#0.00");
                sf = gr.MeasureString(yS, f);
                gr.DrawString(yS, f, Brushes.Red, xx - sf.Width / 2, yy - sf.Height / 2);
            
                // nacrtaj ocenuP
                xx = dx * (2 + brojKolona + 5);
                yy = dy * i+4;

                int sirinaOcene = (int)((dx * 5.0 - 5) * populacija[i].ocenaP);
                
                Rectangle ocenaPR = new Rectangle(xx, yy, sirinaOcene, dy-8);
                gr.FillRectangle(Brushes.Yellow, ocenaPR);

            }
        }



    }
}
