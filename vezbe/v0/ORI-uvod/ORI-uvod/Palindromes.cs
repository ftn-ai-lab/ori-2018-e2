using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORI_uvod
{
    public class Palindromes
    {
        /// <summary>
        /// Determines whether the string is a palindrome.
        /// </summary>
        public bool IsPalindrome(string word)
        {
            // TODO 3 - Implementirati funkiciju koja proverava da li je rec palindrom
            return false;
        }

        public void CheckPalindromes()
        {
            string[] array =
             {
                 "civic",    
                 "deleveled",
                 "Hannah",
                 "kayak",
                 "level",
                 "examiron",
                 "racecar",
                 "radar",
                 "refer",
                 "reviver",
                 "easywcf",
                 "rotator",
                 "rotor",
                 "sagas",
                 "solos",   
                 "stats",
                 "tenet",
                 "Csharpstar"
             };

            foreach (string value in array)
            {
                Console.WriteLine("{0} = {1}", value, IsPalindrome(value));
            }
        }
    }
}
