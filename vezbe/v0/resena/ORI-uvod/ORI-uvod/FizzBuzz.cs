using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORI_uvod
{
    public class FizzBuzz
    {
        public static string GetFizzBuzz()
        {
            string fbString = "";
            // TODO 4: -Implementirati FizzBuzz algoritam
            for (int i = 1; i < 101; i++)
            {
                
                if (i % 3 == 0)
                    fbString += "Fizz";
                if (i % 5 == 0)
                    fbString += "Buzz";
                if (i % 3 != 0 && i % 5 != 0)
                    fbString += i.ToString();             

                fbString += Environment.NewLine;
            }

            return fbString;
        }
    }
}
