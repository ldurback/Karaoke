using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Diagnostics;

namespace MP3Parser
{
    public class Main
    {
        public void ParseDirectoryRecursively(string rootDirectory)
        {
            foreach (string path in Directory.EnumerateFiles(rootDirectory, "*.mp3", SearchOption.AllDirectories))
            {
                TagLib.Mpeg.File tagFile = null;

                try
                {
                    tagFile = (TagLib.Mpeg.File)TagLib.File.Create(path);

                    if (tagFile == null)
                        throw new Exception("Opening file returned null");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(path + " cannot be opened.  Ignoring.  Exception had message: " + e.Message);
                    continue;
                }
            }
        }
    }
}
