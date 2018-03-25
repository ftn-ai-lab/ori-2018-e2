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
            return retVal;
        }

        public int maxOcena(Gradovi g) {
            int retVal = 0;
            //TODO 2: Naci indeks jedinke sa najboljim fitnesom

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

            return retVal;
        }

        public void mutacija(double k, Jedinka j)
        {
            //TODO 3: Implementirati operaciju mutacije
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
            }

            //TODO 6: Dopuniti ukrstanje za preostali deo dece
            for (int i = prag; i < Gradovi.cBrojGradova; i++)
            {
                // za prvo dete ostatak trazi u drugom roditelju
                for (int j = 0; j < Gradovi.cBrojGradova; j++)
                {
                    int x = (i + j) % Gradovi.cBrojGradova;
                }
                // za drugo dete ostatak trazi u prvom roditelju
                for (int j = 0; j < Gradovi.cBrojGradova; j++)
                {
                    int x = (i + j) % Gradovi.cBrojGradova;
                }
            }// for preostali deo dece
        }
    }
}
