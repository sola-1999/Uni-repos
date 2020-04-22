using System;
using System.Collections.Generic;
using System.Text;
/*
 *Title      : gitdiff
 *Form       : diff.cs
 *Use        : finds difference between two files
 *Creator    : Max Jameson
 *Student ID : 19702735
 */


namespace gitdiff
{
    class diff
    {
        //Stores files
        public string[] ofile { get; set; }
        public string[] sfile { get; set; }
        public string f1name { get; set; }
        public string f2name { get; set; }

        //Stores line number
        public int lineNumber;

        //Stores values to loop through array
        public int x { get; set; }
        public int i { get; set; }
        public int k { get; set; }

        //Stores temporary values
        public int temp { get; set; }

        //Stores difference boolean
        public bool different { get; set; } = false;

        //Stores current line in list
        public List<string> file1words { get; set; }
        public List<string> file2words { get; set; }




        public diff(string[] file1, string[] file2, string fileName1, string fileName2)
        {
            //Intialises object
            ofile = file1;
            sfile = file2;
            f1name = fileName1;
            f2name = fileName2;


        }

        public void GitDiff()
        {
            i = 0;

            //Creates an object to handle the programs outputs
            output printer = new output(ofile, sfile, f1name, f2name);


            //Loops through file arrays
            while (i < ofile.Length && i < sfile.Length)
            {
                lineNumber = i;
                //stores each enity as a list of strings
                x = 0;
                k = 0;
                string words1 = ofile[i];
                string words2 = sfile[i];
                file1words = new List<string>(words1.Split(" "));
                file2words = new List<string>(words2.Split(" "));

                //Increments through the list of strings 
                while(x < file1words.Count && k < file2words.Count)
                {
                    
                    //Checks if the currents selected words are the same
                    if (file1words[x] == file2words[k])
                    {
                        //Checks if a difference has already been found
                        if (different == true)
                        {

                        }
                        else
                        {
                            //Detects no differences in the program
                            different = false;
                        }
                    }
                    //Ouput difference
                    else
                    {

                        //Runs method to store the different part of the string
                        printer.GetOutput(x, k, file1words, file2words, lineNumber);
                        
                        //Runs jump method
                        Jump(file1words, file2words);

                        //Runs a method to print the difference
                        printer.Printer(x, k, lineNumber);
                        
                        
                        Console.WriteLine(" ");
                        different = true;
                    }
                    x++;
                    k++;
                }
                i++;
            }

            //Rims the print method to tell the user if the files are different
            printer.Printer(different);
            
            
        }
        
        private void Jump(List<string> file1words, List<string> file2words)
        {
            bool found = false;

            temp = x;
            //Loops through line of first file
            while (temp < file1words.Count && found == false)
            {
                //Checks if temp is the same as file 2
                if (file1words[temp] == file2words[k])
                {
                    //sets file 1 counter to same words as file 2
                    found = true;
                    x = temp;
                }
                else if (file1words[temp] == file2words[k+1])
                {
                    found = true;
                    x = temp;

                    //Adjust position in file 1
                    k = k + 1;
                }
                temp++;
            }

            temp = k;
            //Loops through line of second file
            while (temp < file2words.Count && found == false)
            {
                //Checks if temp is the same as file 2
                if (file2words[temp] == file1words[x])
                {
                    //sets file 1 counter to same words as file 1
                    found = true;
                    k = temp;
                }
                else if (file2words[temp] == file1words[x+1])
                {
                    found = true;
                    k = temp;

                    //Adjusts positon in file 2
                    x = x + 1;
                }
                temp++;
            }

        }

        
    }

    
}
