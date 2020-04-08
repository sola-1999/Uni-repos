using System;
using System.Collections.Generic;
using System.Text;


namespace gitdiff
{
    class diff
    {
        //Stores files
        private string[] ofile { get; set; }
        private string[] sfile { get; set; }

        //Stores line number
        private int lineNumber;

        //Stores values to loop through array
        private int x { get; set; }
        private int i { get; set; }
        private int j { get; set; }
        private int k { get; set; }

        //Stores difference boolean
        private bool different { get; set; } = false; 



        public diff(string[] file1, string[] file2, string fileName1, string fileName2)
        {
            //Intialises object
            ofile = file1;
            sfile = file2;
            x = 0;
            i = 0;
            k = 0;

        }

        public bool GitDiff()
        {

            //Loops through file arrays
            while (i < ofile.Length && i < sfile.Length)
            {
                lineNumber = i;
                //stores each enity as a list of strings
                x = 0;
                k = 0;
                string words1 = ofile[i];
                string words2 = sfile[i];
                List<string> file1words = new List<string>(words1.Split(" "));
                List<string> file2words = new List<string>(words2.Split(" "));

                //Increments through the list of strings 
                while(x < file1words.Count)
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
                        Console.WriteLine("Before jump {0} {1}", file1words[x], file2words[k]);
                        Console.WriteLine("before x = {0} k = {1}", x, k);
                        //Runs jump method
                        Jump(file1words, file2words);
                        Console.WriteLine("after jump {0} {1}", file1words[x], file2words[k]);
                        Console.WriteLine("after x = {0} k = {1}", x, k);

                        Console.WriteLine("line: {0} ", lineNumber);
                        string output = "";

                        //Tests which file has additional text
                        if (k > x)
                        {
                            //Loops through line to construct different string
                            j = x - 1;
                            while (j != k)
                            {
                                
                                output = output + "" + file2words[j];
                               
                                j++;
                            }
                            
                            Console.WriteLine(" + {0}", output);
                        }

                        else if (k < x)
                        {
                            j = k - 1;
                            while (j != x)
                            {

                                output = output + "" + file1words[j];
                                
                                j++;
                            }
                            
                            Console.WriteLine(" + {0}", output);
                        }
                        Console.WriteLine(" ");
                        different = true;
                    }
                    x++;
                    k++;
                }
                i++;
            }
  
            //returns difference value to the program
            return different;
        }
        
        private void Jump(List<string> file1words, List<string> file2words)
        {
            bool found = false;

            j = x;
            while (j < file1words.Count && found == false)
            {
                if (file1words[j] == file2words[k])
                {
                    found = true;
                    x = j;
                }
                else if (file1words[j] == file2words[k+1])
                {
                    found = true;
                    x = j;
                }
                j++;
            }

            j = k;
            while (j < file2words.Count && found == false)
            {
                if (file2words[j] == file1words[x])
                {
                    found = true;
                    k = j;
                }
                else if (file2words[j] == file1words[x+1])
                {
                    found = true;
                    k = j;
                }
                j++;
            }

        }

        
    }

    
}
