using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORI_uvod
{
    public class Duplicate
    {
        public void CheckDuplicates()
        {
            string value1 = RemoveDuplicateChars("Csharpstar");
            string value2 = RemoveDuplicateChars("Google");
            string value3 = RemoveDuplicateChars("Yahoo");
            string value4 = RemoveDuplicateChars("CNN");
            string value5 = RemoveDuplicateChars("Line1\nLine2\nLine3");

            Console.WriteLine(value1);
            Console.WriteLine(value2);
            Console.WriteLine(value3);
            Console.WriteLine(value4);
            Console.WriteLine(value5);
        }

        static string RemoveDuplicateChars(string key)
        {
            // --- Removes duplicate chars using string concats. ---
         
            // Store the result in this string.
            string result = "";
            for (int i = 0; i < key.Length; i++)
            {
                if (result.IndexOf(key[i]) == -1)
                    result += key[i];
            }

            // TODO 1: Implementirati funkciju koja brise duple karaktere iz reci
            return result;
        }
    }
}
