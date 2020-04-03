using System;
using System.Collections.Generic;
using System.Text;

namespace gitdiff
{
    class diff
    {
        //Stores files
        private string[] ofile { get; set; }
        private string[] sfile { get; set; }
        
        //Stores difference boolean
        private bool different { get; set; } = false; 



        public diff(string[] file1, string[] file2)
        {
            //Intialises object
            ofile = file1;
            sfile = file2;

        }

        public bool GitDiff()
        {

                for (int i = 0; i < ofile.Length; i++)
                {
                    

                    //Checks if each element in the file is the same
                    if (ofile[i] != sfile[i])
                    {
                    return different = true;
                    }
                    else
                    {
                        different = false;
                    }
                }
  
            //returns difference value to the progra
            return different;
        }
    }
}
