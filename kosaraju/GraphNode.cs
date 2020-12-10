using System;
using System.Collections.Generic;
using System.Text;

namespace kosaraju
{
    class GraphNode <T>
    {
        #region Fields         
        T value;

        //List<GraphNode<T>> neighbors;


        #endregion

        #region Constructor 
        ///<summary>
        /// Constructor
        ///</summary>
        ///
        public GraphNode(T value)
        {
            this.value = value;

        }
        #endregion

        #region Properties
        public T Value
        {
            get { return value; }
            set { value = value; }
        }

        public override bool Equals(object obj)
        {
            return obj is GraphNode<T> node &&
                   EqualityComparer<T>.Default.Equals(value, node.value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(value);
        }
    }

    #endregion

}

