using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace kosaraju
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            File myfile = new File("c:\\users\\vasiliki\\desktop\\coursera algorithms\\algorithms coursera\\kosaraju\\textfile\\probe3.txt");
            List<string> fileinfo = myfile.OpenFileMethod();
            Console.WriteLine("time to open file: " + stopwatch.ElapsedMilliseconds);
            
            stopwatch.Start();
            
            
            stopwatch.Stop();
            Console.WriteLine("time: " + stopwatch.ElapsedMilliseconds);
            Algoritms<int> MyAlgo = new Algoritms<int>();

            List<int> sccs = new List<int>();
            sccs = MyAlgo.CalculateTime2(fileinfo);

            foreach(int scc_length in sccs)
                    {
               Console.WriteLine(scc_length);
            }




        }
    }
}
