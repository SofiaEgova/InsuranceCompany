using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Services
{
    public class Logger
    {
        private string CurrentLogText;
        private static FileStream f1;
        private StreamWriter output;

        string path = @"d:\Repositories\VS\InsuranceCompany\Archive\log.txt";

        public Logger()
        {
            f1 = new FileStream(path, FileMode.Append);
            output = new StreamWriter(f1);
        }

        public void Log(string message)
        {
            CurrentLogText = message + ", Дата: " + DateTime.Now.ToString();
            output.WriteLine(CurrentLogText);
            f1.Flush();
            output.Flush();
        }
    }
}
