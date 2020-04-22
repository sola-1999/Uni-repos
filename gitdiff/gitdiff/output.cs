using System;
using System.Collections.Generic;
using System.Text;
/*
 *Title      : gitdiff
 *Form       : output.cs
 *Use        : handles outputing to the command prompt
 *Creator    : Max Jameson
 *Student ID : 19702735
 */

namespace gitdiff
{
    class output : diff
    {
        //Stores the string to be output
        private List<string> OutputString { get; set; }

        //Stores string with differences in both files
        private string logString1 { get; set; }
        private string logString2 { get; set; }

        //Stores a log object
        private log logtofile { get; set; }

        //Stores final output
        private string result { get; set; }

        

        //creates object using parents contructor
        public output(string[] file1, string[] file2, string fileName1, string fileName2)
            : base(file1, file2, fileName1, fileName2)
        {
            //creates a log objects
            logtofile = new log(f1name, f2name);


        }

        public void GetOutput(int f1, int f2, List<string> line1, List<string> line2, int ln)
        {
            
            //Sets string position based on diff values
            x = f1;
            k = f2;
            lineNumber = ln;
            i = x - 1;
            file1words = line1;
            file2words = line2;

            OutputString = new List<string>();
            logString1 = "";
            logString2 = "";
            
            //Stores the string with the difference for both files
            while (i <= x + 1)
            {
                OutputString.Add(file2words[i]);
                logString1 = logString1 + file1words[i] + " ";
                logString2 = logString2 + file2words[i] + " ";
                i++;

            }

            //Runs method to update log
            logtofile.entrylog(logString1, logString2, lineNumber);

        }


        public void Printer(int f1, int f2, int ln)
        {
            //Sets string position based on diff values
            x = f1;
            k = f2;
            lineNumber = ln;


            //Tests which file has additional text
            if (k < x)
            {
                //Prints string with difference to the user
                Console.WriteLine("Line : {0}", lineNumber);
                Console.Write(" - {0} ", OutputString[0]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0} ", OutputString[1]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0} ", OutputString[2]);
            }

            else
            {
                //Prints string with difference to the user
                Console.WriteLine("Line : {0}", lineNumber);
                Console.Write(" + {0} ", OutputString[0]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0} ", OutputString[1]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}", OutputString[2]);
            }
            Console.WriteLine(" ");
        }

        public void Printer(bool diff)
        {

            if (diff == true)
            {
                //Lets the user know the files are different
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("files {0} and {1} are different", f1name, f2name);
                Console.ForegroundColor = ConsoleColor.White;
                result = "Files " + f1name + " and " + f2name + " are different";
                logtofile.entrylog(result);
            }
            else
            {
                //Lets the user know the files are the same
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Files {0} and {1} are the same", f1name, f2name);
                Console.ForegroundColor = ConsoleColor.White;
                result = "Files " + f1name + " and " + f2name + " are the same";
                logtofile.entrylog(result);


            }


        }

    }
}
