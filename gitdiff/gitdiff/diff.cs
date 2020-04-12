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
        private int k { get; set; }

        //Stores temporary values
        private int temp { get; set; }

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
                        
                        //Runs jump method
                        Jump(file1words, file2words);
                        

                        Console.WriteLine("line: {0} ", lineNumber);
                        string output = "";

                        //Tests which file has additional text
                        if (k > x)
                        {
                            //Loops through line to construct different string
                            temp = x - 1;
                            while (temp != k)
                            {
                                
                                output = output + " " + file2words[temp];
                               
                                temp++;
                            }
                            
                            Console.WriteLine(" + {0}", output);
                        }

                        else if (k < x)
                        {
                            temp = k - 1;
                            while (temp != x)
                            {

                                output = output + " " + file1words[temp];
                                
                                temp++;
                            }
                            
                            Console.WriteLine(" + {0}", output);
                        }

                        else if (k == x)
                        {
                            temp = k - 2;
                            while(temp != x + 1)
                            {
                                output = output + " " + file2words[temp];
                                temp++;
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
