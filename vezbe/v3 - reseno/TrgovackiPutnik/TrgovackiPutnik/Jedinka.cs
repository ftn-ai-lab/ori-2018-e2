using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrgovackiPutnik
{
    public class Jedinka
    {
        public int[] hromozomi;

        public Jedinka()
        {
            hromozomi = new int[Gradovi.cBrojGradova];
            for (int i = 0; i < Gradovi.cBrojGradova; i++)
                hromozomi[i] = i;
        }

        public Jedinka(Jedinka aJedinka) {
            hromozomi = new int[Gradovi.cBrojGradova];
            for (int i = 0; i < Gradovi.cBrojGradova; i++)
                hromozomi[i] = aJedinka.hromozomi[i];
        }

        public void permutacija(Random rnd)
        {
            for (int i = 0; i < Gradovi.cBrojGradova; i++)
            {
                int x = (int)(Gradovi.cBrojGradova * rnd.NextDouble());
                int y = (int)(Gradovi.cBrojGradova * rnd.NextDouble());
                int t = hromozomi[x];
                hromozomi[x] = hromozomi[y];
                hromozomi[y] = t;
            }
        }

        public double fitness(Gradovi g)
        {
            double ret = 0;
            for (int i = 0; i < Gradovi.cBrojGradova; i++)
            {
                int x = i;
                int y = (i + 1) % Gradovi.cBrojGradova;
                double d = g.rastojanje(hromozomi[x], hromozomi[y]);
                ret += d;
            }
            return Gradovi.maxRastojanje - ret;
        }

        public override string ToString()
        {
            String retVal = "";
            for (int i = 0; i < Gradovi.cBrojGradova; i++)
            {
                retVal += ","+hromozomi[i];
            }
            return retVal;
        }

    }
}
