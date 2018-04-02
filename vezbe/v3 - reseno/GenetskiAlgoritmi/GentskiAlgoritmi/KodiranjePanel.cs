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

    public delegate void ActionEventHandler(Jedinka jedinka, double xNovo);

    public partial class KodiranjePanel : UserControl
    {
        public KodiranjePanel()
        {
            InitializeComponent();
            jedinka = new Jedinka(35, 0, 100);
        }

        public Jedinka jedinka = null;

        float x0 = 0;
        float xM = 0;
        float y0 = 0;
        float yM = 0;        
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            double maxX = jedinka.MAX_X;
            double minX = jedinka.MIN_X;
            double x = jedinka.x;

            Graphics gr = e.Graphics;
            gr.FillRectangle(Brushes.White, this.ClientRectangle);

            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;

            Font f = new Font(FontFamily.GenericSerif, 8);
            SizeF sf = gr.MeasureString("65535", f);

            x0 = 2 + sf.Width;
            xM = width - sf.Width;
            y0 = height - sf.Height - 4;
            yM = sf.Height + 2;

            // y koordinatna osa
            gr.DrawString("65535", f, Brushes.Black, 2, yM-sf.Height/2);

            sf = gr.MeasureString("0", f);
            gr.DrawString("0", f, Brushes.Black, x0-sf.Width-2, y0 - sf.Height / 2);
            Color c = Color.FromArgb(100, Color.Gray);
            // horizontalne linije
            gr.DrawLine(new Pen(c), x0-2, yM, xM + 2, yM);
            gr.DrawLine(new Pen(c), x0-2, y0, xM + 2, y0);
            // vertikalne linije
            gr.DrawLine(new Pen(c), x0, yM - 2, x0, y0+2);
            gr.DrawLine(new Pen(c), xM, yM - 2, xM, y0 + 2);
            
            // x koordinatna osa
            String minXS = "" + minX.ToString("#0.00");
            sf = gr.MeasureString(minXS, f);
            gr.DrawString(minXS, f, Brushes.Black, 2 + x0-sf.Width/2, y0 + 2);

            String maxXS = "" + maxX.ToString("#0.00");
            sf = gr.MeasureString(maxXS, f);
            gr.DrawString(maxXS, f, Brushes.Black, xM - sf.Width / 2, y0 + 2);

            // funkcija
            gr.DrawLine(new Pen(Brushes.Blue, 2), x0, y0, xM, yM);
            
            // nacrtati X
            double a = (xM - x0)/(maxX-minX);
            double b = x0-a*minX;
            float xKoordinate = (float)(a * x + b);
            String xS = "" + x.ToString("#0.00");
            sf = gr.MeasureString(xS, f);
            gr.DrawString(xS, f, Brushes.Black, xKoordinate - sf.Width / 2, y0 + 2);
            gr.DrawLine(new Pen(c), xKoordinate, yM - 2, xKoordinate, y0 + 2);
            
            // nacrtati Y
            int yInt = jedinka.convert_double2int(jedinka.x);

            double aY = (yM - y0) / 65535;
            double bY = y0;
            float yKoordinate = (float)(aY * yInt + bY);
            String yS = "" + yInt;
            sf = gr.MeasureString(yS, f);
            gr.DrawString(yS, f, Brushes.Black, x0-sf.Width-2, yKoordinate-sf.Height/2);
            gr.DrawLine(new Pen(c), x0-2, yKoordinate, xM+2, yKoordinate);
        }

        public event ActionEventHandler JedinkaPromenjena;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int eX = e.X;
            int eY = e.Y;
            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;

            double maxX = jedinka.MAX_X;
            double minX = jedinka.MIN_X;
            double x = jedinka.x;

            double a = (xM - x0) / (maxX - minX);
            double b = x0 - a * minX;
            double xNovo = (eX-b)/a;
            jedinka.x = xNovo;
            this.Refresh();
            if (JedinkaPromenjena != null)
                JedinkaPromenjena(jedinka, xNovo);

        }


    }
}
