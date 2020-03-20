using System;
using System.Collections.Generic;
using System.Text;

namespace OOAssessment2
{
    class filechoice
    {
      
        private List<string[]> files { get; set; }//Stores array of files
        private int lenght { get; set; }//Stores lenght of the array

        public filechoice(List<string[]> repos, int len)
        {
            files = repos;
            lenght = len;//Initialises object

        }

        public string[] Choose()
        {
            

                Console.WriteLine("Choose a text file to search (0 = 1a, 1 = 1b, 2 = 2a, 3 = 2b, 4 = 3a, 5 = 3b);");
                string SChoice = Console.ReadLine();
                int Choice = Convert.ToInt32(SChoice);//Takes a file choice from the user

                if (Choice >= 0 & Choice <= lenght)
                {
                    
                    string[] file = files[Choice];
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
