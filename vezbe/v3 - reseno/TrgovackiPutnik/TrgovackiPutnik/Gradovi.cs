using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrgovackiPutnik
{
    public class Gradovi
    {
        public static int cBrojGradova = 10;
        public static double maxRastojanje = 100.0;
        
        public Grad[] gradovi;

        public Gradovi() {
            gradovi = new Grad[cBrojGradova];
            gradovi[0] = new Grad(5, 5);
            gradovi[1] = new Grad(10, 5);
            gradovi[4] = new Grad(4, 10);
            gradovi[3] = new Grad(8, 15);
            gradovi[2] = new Grad(5, 10);
            gradovi[5] = new Grad(8, 6);
            gradovi[6] = new Grad(15, 16);
            gradovi[7] = new Grad(8, 16);
            gradovi[8] = new Grad(18, 6);
            gradovi[9] = new Grad(3, 4);
        }

        public double rastojanje(int i, int j)
        {
            return Math.Sqrt(Math.Pow(gradovi[i].x - gradovi[j].x, 2) + Math.Pow(gradovi[i].y - gradovi[j].y, 2));
        }

    }
}
