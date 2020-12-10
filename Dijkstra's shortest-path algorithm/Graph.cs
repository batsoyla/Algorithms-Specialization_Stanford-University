using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dijkstra_s_shortest_path_algorithm
{
    class Graph
    {
        #region Fields
        LinkedList<Tuple<int, int>>[] adjacencyList;
        #endregion

        #region Constructor 
        // Constructor - creates an empty Adjacency List
        public Graph(int vertices)
        {

            adjacencyList = new LinkedList<Tuple<int, int>>[vertices];
           
            for (int i = 0; i < adjacencyList.Length; ++i)
            {
                adjacencyList[i] = new LinkedList<Tuple<int, int>>();
            }
        }
        #endregion
       

        #region Methods
        // Appends a new Edge to the linked list
        public void addEdgeAtEnd(int startVertex, int endVertex, int weight)
        {
            adjacencyList[startVertex].AddLast(new Tuple<int, int>(endVertex, weight));
            
        }

        //if GraphNode contains Edge
        public bool containsEdge(int Node, int Vertex)
        {
            foreach(Tuple<int, int> input in adjacencyList[Node])
            {
                if (input.Item1 == Vertex )
                { 
                    return true;
                }
               
            }
            return false;

        }
        //returns size of Graph
        public int getNumberOfVertices()
        {
            return adjacencyList.Length;
        }
         public int getdist(int startVertex, int endVertex)
        {
            foreach(Tuple<int, int> node in adjacencyList[startVertex])
            {
                if(node.Item1 == endVertex)
                { 
                   return node.Item2;
                }
                
            }
            return -1;
        }

        // Prints the Adjacency List
        public void printAdjacencyList()
        {
            int i = 0;

            foreach (LinkedList<Tuple<int, int>> list in adjacencyList)
            {
                Console.Write("adjacencyList[" + (i+1) + "] -> ");

                foreach (Tuple<int, int> edge in list)
                {
                    Console.Write((edge.Item1 + 1) + "(" + edge.Item2 + ")");
                }

                ++i;
                Console.WriteLine();
            }
        }

        void printWholeSolution(int[] dist, int n)
        {
            Console.Write("\nVertex     Distance "
                          + "from Source\n");
            for (int i = 0; i < adjacencyList.Length; i++)
                Console.Write((i +1) + " \t\t " + dist[i] + "\n");
        }

        void printSolution(int[] dist, int n)
        {
            Console.Write("Distance from Source\n");
            List<int> results = new List<int>() { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 };
            foreach (int result in results)
            {
                Console.Write(" \t " + dist[result-1] + ",");
            }
        }
        public LinkedList<Tuple<int, int>> this[int index]
        {
            get
            {
                LinkedList<Tuple<int, int>> edgeList
                               = new LinkedList<Tuple<int, int>>(adjacencyList[index]);

                return edgeList;
            }
        }

        public int minDistance(int[] dist,
                   ArrayList sptSet)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < adjacencyList.Length; v++)
                if (sptSet.Contains(v)  && dist[v] <= min)
                {
                    
                    min = dist[v];
                    min_index = v;
                   
                }
           
            return min_index;
        }

        public void Dijkstra(int src)
        {
            
            int[] dist = new int[adjacencyList.Length]; // The output array. dist[i] 
                                                        // will hold the shortest 
                                                        // distance from src to i 

            // unvisited will true if vertex 
            // i is not included in shortest path 
            // tree or shortest distance from 
            // src to i is finalized 
            ArrayList unvisited = new ArrayList();
                
            // Initialize all distances as 
            // INFINITE and stpSet[] as false 
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                dist[i] = int.MaxValue;
                unvisited.Add(i);
            }

            // Distance of source vertex 
            // from itself is always 0 
            dist[src] = 0;
            
       while(unvisited.Count>0)
            {
                // Pick the minimum distance vertex 
                // from the set of vertices not yet 
                // processed. u is always equal to 
                // src in first iteration. 
                int u = minDistance(dist, unvisited);
                
                //take ta node out of unvisited list
                unvisited.Remove(u);

                for (int i=0; i<adjacencyList.Length;i++)
                { if (!unvisited.Contains(i))
                    {
                        
                        foreach (Tuple<int, int> node in adjacencyList[i])
                        {
                            if (unvisited.Contains(node.Item1) && (dist[i]+node.Item2 )<=dist[node.Item1])
                            {
                                
                                dist[node.Item1] = dist[i] + node.Item2;
                               
                            }

                        }
                    }
                        
                            
                 }
               
            }


            printSolution(dist, adjacencyList.Length);



        }
        #endregion

    }
}
