using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace gitdiff
{
    class fileCheck
    {
        //Stores test file
        private string Testfile { get; set; }
        
        //Stores file names
        private string file1 { get; set; }
        private string file2 { get; set; }

        //Store bool to check if they can be compared
        private bool same { get; set; }

        public fileCheck(string file)
        {
            //Saves the file to be tested
            Testfile = file;

            //Runs test method
            test();

        }

        private void test()
        {
            //Attempts to read the file to see if it exists+
            try
            {
             File.ReadAllText(Testfile);

            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File {0} not found: {1} ", Testfile, e.Message );
                

            }
        }

        public bool CheckSame(string f1, string f2)
        {
            //checks if the two files have the same name
            if (f1[0] == f2[0])
            {
                same = true;
            }
            else
            {
                same = false;
            }
            return same;
        }
    }
}
