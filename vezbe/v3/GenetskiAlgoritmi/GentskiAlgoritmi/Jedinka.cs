using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GentskiAlgoritmi
{
    public class Jedinka
    {
        public static int MAXSTRING = 16;
        public int MAX_INT;
        public double MIN_X;
        public double MAX_X;
        public double x;
        public int [] chromosome;
        public double ocena;
        public double ocenaP;

        public Jedinka()
        {
            MAX_INT = (int) Math.Pow(2, MAXSTRING) - 1;
            x = 0;
            chromosome = new int[MAXSTRING];
        }

        public Jedinka(double aMIN_X, double aMAX_X) 
        {
            MAX_INT = (int)Math.Pow(2, MAXSTRING) - 1;
	        MIN_X = aMIN_X;
	        MAX_X = aMAX_X;
	        x = MIN_X;
	        chromosome = int2bin((int)x);
        }

        public Jedinka(double newX, double aMIN_X, double aMAX_X) 
        {
            MAX_INT = (int)Math.Pow(2, MAXSTRING) - 1;
	        MIN_X = aMIN_X;
	        MAX_X = aMAX_X;
	        x = newX;
            chromosome = int2bin(convert_double2int(x));
        }

        public Jedinka(Jedinka jedinka)
        {
            MAX_INT = (int)Math.Pow(2, MAXSTRING) - 1;
            MIN_X = jedinka.MIN_X;
	        MAX_X = jedinka.MAX_X;
	        x = jedinka.x;
	        chromosome = int2bin((int)x);
        }

        int [] int2bin(int b)
        {
            int[] retVal = new int[MAXSTRING];
            for (int i = 0; i < MAXSTRING; i++)
            {
                int o = (int)b % 2;
                b = b / 2;
                retVal[i] = o;
            }
            return retVal;
        }
        
        public int convert_double2int(double aX)
        {
	        return (int)((aX-MIN_X)*MAX_INT/(MAX_X-MIN_X));
        }

        double convert_int2double(int a)
        {
	        return a*(MAX_X-MIN_X)/MAX_INT+MIN_X;
        }

        public double bin2double(int [] bin) {
            int ret = 0;
            int b = 1;
            for (int i = 0; i < MAXSTRING; i++)
            {
                ret += bin[i] * b;
                b = b * 2;
            }
            return convert_int2double(ret);
        }

        public override String ToString()
        {
            String retVal = "";
            for (int i = 0; i < MAXSTRING - 1; i++)
            {
                retVal += chromosome[i];
            }
            return retVal;
        }
    }
}
