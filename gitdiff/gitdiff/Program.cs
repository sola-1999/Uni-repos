using System;
using System.IO;

namespace gitdiff
{
    class Program
    {
        static void Main(string[] args)
        {
            //Takes two files as arguments
            string file1 = "";
            string file2 = "";

            //Checks if the given arguments are valid inputs
            if (args.Length != 2 || args == null)
            {
                Console.WriteLine("Invalid input, retry command with correct input (gitdiff file1.txt file2.txt)");

            }
            else
            {
                //Saves arguments as variables
                file1 = args[0];
                file2 = args[1];

                fileCheck check1 = new fileCheck(file1);
                fileCheck check2 = new fileCheck(file2);



            }
        }
    }
}
