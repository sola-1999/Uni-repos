using System;
using System.Collections.Generic;
using System.Text;

namespace OOAssessment2
{
    class gitdiff
    {
        private string[] ofile;
        private string[] sfile;//Stores files
        private bool different = false;//Stores difference boolean



        public gitdiff(string[] file1, string[] file2)
        {
            ofile = file1;
            sfile = file2;//Intialises object

        }

        public bool diff()
        {
            if (ofile.Length != sfile.Length)//Checks if the files are the same size
            {
                different = false;
            }
            else
            {
                
                for (int i = 0; i < ofile.Length; i ++)
                {
                    if (ofile[i] != sfile[i])//Checks if each element in the file is the same
                    {
                       return different = true;
                    }
                    else
                    {
                        different = false;
                    }
                }
            }
            return different;//returns difference value to the program
        }
    }
}
