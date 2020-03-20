using System;
using System.Collections.Generic;
using System.Text;

namespace OOAssessment2
{
    class gitdiff
    {
        private string[] ofile;
        private string[] sfile;
        private bool different = false;



        public gitdiff(string[] file1, string[] file2)
        {
            ofile = file1;
            sfile = file2;

        }

        public bool diff()
        {
            if (ofile.Length != sfile.Length)
            {
                different = false;
            }
            else
            {
                
                for (int i = 0; i < ofile.Length; i ++)
                {
                    if (ofile[i] != sfile[i])
                    {
                       return different = true;
                    }
                    else
                    {
                        different = false;
                    }
                }
            }
            return different;
        }
    }
}
