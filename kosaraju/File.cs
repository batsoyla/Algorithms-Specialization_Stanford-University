using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace kosaraju
{
    class File
    {
        #region Fields
        String path;
        #endregion

        #region Constructor
        public File(String path)
        {
            this.path = path;
        }
        #endregion

# region Properties

        public String Path
        {
            get { return path; }
        }

        #endregion

        #region Methods

        public List<String> OpenFileMethod()
        {

            List<String> ListText = new List<String>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ListText.Add(line); // Add to list.

                }
            }
            return ListText;
        }
        #endregion
    }

}
