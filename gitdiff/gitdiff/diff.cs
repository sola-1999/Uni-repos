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

        //Stores values to loop through array
        private int x { get; set; }
        private int i { get; set; }

        //Stores difference boolean
        private bool different { get; set; } = false; 



        public diff(string[] file1, string[] file2)
        {
            //Intialises object
            ofile = file1;
            sfile = file2;
            x = 0;
            i = 0;

        }

        public bool GitDiff()
        {

            //Loops through file arrays
            while (i < ofile.Length && i < sfile.Length)
            {
                //stores each enity as a list of strings
                x = 0;
                string words1 = ofile[i];
                string words2 = sfile[i];
                List<string> file1words = new List<string>(words1.Split(" "));
                List<string> file2words = new List<string>(words2.Split(" "));

                //Increments through the list of strings 
                while(x < file1words.Count)
                {
                    //Checks if the currents selected words are the same
                    if (file1words[x] == file2words[x])
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
                        Console.WriteLine("Difference found: ");
                        Console.WriteLine("First file: {0}", file1words[x]);
                        Console.WriteLine("Second file: {0}", file2words[x]);
                        return different = true;

                    }
                    x++;
                }
                i++;
            }
  
            //returns difference value to the program
            return different;
        }

        
    }

    
}
