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
    public partial class JedinkaPanel : UserControl
    {
        public JedinkaPanel()
        {
            InitializeComponent();
            jedinka = new Jedinka(5, 0, 100);
        }

        public Jedinka jedinka = new Jedinka();
        public int redniBroj = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gr = e.Graphics;
            gr.FillRectangle(Brushes.White, this.ClientRectangle);

            Rectangle rec = this.ClientRectangle;

            int brojKolona = Jedinka.MAXSTRING;

            // nacrtaj grid
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / (
                2 +// redni broj
                brojKolona +
                3 + // za x
                3  // za f(x)
                ));
            int dy = (int)(height / 1);

            int xx;
            int yy;
            for (int j = 0; j < brojKolona; j++)
            {
                Color c = Color.FromArgb(40, Color.Gray);
                xx = dx * (j + 2);
                // pomeri sve za dve kolone
                int y0 = 0;
                int yH = height;
                gr.DrawLine(new Pen(c), xx, y0, xx, yH);
            }
            for (int i = 0; i < 1; i++)
            {
                Color c = Color.FromArgb(100, Color.Blue);
                yy = dy * i;
                int x0 = 0;
                int xH = width;
                gr.DrawLine(new Pen(c), x0, yy, xH, yy);
            }

            // ispisi redni broj
            xx = (int)(dx / 2) + dx * 0;
            yy = (int)(dy / 2) + dy * 0;

            Font f = new Font(FontFamily.GenericSerif, 8);
            SizeF sf = gr.MeasureString("" + redniBroj, f);
            gr.DrawString("" + redniBroj, f, Brushes.Red, xx - sf.Width / 2, yy - sf.Height / 2);

            for (int j = 0; j < brojKolona; j++)
            {
                Rectangle r = new Rectangle(dx * (j + 2) + 2, dy * 1 + 2, dx - 4, dy - 4);
                Color cc1 = Color.FromArgb(40, Color.White);
                int tt = jedinka.chromosome[j];
                if (tt == 1)
                    cc1 = Color.FromArgb(100, Color.Black);
                gr.FillRectangle(new SolidBrush(cc1), r);

                xx = (int)(dx / 2) + dx * (j + 2);
                yy = (int)(dy / 2) + dy * 0;

                sf = gr.MeasureString("" + tt, f);
                gr.DrawString("" + tt, f, Brushes.Black, xx - sf.Width / 2, yy - sf.Height / 2);
            }

            // ispisi x
            xx = (int)(dx / 2) + dx * (2 + brojKolona + 1);// + 1 je da bude u sredini grupe od 3 celije
            yy = (int)(dy / 2) + dy * 0;

            f = new Font(FontFamily.GenericSerif, 8);
            String xS = "" + jedinka.x.ToString("#0.00");
            sf = gr.MeasureString(xS, f);
            gr.DrawString(xS, f, Brushes.Red, xx - sf.Width / 2, yy - sf.Height / 2);

        }
    }
}
