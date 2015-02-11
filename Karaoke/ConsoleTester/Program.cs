using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            MP3Parser.Parser.ParseDirectoryRecursively("C:\\Users\\Luke\\Music\\Karaoke Collection 2014 Vol 3 Reupload By ROFFE");
        }
    }
}
