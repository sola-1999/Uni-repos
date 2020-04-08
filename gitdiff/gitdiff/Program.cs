using System;
using System.IO;

namespace gitdiff
{
    class Program
    {
        static void Main(string[] args)
        {

            //Used to stores files as array

            string[] file1;
            string[] file2;

            bool difference;

            string test1 = "3a.txt";
            string test2 = "3b.txt";
            //Checks if the given arguments are valid inputs
            if (args.Length != 2 || args == null)
            {
                Console.WriteLine("Invalid input, retry command with correct input (gitdiff file1.txt file2.txt)");

            }
            else
            {
                
                //Checks if files exist
                fileCheck check1 = new fileCheck(args[0]);
                fileCheck check2 = new fileCheck(args[1]);

                //Stores files as arrays
                file1 = File.ReadAllLines(args[0]);
                file2 = File.ReadAllLines(args[1]);



                //Sets up a git object
                diff git = new diff(file1, file2, args[0] ,args[1]);

                //Checks for differences in the files
                difference = git.GitDiff();

                if (difference == true)
                {
                    //Lets the user know the files are different
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("files {0} and {1} are different",args[0], args[1]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    //Lets the user know the files are the same
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("These files are the same");
                    Console.ForegroundColor = ConsoleColor.White;

                }

            }
        }
    }
}
