using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace gitdiff
{
    class fileCheck
    {
        private string Testfile { get; set; }

        public fileCheck(string file)
        {
            Testfile = file;
            test();

        }

        private void test()
        {
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
