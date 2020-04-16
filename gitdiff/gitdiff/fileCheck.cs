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
    }
}
