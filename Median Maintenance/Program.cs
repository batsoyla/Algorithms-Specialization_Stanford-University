using System;
using System.Collections.Generic;
namespace Median_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            List<int> Lists = new List<int>();


            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Vasiliki\Desktop\coursera algorithms\algorithms coursera\week3\input.txt");
            while ((line = file.ReadLine()) != null)
            {
                Lists.Add(Int32.Parse(line));

                counter++;
            }
            int[] numbers = new int[counter];
            int i = 0;
            foreach(int _line in Lists)
            {
                numbers[i] = _line;
               
                i++;
            }


            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            System.Console.WriteLine("There are {0} lines.", numbers.Length);
            int size = (numbers.Length / 2) + 1;
            // Suspend the screen.  
           
            MinHeap minHeap = new MinHeap(size);
            MaxHeap maxHeap = new MaxHeap(size);
            Median median_  = new Median();
            
            int m = 0;
            List<int> Medians = new List<int>();
            for ( i=0; i < numbers.Length; i++)
            {
                m = median_.getMedian(numbers[i], m, minHeap, maxHeap);
                Medians.Add(m);

                
            }
            int sum = 0;
            foreach(int _median in Medians )
            {
                
                sum += _median;

            }

            Console.WriteLine("Result:  " + (sum ));
            
        }
    }
}
