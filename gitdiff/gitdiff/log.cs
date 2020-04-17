using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace gitdiff
{
    class log
    {
        private string f1name;
        private string f2name;
        public log(string f1, string f2)
        {
            f1name = f1;
            f2name = f2;
            using (StreamWriter addEntry = File.AppendText("logfile,txt"))
            {

                addEntry.WriteLine("Testing files {0} and {1} for changes", f1name, f2name);
                addEntry.WriteLine("");
                addEntry.Close();
            }
        }

        public void entrylog(string entry1, string entry2, int ln)
        {
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
            using (StreamWriter addEntry = File.AppendText("logfile,txt"))
            {
                
                addEntry.WriteLine("{0}", entry);
                addEntry.WriteLine("");
                addEntry.Close();
            }
        }
    }
}
