using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace kosaraju
{
    class Algoritms<T>
    {


        public void FillOrder(GraphNode<int> node, HashSet<GraphNode<int>> visited, Stack<GraphNode<int>> stack, Graph<int> graph)
        {       if (!visited.Contains(node))
            {
                visited.Add(node);
                if (graph.MyGraph.ContainsKey(node))
                {

                    foreach (GraphNode<int> neighbor in graph.MyGraph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            FillOrder(neighbor, visited, stack, graph);

                        }
                    }
                }
                stack.Push(node);
            }
            
        }



        public void DfSUtil(GraphNode<int> node, HashSet<GraphNode<int>> visited, Graph<int> graph, int count )
        {
           
                visited.Add(node);
                count++;
                
                
                if (graph.MyGraph.ContainsKey(node))
                {
                    Console.WriteLine(count);

                    foreach (GraphNode<int> neighbor in graph.MyGraph[node])
                    {

                        if (!visited.Contains(neighbor))
                        {
                              DfSUtil(neighbor, visited, graph, count);
                            
                        }
                      
                    }

               
            }

        }
       


        public List<int> CalculateTime(List<String> fileinfo)
        {
            //create reverse graph
            Graph<int> graph= new Graph<int>();
            graph = graph.BuildReverseGraph(fileinfo);
            Stack<GraphNode<int>> stack = new Stack<GraphNode<int>>();
            stack = graph.CreateStack();

            int ft = 0;
            HashSet<GraphNode<int>> visited = new HashSet<GraphNode<int>>();
            Stack<GraphNode<int>> _stack = new Stack<GraphNode<int>>();
            while (stack.Count > 0)
            {
                GraphNode<int> node = stack.Pop();
                
                if (visited.Contains(node) )

                {                

                    continue;
                }
                else
                {

                    FillOrder(node,visited, _stack, graph);
                 }

            }
           
            //Delete graph 
            graph.DeleteGraph();
            //Empty hashset
            visited.Clear();
            HashSet<GraphNode<int>> visited_ = new HashSet<GraphNode<int>>();
            //create the original graph
            graph = graph.BuildGraph(fileinfo);
            List<int> mylist = new List<int>();
            //DFS for strongly connected components
            while(_stack.Count>0)
            {
                GraphNode<int> node = _stack.Pop();
              
                if (visited.Contains(node))

                {                    
                    continue;
                }
                else
                {
                    

                    int count = 0;
                    DfSUtil(node, visited_,graph,count);
                    Console.WriteLine("To count einai " + count);
                    mylist.Add(count);
 
                    mylist.Sort();

                    if (mylist.Count > 5)
                    {

                        mylist.RemoveRange(0, mylist.Count - 4);
                    }

                }
               

            }

            return mylist;
        }



        public List<int> CalculateTime2(List<String> fileinfo)
        {
            //create reverse graph
            Graph<int> graph = new Graph<int>();
           
            
            graph = graph.BuildReverseGraph(fileinfo);
            graph.CountEdges();
            //graph.GraphToString();
            Stack<GraphNode<int>> stack = new Stack<GraphNode<int>>();
            Stack<GraphNode<int>> Helper_stack = new Stack<GraphNode<int>>();
            Helper_stack = graph.CreateStack();
            Console.WriteLine("to stack pou dimiourgithike exei mikos " + Helper_stack.Count);

            HashSet<GraphNode<int>> visited = new HashSet<GraphNode<int>>();
            HashSet<GraphNode<int>> timed = new HashSet<GraphNode<int>>();
            Stack<GraphNode<int>> _stack = new Stack<GraphNode<int>>();
            while (Helper_stack.Count > 0)
            {
                GraphNode<int> Helper_node = Helper_stack.Pop();

                if (visited.Contains(Helper_node))
                {
                    continue;
                }
                else
                {
                   stack.Push(Helper_node);
                }

                while((stack.Count > 0))
                {
                    GraphNode<int> node = stack.Pop();
                    if (timed.Contains(node))
                    {
                            continue;
                    }
                    else
                    {
                        if(visited.Contains(node))
                        {
                            timed.Add(node);
                            _stack.Push(node);
                        }

                        else
                        {
                            stack.Push(node);
                            visited.Add(node);
                            if (graph.MyGraph.ContainsKey(node))
                            {

                                foreach (GraphNode<int> neighbor in graph.MyGraph[node])
                                {
                                    if (graph.MyGraph[node].Count > 0)
                                    {
                                        if (!visited.Contains(neighbor))
                                        { stack.Push(neighbor); }
                                    }
                                }
                            }
                        }

                    }
                    
                }

               
            }

           
            stack.Clear();
            //Delete graph 
            graph.DeleteGraph();
            //Empty hashset
            visited.Clear();
            timed.Clear();

            //create the original graph

            graph = graph.BuildGraph(fileinfo);

            List<int> list = new List<int>();
            List<int> result = new List<int>();
            //DFS for strongly connected components

            while (_stack.Count>0)
            {
                int count = 0;
                GraphNode<int> node = _stack.Pop();


                if (visited.Contains(node))
                {
                    continue;
                }
                else
                {
                    stack.Push(node);
                }

                    while (stack.Count > 0)
                    {
                        node = stack.Pop();
                      
                        if (timed.Contains(node))
                        {
                        continue;
                         }
                        if (visited.Contains(node))

                        {
                      
                        count++;
                        timed.Add(node);
                            //continue;
                        }
                        else
                        {
                            stack.Push(node);

                            visited.Add(node);
                            if (graph.MyGraph.ContainsKey(node))
                            {

                                foreach (GraphNode<int> neighbor in graph.MyGraph[node])
                                {
                                    if (!visited.Contains(neighbor))
                                        stack.Push(neighbor);
                                }
                            }
                        }

                    }


                result.Add(count);
                result=result.OrderByDescending(count=>count).ToList();

                if (result.Count>5)
                {
                    result.RemoveRange(5, result.Count - 5);
                }

                count = 0;

            }

            return result;
        }
    }
}
