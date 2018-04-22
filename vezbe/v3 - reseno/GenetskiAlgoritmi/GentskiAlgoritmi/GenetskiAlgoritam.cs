using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GentskiAlgoritmi
{
    class GenetskiAlgoritam
    {
        double MIN_X = 0;
	    double MAX_X = 10;
	    int elitizam = 1;// 0 nema elitizma 1 sa elitizmom

	    int broj_jedinki = 100;
	    int broj_iteracija = 1000;

        double prag_ukrstanja = 0.3;
        double prag_mutacije  = 0.02;

        double suma_ocena = 0.0;
        double max_ocena  = 0.0;
        int index_najboljeg = 0;
        double  resenjeX = 0.0;
    	
        Jedinka [] generacija;
	    Jedinka [] nova_generacija;

        public static double funkcija(double d)
        {
            return Math.Sin(d / 5) + 0.1 * Math.Cos(10 * d);
        }

        Random rand = new Random();
        int selekcija(Jedinka[] gen)
        {
            int retVal = 0;
	        double t = suma_ocena * rand.NextDouble();
	        double s = 0.0;
	        double sp = 0.0;
            //TODO 2 : Dopuniti operaciju selekcije
            for (int i = 0; i < gen.Length; i++)
            {
                s += gen[i].ocenaP;
                if (sp <= t && t <= s)
                {
                    retVal = i;
                    break;
                }
                sp = s;
            }
	        return retVal;
        }

        void ukrstanje(Jedinka jedinka1, Jedinka jedinka2, double prag) 
        {
	        //TODO 3: Implementirati operaciju ukrstanja
            for (int i = 0; i < Jedinka.MAXSTRING; i++)
            {
                double t = rand.NextDouble();
                if (t < prag)
                {
                    int tmp = jedinka1.chromosome[i];
                    jedinka1.chromosome[i] = jedinka2.chromosome[i];
                    jedinka2.chromosome[i] = tmp;
                }
            }
            jedinka1.x = jedinka1.bin2double(jedinka1.chromosome);
            jedinka2.x = jedinka2.bin2double(jedinka2.chromosome);
        }
   
        void mutacija(Jedinka jedinka, double prag) 
        {
	        //TODO 4: Implementirati operaciju mutacije
            for (int i = 0; i < Jedinka.MAXSTRING; i++)
            {
                double t = rand.NextDouble();
                if (t < prag)
                {
                    if (jedinka.chromosome[i] == 0)
                    {
                        jedinka.chromosome[i] = 1;
                    }
                    else
                    {
                        jedinka.chromosome[i] = 0;
                    }
                }
            }
	        jedinka.x = jedinka.bin2double(jedinka.chromosome);
        }

        public double algoritam() 
        {
	        // prva generacija
	        generacija = new Jedinka[broj_jedinki];
	        nova_generacija = new Jedinka[broj_jedinki];
	        for (int i = 0; i < broj_jedinki; i++) 
            {
                double xx = rand.NextDouble() * (MAX_X - MIN_X) + MIN_X;
		        generacija[i] = new Jedinka(xx, MIN_X, MAX_X);
	         }
	        //nove generacije
	        for (int j = 0; j < broj_iteracija; j++) 
            {
                max_ocena = funkcija(generacija[0].x);
                index_najboljeg = 0;
                for (int i = 0; i < broj_jedinki; i++)
                {
                    generacija[i].ocena = funkcija(generacija[i].x);
                    if (max_ocena < generacija[i].ocena)
                    {
                        max_ocena = generacija[i].ocena;
                        index_najboljeg = i;
                    }
                }
                // odrediti ocenuP
                double minOcena = generacija[0].ocena;
                double maxOcena = generacija[0].ocena;
                for (int i = 0; i < broj_jedinki; i++)
                {
                    minOcena = Math.Min(minOcena, generacija[i].ocena);
                    maxOcena = Math.Max(maxOcena, generacija[i].ocena);
                }
                // skaliranje minOcena = 0 maxOcena = 100
                double a = 100 / (maxOcena - minOcena);
                double b = -a * minOcena;
                double ukupno = 0;
                for (int i = 0; i < broj_jedinki; i++)
                {
                    double ocenaP = (float)(a * generacija[i].ocena + b);
                    generacija[i].ocenaP = ocenaP / 100.0;
                    ukupno += generacija[i].ocenaP;
                }
                suma_ocena = ukupno;
		        resenjeX = generacija[index_najboljeg].x;
		        int start = 0;

                if(elitizam == 1) {
                    nova_generacija[0] = new Jedinka(generacija[index_najboljeg]);
                    nova_generacija[1] = new Jedinka(generacija[index_najboljeg]);
    		        start = 1;
		        }
		        for (int i = start; i < broj_jedinki / 2; i++) { // sa elitizmom
			        int roditelj1 = selekcija(generacija);
			        int roditelj2 = selekcija(generacija);

                    Jedinka A = new Jedinka(generacija[roditelj1]);
                    Jedinka B = new Jedinka(generacija[roditelj2]);
                    ukrstanje(A, B, prag_ukrstanja);
                    mutacija(A, prag_mutacije);
                    mutacija(B, prag_mutacije);
			        nova_generacija[i * 2] = A;
			        nova_generacija[i * 2 + 1] = B;
		        }
		        for (int i = 0; i < broj_jedinki; i++) {
                    generacija[i] = nova_generacija[i];
		        }
	        }
	        return resenjeX;
        }   
    }
}
