using System;
using System.Collections.Generic;

namespace OOAssessment2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool difference;
            string[] repo1a = System.IO.File.ReadAllLines("GitRepositories_1a.txt");
            string[] repo1b = System.IO.File.ReadAllLines("GitRepositories_1b.txt");
            string[] repo2a = System.IO.File.ReadAllLines("GitRepositories_2a.txt");
            string[] repo2b = System.IO.File.ReadAllLines("GitRepositories_2b.txt");
            string[] repo3a = System.IO.File.ReadAllLines("GitRepositories_3a.txt");
            string[] repo3b = System.IO.File.ReadAllLines("GitRepositories_3b.txt");//Pulls text files

            List<string[]> repos = new List<string[]> { repo1a, repo1b , repo2a , repo2b , repo3a , repo3b };//Creates a list to store the files
            int reposLen = repos.Count - 1;//Gets the length of the list
            

            filechoice files = new filechoice(repos, reposLen);//Creates an object which selects files
            string[] file1 = files.Choose();
            string[] file2 = files.Choose();//Runs method to choose files

            gitdiff git = new gitdiff(file1, file2);


            difference = git.diff();//Runs the git diff command 

            if(difference == true)
            {
                Console.WriteLine("files 1 and 2 are different");//Lets the user know the files are different

            }
            else
            {
                Console.WriteLine("These files are the same");//Lets the user know the files are the same
            }


        }
    }
}
