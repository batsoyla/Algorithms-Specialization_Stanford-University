using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra_s_shortest_path_algorithm
{
    class Helper
    {
        #region Flields
        String input;
        #endregion

        #region Properties
        public string Input  // property
        {
            get { return input; }   // get method
            set { input = value; }  // set method
        }
        #endregion


        #region Constructor
        public Helper(string input)
        {
            this.input = input;
        }
        #endregion

        #region Methods
        public String[]  ReadFile()
        {
            string[] lines = System.IO.File.ReadAllLines(this.input);
            return lines;
        }


        #endregion  
    }
}
