using System;
using System.IO;
/*
 *Title      : gitdiff
 *Form       : Program.cs
 *Use        : runs gitdiff
 *Creator    : Max Jameson
 *Student ID : 19702735
 */

namespace gitdiff
{
    class Program
    {
        static void Main(string[] args)
        {

            //Used to stores files as array

            string[] file1;
            string[] file2;



            //Stores if the two files can be compared
            bool SameCheck;
            
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

                //Sets a bool on if the files can be compared
                SameCheck = check1.CheckSame(args[0], args[1]);

                //Stores files as arrays
                file1 = File.ReadAllLines(args[0]);
                file2 = File.ReadAllLines(args[1]);

                //Determines if the files can be compared
                if (SameCheck == true)
                {

                    //Sets up a git object
                    diff git = new diff(file1, file2, args[0], args[1]);

                    //Checks for differences in the files
                    git.GitDiff();

                }

                else
                {
                    Console.WriteLine("Files {0} and {1} are not comparable", args[0], args[1]);
                }

            }
        }
    }
}
