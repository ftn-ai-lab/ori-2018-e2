using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrgovackiPutnik
{
    public partial class GradoviPanel : UserControl
    {
        public GradoviPanel()
        {
            InitializeComponent();
            gradovi = new Gradovi();
            resenje = null;
        }

        public Gradovi gradovi;
        public Jedinka resenje;


        float x0 = 0;
        float xM = 0;
        float y0 = 0;
        float yM = 0;  
        public int brojVrsta = 25;
        public int brojKolona = 25;


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gr = e.Graphics;
            gr.FillRectangle(Brushes.White, this.ClientRectangle);

            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;

            x0 = 20;
            xM = width - 20;
            y0 = height - 20;
            yM = 20;

            float dx = (float)((xM - x0) / brojKolona);
            float dy = (float)((y0-yM) / brojVrsta);

            for (int j = 0; j < brojKolona+1; j++)
            {
                Color c = Color.FromArgb(40, Color.Gray);
                float xx = x0+dx * j;
                gr.DrawLine(new Pen(c), xx, y0, xx, yM);
                Font f = new Font(FontFamily.GenericSerif, 8);
                SizeF sf = gr.MeasureString("" + j, f);
                gr.DrawString("" + j, f, Brushes.Gray, xx - sf.Width / 2, y0 + 2);
            }
            for (int i = 0; i < brojVrsta+1; i++)
            {
                Color c = Color.FromArgb(40, Color.Gray);
                float yy = y0 - dy * i;
                gr.DrawLine(new Pen(c), x0, yy, xM, yy);
                Font f = new Font(FontFamily.GenericSerif, 8);
                SizeF sf = gr.MeasureString("" + i, f);
                gr.DrawString("" + i, f, Brushes.Gray, x0 - sf.Width-2, yy-sf.Height/2);
            }

            if (gradovi != null)
            {
                if (resenje != null) {
                    int n = resenje.hromozomi.Length;
                    for (int i = 0; i < n; i++) {
                        int sledeci = (i + 1) % n;
                        Grad g1 = gradovi.gradovi[resenje.hromozomi[i]];
                        Grad g2 = gradovi.gradovi[resenje.hromozomi[sledeci]];
                        float xx1 = (float)(x0 + dx * g1.x);
                        float yy1 = (float)(y0 - dy * g1.y);
                        float xx2 = (float)(x0 + dx * g2.x);
                        float yy2 = (float)(y0 - dy * g2.y);
                        gr.DrawLine(Pens.Blue, xx1, yy1, xx2, yy2);
                    }                
                }
                
                for (int i = 0; i < gradovi.gradovi.Length; i++)
                {
                    Font f = new Font(FontFamily.GenericSerif, 8);
                    SizeF sf = gr.MeasureString("" + i, f);
                    float xx = (float)(x0 + dx * gradovi.gradovi[i].x);
                    float yy = (float)(y0 - dy * gradovi.gradovi[i].y);
                    float r = Math.Max(sf.Width, sf.Height)+4;
                    Rectangle rEl = new Rectangle((int)(xx - r/2), (int)(yy - r/2), (int)(r), (int)(r));
                    gr.FillEllipse(Brushes.White, rEl);
                    gr.DrawEllipse(Pens.Green, rEl);
                    gr.DrawString("" + i, f, Brushes.Black, xx - sf.Width / 2, yy - sf.Height / 2);

                }
            }// if gradovi != null
        }
    }
}
