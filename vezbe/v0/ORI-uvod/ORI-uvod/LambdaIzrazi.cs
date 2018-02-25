using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORI_uvod
{
    public class LambdaIzrazi
    {
        /// <summary>
        /// https://www.dotnetperls.com/lambda
        /// </summary>
        public static void Primeri()
        {
            List<int> elements = new List<int>() { 10, 20, 31, 40, 55 };
            Console.WriteLine(string.Join(",", elements.ToArray()));
            // ... Find index of first odd element.
            int oddIndex = elements.FindIndex(x => x % 2 != 0);
            Console.WriteLine("First odd index: {0}, # {1}", oddIndex, elements[oddIndex]);
            double sumOdd = elements.Sum(x => (x % 2 != 0)? x: 0);
            Console.WriteLine("Odd sum: {0}", sumOdd);
            double evenSum = elements.Sum(x => (x % 2 == 0)? x: 0);
            Console.WriteLine("Even sum: {0}", evenSum);
            Console.WriteLine("Skiped: {0}", string.Join(",", elements.Skip(1)));
            Console.WriteLine("Take: {0}", string.Join(",", elements.Take(3)));
            List<int> squares = elements.Select(x => x * x).ToList();
            Console.WriteLine(string.Join(",", squares));
            List<int> oddSquares = elements.Select(x => x * x).Where(x => x % 2 != 0).ToList();
            Console.WriteLine(string.Join(",", oddSquares));

        }
    }
}
