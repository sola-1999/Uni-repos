using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace gitdiff
{
    class log
    {
        //Stores names of the file
        private string f1name { get; set; }
        private string f2name { get; set; };
        public log(string f1, string f2)
        {
            //Takes file name parameters and stores them
            f1name = f1;
            f2name = f2;

            //Opens log file and appends a new log
            using (StreamWriter addEntry = File.AppendText("logfile,txt"))
            {

                addEntry.WriteLine("Testing files {0} and {1} for changes", f1name, f2name);
                addEntry.WriteLine("");
                addEntry.Close();
            }
        }

        public void entrylog(string entry1, string entry2, int ln)
        {
            //Adds a difference in the files to the log
            using (StreamWriter addEntry = File.AppendText("logfile,txt"))
            {
                
                addEntry.WriteLine("Line: {0}", ln);
                addEntry.WriteLine("{0} = {1}", f1name, entry1);
                addEntry.WriteLine("{0} = {1}", f1name, entry2);
                addEntry.WriteLine("");
                addEntry.Close();
            }
        }

        public void entrylog(string entry)
        {
            //Outputs the final comparion of the file to the log
            using (StreamWriter addEntry = File.AppendText("logfile,txt"))
            {
                
                addEntry.WriteLine("{0}", entry);
                addEntry.WriteLine("");
                addEntry.Close();
            }
        }
    }
}
