using System;
using System.Collections.Generic;
using System.Text;

namespace gitdiff
{
    class diff
    {
        private string[] ofile { get; set; }
        private string[] sfile { get; set; }//Stores files
        private bool different { get; set; } = false; //Stores difference boolean



        public diff(string[] file1, string[] file2)
        {
            ofile = file1;
            sfile = file2;//Intialises object

        }

        public bool GitDiff()
        {
            if (ofile.Length != sfile.Length)//Checks if the files are the same size
            {
                different = false;
            }
            else
            {

                for (int i = 0; i < ofile.Length; i++)
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
