using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORI_uvod
{
    class Program
    {
        static void Main(string[] args)
        {
            Duplicate duplicate = new Duplicate();
            Anagrams anagrams = new Anagrams();
            Palindromes palindromes = new Palindromes();

            Console.WriteLine("############## duplicates ############");
            //duplicate.CheckDuplicates();
            Console.WriteLine("############# Anagrams ############");
            //anagrams.CheckAnagrams();
            Console.WriteLine("############# Palindromes ##########");
            //palindromes.CheckPalindromes();
            Console.WriteLine("############# FizzBuzz ##############");
            //Console.WriteLine(FizzBuzz.GetFizzBuzzL());
            Console.WriteLine("############# Lambda izrazi ##############");
            LambdaIzrazi.Primeri();
            Console.Read();
        }
    }
}
