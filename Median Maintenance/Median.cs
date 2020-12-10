using System;
using System.Collections.Generic;
using System.Text;

namespace Median_Maintenance
{
    class Median
    {
        int Average(int a, int b)
        {
            return (a + b) / 2;
        }
        public int getMedian(int Element, int Median,MinHeap minHeap, MaxHeap maxHeap)
        {
            int bal = areBalanced(minHeap, maxHeap);
            //Console.WriteLine("To Balance einai : " +bal);
            switch (bal)
            {
                case -1:// There are more elements in right (min) heap
                    {
                        if(Element < Median)// current element fits in right (min) heap 
                        {

                            //current element fits left Heap (maxHeap)
                            maxHeap.Add(Element);

                        }
                        else
                        {
                            
                            // insert into left heap 
                            maxHeap.Add(minHeap.Pop());

                            // current element fits in right (min) heap 
                            minHeap.Add(Element);

                        }
                        // Both heaps are balanced 
                        //Median = Average(minHeap.Peek(), maxHeap.Peek());
                        Median = maxHeap.Peek();
                        break;
                    }

                case 0:// The left and right heaps contain same number of elements 
                    {
                        if(Element < Median)
                        {
                            maxHeap.Add(Element);
                            Median = maxHeap.Peek();
                        }
                        else
                        {
                            minHeap.Add(Element);
                            Median = minHeap.Peek();
                        }

                        break;
                    }

                case 1:// There are more elements in left(max) heap
                    {
                        if(Element < Median)
                        {
                            // Remove top element from left heap and 
                            // insert it into the right heap
                            minHeap.Add(maxHeap.Pop());
                            maxHeap.Add(Element);                              

                        }
                        else
                        {
                            minHeap.Add(Element);

                        }
                        // Both heaps are balanced 
                        Median = maxHeap.Peek();
                        break;
                    }
            }
            return Median;
        }

        public int areBalanced(MinHeap minHeap, MaxHeap maxHeap)
        {
            if (maxHeap.Size < minHeap.Size )
            {
                return -1;
            }
            else if (minHeap.Size == maxHeap.Size)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
