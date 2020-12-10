using System;
using System.IO;
using System.Collections.Generic;

namespace _2Sum
{
    class Program
    {
        static void Main(string[] args)
        {
           List<String> num = new List<String>();
            using (StreamReader sr = new StreamReader(@"C:\Users\Vasiliki\Desktop\coursera algorithms\algorithms coursera\week4\input.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    num.Add(line);
                }
            }
            Console.WriteLine(num.Count);
            HashSet<long> result = new HashSet<long>();
            twoSum Sum = new twoSum();
            result = Sum.TwoSum(num, -10000, 10000);
            Console.WriteLine(result.Count);

        }
    }
}
