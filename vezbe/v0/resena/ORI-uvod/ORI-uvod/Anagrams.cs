using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORI_uvod
{
    public class Anagrams
    {   
        /// <summary>
        /// an example: Silent–>Listen, post–>opts.
        /// </summary>
        public void CheckAnagrams()
        {
            //Receive Words from User  
            Console.Write("Enter first word:");
            string word1 = Console.ReadLine();
            Console.Write("Enter second word:");
            string word2 = Console.ReadLine();

            //Add optional validation of input words if needed.  
            //.....  
            //TODO 2: - Anagram

            //step 1  - konvertuj reci da sadrze samo mala slova i prevori ih u niz
            char[] char1 = word1.ToLower().ToCharArray();
            char[] char2 = word2.ToLower().ToCharArray();

            //Step 2 - sortiraj nizove 
            Array.Sort(char1);
            Array.Sort(char2);
            //Step 3 - gradi nove reci od sortiranih nizova
            string NewWord1 = new string(char1);
            string NewWord2 = new string(char2);

            //Step 4  - uporedi nove reci
            if (NewWord1.Equals(NewWord2))
            {
                Console.WriteLine("Yes! Words \"{0}\" and \"{1}\" are Anagrams", word1, word2);
            }
            else
            {
                Console.WriteLine("No! Words \"{0}\" and \"{1}\" are not Anagrams", word1, word2);
            }

            //Hold Console screen alive to view the results.  
            Console.ReadLine();
        } 
    }
}
