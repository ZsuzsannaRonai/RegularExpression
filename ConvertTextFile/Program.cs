using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new StreamReader(@"C:\Users\ronai\Documents\module .NET\Regular_expression\.gitignore.txt");
            var changedFile = new StreamWriter(@"C:\Users\ronai\Documents\module .NET\Regular_expression\.gitignore_utf.txt", false, Encoding.UTF7);
            changedFile.Write(file.ReadToEnd());
            changedFile.Close();
            file.Close();
        }
    }
}
