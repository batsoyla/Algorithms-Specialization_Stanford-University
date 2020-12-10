using System;
using System.Collections.Generic;
using System.Text;

namespace Median_Maintenance
{
    class MinHeap
    {
        #region Fields
        private readonly int[] _elements;
        private int _size;
        #endregion

        #region constructor 
        public MinHeap(int size)
        {
            _elements = new int[size];
        }

        #endregion


        #region Property
        public int Size
        {
            get { return _size; }

        }

        #endregion
        #region Methods 
        private int GetLeftChildIndex(int ElementIndex)
        {
            return (2 * ElementIndex + 1);
        }

        private int GetRightChildIndex(int ElementIndex)
        {
            return (2 * ElementIndex + 2);
        }

        private int GetParentIndex(int ElementIndex)
        {
            return ((ElementIndex - 1) / 2);
        }

        private bool HasLeftChild(int ElementIndex)
        {
            return GetLeftChildIndex(ElementIndex) < _size;
        }

        private bool HasRightChild(int ElementIndex)
        {
            return GetRightChildIndex(ElementIndex) < _size;
        }
        private bool IsRoot(int ElementIndex)
        {
            return ElementIndex == 0;
        }

        private int GetLeftChild(int ElementIndex)
        {
            return _elements[GetLeftChildIndex(ElementIndex)];
        }
        private int GetRightChild(int ElementIndex)
        {
            return _elements[GetRightChildIndex(ElementIndex)];
        }
        private int GetParent(int ElementIndex) 
        {
            return _elements[GetParentIndex(ElementIndex)];
            }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }
        public int Peek()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _elements[0];
        }
        public int Pop()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            ReCalculateDown();

            return result;
        }

        public void Add(int element)
        {
            if (_size == _elements.Length)
            {
                throw new IndexOutOfRangeException();
            }

            _elements[_size] = element;
            _size++;

            ReCalculateUp();
        }
        private void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex] >= _elements[index])
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        private void ReCalculateUp()
        {
            int index = _size - 1;
            while (!IsRoot(index) && _elements[index] < GetParent(index))
            {
                int parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
        public void printHeap()
        {
            Console.WriteLine("To MIN_heap einai");
            for (int i = 0; i < _size; i++)
            {
                Console.Write(" " + _elements[i] + ",");
                    }
            Console.WriteLine();
        }

        #endregion
    }



}
