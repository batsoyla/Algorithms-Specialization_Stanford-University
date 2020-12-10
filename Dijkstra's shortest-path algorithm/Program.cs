using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Collections.Generic;

namespace Dijkstra_s_shortest_path_algorithm
{
    class Program
    {
        static void Main(string[] args)
        { //0pen .txt file and read from it 
            Helper txt = new Helper("C:\\Users\\Vasiliki\\Desktop\\coursera algorithms\\algorithms coursera\\week2\\info.txt");
            String[] lines = txt.ReadFile();
            
            
            //build new graph
            Graph adjacencyList = new Graph(lines.Length);
            foreach (String line in lines)
            {
                
                String[] results = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                
                int StartVertex = Int32.Parse(results[0]);
                foreach (String result in results)
                {
                   
                    if (result.Contains(","))
                    {
                        String[] input = result.Split(',');
                        int EndVertex = Int32.Parse(input[0]);
                        int Weight = Int32.Parse(input[1]);
                        adjacencyList.addEdgeAtEnd(StartVertex-1, EndVertex-1, Weight);

                    }
                   
                }
            }
            adjacencyList.Dijkstra(0);

        }
    }
}
