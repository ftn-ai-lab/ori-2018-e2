using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrgovackiPutnik
{
    public class Populacija
    {
        public static int velicinaPopulacije = 100;
        
        public Jedinka[] jedinke;
        
        public Populacija(){
            jedinke = new Jedinka[velicinaPopulacije];
            for (int i = 0; i < velicinaPopulacije; i++)
            {
                jedinke[i] = new Jedinka();
            }
        }

        public void pocetnaPopulacija(){
            Random rnd = new Random(DateTime.Now.Millisecond);
            for(int i=0; i<velicinaPopulacije; i++){
                jedinke[i].permutacija(rnd);
            }
        }

        public double sumaOcena(Gradovi g) {
            double retVal = 0;
            //TODO 1: Dopuniti metodu
            foreach (Jedinka j in jedinke)
            {
                retVal += j.fitness(g);
            }
            return retVal;
        }

        public int maxOcena(Gradovi g) {
            int retVal = 0;
            double max = Double.MinValue;
            //TODO 2: Naci indeks jedinke sa najboljim fitnesom
            for (int i = 0; i < jedinke.Length; i++)
            {
                double f = jedinke[i].fitness(g);
                if (f > max)
                {
                    max = f;
                    retVal = i;
                }
            }
            return retVal;
        }

        Random rnd = new Random();
        public int selekcija(Gradovi g, double suma)
        {
            int retVal = 0;
            double t = suma * rnd.NextDouble();
            double s = 0.0;
            double sp = 0.0;
            //TODO 4 : Dopuniti operaciju selekcije
            for (int i = 0; i < Gradovi.cBrojGradova; i++)
            {
                sp += jedinke[i].fitness(g);
                if (sp <= t && t <= s)
                {
                    retVal = i;
                    break;
                }
                sp = s;
            }
            return retVal;
        }

        public void mutacija(double k, Jedinka j)
        {
            //TODO 3: Implementirati operaciju mutacije
            for (int i = 0; i < Gradovi.cBrojGradova; i++)
            {
                double prag = rnd.NextDouble();
                if (prag < k)
                {
                    int pos = (int)(Gradovi.cBrojGradova * rnd.NextDouble());
                    int tmp = j.hromozomi[i];
                    j.hromozomi[i] = j.hromozomi[pos];
                    j.hromozomi[pos] = tmp;
                }
            }
        }

        public void ukrstanje(Jedinka roditelj1, Jedinka roditelj2, double k, Jedinka dete1, Jedinka dete2)
        {
            int prag = (int)(Gradovi.cBrojGradova * rnd.NextDouble());
            int[] ht1 = new int[Gradovi.cBrojGradova];
            int[] ht2 = new int[Gradovi.cBrojGradova];
            for (int i = 0; i < Gradovi.cBrojGradova; i++)
            {
                ht1[i] = 0;
                ht2[i] = 0;
            }
            for (int i = 0; i < prag; i++)
            {
                //TODO 5: Prebaciti vrednosti hromozoma i oznaciti koji su to prebaceni hromozomi
                dete1.hromozomi[i] = roditelj1.hromozomi[i];
                ht1[roditelj1.hromozomi[i]] = 1;
                dete2.hromozomi[i] = roditelj2.hromozomi[i];
                ht2[roditelj2.hromozomi[i]] = 1;

            }

            //TODO 6: Dopuniti ukrstanje za preostali deo dece
            for (int i = prag; i < Gradovi.cBrojGradova; i++)
            {
                // za prvo dete ostatak trazi u drugom roditelju
                for (int j = 0; j < Gradovi.cBrojGradova; j++)
                {
                    int x = (i + j) % Gradovi.cBrojGradova;
                    if (ht1[roditelj2.hromozomi[x]]==0)
                    {
                        dete1.hromozomi[i] = roditelj2.hromozomi[x];
                    }
                }
                // za drugo dete ostatak trazi u prvom roditelju
                for (int j = 0; j < Gradovi.cBrojGradova; j++)
                {
                    int x = (i + j) % Gradovi.cBrojGradova;
                    if (ht2[roditelj1.hromozomi[x]] == 0)
                    {
                        dete2.hromozomi[i] = roditelj1.hromozomi[x];
                    }
                }
            }// for preostali deo dece
        }
    }
}
