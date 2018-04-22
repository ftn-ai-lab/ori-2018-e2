using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrgovackiPutnik
{
    public class GenetskiAlgoritam
    {
        // ------ konstante ---------
        public static int cBrojIteracija = 1000;
        public static double cUkrstanje = 0.5;
        public static double cMutacija = 0.02;

        public Gradovi gradovi = new Gradovi();
        Populacija roditelji = new Populacija();
        Populacija deca = new Populacija();
        public Jedinka najbolja = null;
        public int iteracija = 0;

        public void inicijalizacija(GradoviPanel panel) {
            Populacija roditelji = new Populacija();
            Populacija deca = new Populacija();
            roditelji.pocetnaPopulacija();
            iteracija = 0;
        }

        public void jednaIteracija(GradoviPanel panel) {
            iteracija++;
            //roditelji.print(g);
            double suma = roditelji.sumaOcena(gradovi);
            // na osnovu prethodne populacije kreiraj novu
            // elitizam
            int najbolji = roditelji.maxOcena(gradovi);
            Jedinka elitna = roditelji.jedinke[najbolji];
            najbolja = elitna;
            panel.resenje = najbolja;
            panel.Refresh();

            deca.jedinke[0] = new Jedinka(elitna);
            deca.jedinke[1] = new Jedinka(elitna);
            // ostali
            for (int i = 1; i < roditelji.jedinke.Length / 2; i++)
            {
                // selekcija roditelj1
                int roditelj1Int = roditelji.selekcija(gradovi, suma);
                // selekcija roditelj2
                int roditelj2Int = roditelji.selekcija(gradovi, suma);
                Jedinka A = new Jedinka(roditelji.jedinke[roditelj1Int]);
                Jedinka B = new Jedinka(roditelji.jedinke[roditelj2Int]);
                Jedinka a = new Jedinka(roditelji.jedinke[roditelj1Int]);
                Jedinka b = new Jedinka(roditelji.jedinke[roditelj2Int]);

                roditelji.ukrstanje(A, B, cUkrstanje, a, b);
                // mutacija dete1
                deca.mutacija(cMutacija, a);
                // mutacija dete2
                deca.mutacija(cMutacija, b);
                deca.jedinke[i * 2] = a;
                deca.jedinke[i * 2 + 1] = b;

            }
            roditelji = deca;
            deca = new Populacija();
        }

        
        public Jedinka genetskiAlgoritam(GradoviPanel panel)
        {
            inicijalizacija(panel);
            for (int it = 0; it < cBrojIteracija; it++)
            {
                jednaIteracija(panel);
            }
            return najbolja;
        }

    }
}
