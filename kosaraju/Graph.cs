using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace kosaraju
{
    class Graph<T>
    {
        #region Fields      

        Dictionary<GraphNode<T>, List<GraphNode<T>>> graph = new Dictionary<GraphNode<T>, List<GraphNode<T>>>();

        #endregion
        #region Constructor          
        /// <summary>         
        /// Constructor         
        /// </summary>         
        public Graph()
        {
        }
        #endregion

        public Dictionary<GraphNode<T>, List<GraphNode<T>>> MyGraph
        {
            get { return graph; }
            
        }

        #region Methods

        public bool graphContainsKey (GraphNode<T> node)
        {
            if (graph.ContainsKey(node))
            {
                return true;
            }
            return false;
        }


        public void AddToGraph(GraphNode<T> node1, GraphNode<T> node2)
        {

            
            if (graph.ContainsKey(node1) && graph.ContainsKey(node2))
            {
                if (!graph[node1].Contains(node2))
                {
                    //it means that the neighbors are not emty
                    graph[node1].Add(node2);

                }
            }
            else if(graph.ContainsKey(node1))
            {
                if (!graph.ContainsKey(node2))
                //create node 2 with empty list
                {
                    List<GraphNode<T>> listnodes = new List<GraphNode<T>>();
                    graph.Add(node2, listnodes);
                    //add node2 as neigbor
                    graph[node1].Add(node2);

                }

            }
            else if (graph.ContainsKey(node2))
            {
                if (!graph.ContainsKey(node1))
                //create node 2 with empty list
                {
                    List<GraphNode<T>> listnodes = new List<GraphNode<T>>();
                    listnodes.Add(node2);
                    graph.Add(node1, listnodes);
                }
            }

            else if(!graph.ContainsKey(node1))
                { if (!graph.ContainsKey(node2))
                {
                    List<GraphNode<T>> listnodes = new List<GraphNode<T>>();
                    List<GraphNode<T>> listnodes1 = new List<GraphNode<T>>();
                    listnodes.Add(node2);

                    try
                    {
                        graph[node1] = listnodes;
                        graph[node2] = listnodes1;
                    }
                    catch (System.FieldAccessException e)
                    {

                        Console.WriteLine(e);
                    }
                }
                }
            
        }




        public void GraphToString()
        {
            Console.Write("[key is: {0} -> Values :");
            foreach (GraphNode<T> value in   graph.Keys)
            {
                Console.Write("[key is: {0} -> Values :", value.Value);
                for (int i = 0; i < graph[value].Count; i++)
                {
                    Console.Write(" "+ graph[value][i].Value +" ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }
        public Graph<int> BuildGraph(List<String> graphInfo)
        {

            //Create a graph
            Graph<int> mygraph = new Graph<int>();
            //Continue to read until you reach end of file


            System.Collections.IList list = graphInfo;
            for (int i = 0; i < list.Count; i++)
            {
                string line = (string)list[i];
                String[] nodes = line.Split(" ");
                //Convert string to int
                GraphNode<int> node1 = new GraphNode<int>(Int32.Parse(nodes[0]));
                GraphNode<int> node2 = new GraphNode<int>(Int32.Parse(nodes[1]));
                mygraph.AddToGraph(node1, node2);
            }

            return mygraph;
        }


        public Graph<int> BuildReverseGraph(List<String> graphInfo)
        {

            //Create a graph
            Graph<int> mygraph = new Graph<int>();
            //Continue to read until you reach end of file


            System.Collections.IList list = graphInfo;
            for (int i = 0; i < list.Count; i++)
            {
                string line = (string)list[i];
                String[] nodes = line.Split(" ");
                //Convert string to int
                GraphNode<int> node1 = new GraphNode<int>(Int32.Parse(nodes[1]));
                GraphNode<int> node2 = new GraphNode<int>(Int32.Parse(nodes[0]));
                mygraph.AddToGraph(node1, node2);
            }

            return mygraph;
        }

        public override bool Equals(object obj)
        {
            return obj is Graph<T> graph &&
                   EqualityComparer<Dictionary<GraphNode<T>, List<GraphNode<T>>>>.Default.Equals(this.graph, graph.graph) &&
                   EqualityComparer<Dictionary<GraphNode<T>, List<GraphNode<T>>>>.Default.Equals(MyGraph, graph.MyGraph);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(graph, MyGraph);
        }
         
        public Stack<GraphNode<T>> CreateStack ()
        {
            List<T> list = new List<T>();
           Stack <GraphNode<T>> stack = new Stack<GraphNode<T>>();
            
         foreach (GraphNode<T> node in graph.Keys)
            {
                list.Add(node.Value);
            }

            list.Sort();
            foreach(T i in list)
            {
                GraphNode<T> node = new GraphNode<T>(i);
                stack.Push(node);
            }
            return stack;
        }

        public void DeleteGraph()
        {
            foreach (GraphNode<T> _key in graph.Keys)
            {
                graph.Remove(_key);
            }
        }



        public void CountEdges()
        {
            int count = 0;
       foreach(GraphNode<T> node in graph.Keys)
            {
                count += graph[node].Count;
            }
        }
            
            #endregion
    }
}
