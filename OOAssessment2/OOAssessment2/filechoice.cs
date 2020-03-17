using System;
using System.Collections.Generic;
using System.Text;

namespace OOAssessment2
{
    class filechoice
    {
        private List<Array> files { get; set; }//Stores arrays of files
        private int lenght { get; set; }//Stores lenght of the array

        public filechoice(List<Array> repos, int len)
        {
            files = repos;
            lenght = len;

        }

        public Array Choose()
        {
            Array file;//Sets an array to store the chosen file

                Console.WriteLine("Choose a text file to search (0 = 1a, 1 = 1b, 2 = 2a, 3 = 2b, 4 = 3a, 5 = 3b);");
                string SChoice = Console.ReadLine();
                int Choice = Convert.ToInt32(SChoice);//Takes a file choice from the user

                if (Choice >= 0 & Choice <= lenght)
                {
                    
                    file = files[Choice];
                    return file;//Returns the chosen file


                }
                else
                {
                    
                    Console.WriteLine("Invalid input");
                    return Choose();//Runs the method recusrsivly until valid input
                }
            
            
            

        }
    }
}
