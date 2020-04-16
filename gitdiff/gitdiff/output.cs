using System;
using System.Collections.Generic;
using System.Text;

namespace gitdiff
{
    class output : diff
    {
        private List<string> OutputString { get; set; }
     
        //creates object using parents contructor
        public output(string[] file1, string[] file2, string fileName1, string fileName2)
            :base(file1, file2, fileName1, fileName2)
        {

        }

        public void GetOutput(int f1, int f2, List<string> line1, List<string> line2)
        {

            
            
            x = f1;
            k = f2;
            i = x - 1;
            file1words = line1;
            file2words = line2;
            OutputString = new List<string>();
            Console.WriteLine("x = {0}, k = {1}", x, k);

            while (i <= x + 1)
            {
                OutputString.Add(line2[i]);
                i++;
            }


        }


        public void Printer(int f1, int f2, int ln)
        {
            x = f1;
            k = f2;
            lineNumber = ln;
            //Tests which file has additional text

            if (k < x)
            {
                Console.WriteLine("Line : {0}", lineNumber);
                Console.Write(" - {0} ",OutputString[0]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0} ", OutputString[1]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0} ", OutputString[2]);
            }

            else
            {
                Console.WriteLine("Line : {0}", lineNumber);
                Console.Write(" + {0} ", OutputString[0]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0} ", OutputString[1]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}", OutputString[2]);
            }
            Console.WriteLine(" ");
        }


    }
}
