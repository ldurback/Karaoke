using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Diagnostics;

namespace MP3Parser
{
    static public class Parser
    {
        static public void ParseDirectoryRecursively(string rootDirectory)
        {
            foreach (string path in Directory.EnumerateFiles(rootDirectory, "*.mp3", SearchOption.AllDirectories))
            {
                TagLib.Mpeg.AudioFile file = null;

                try
                {
                    file = (TagLib.Mpeg.AudioFile)TagLib.File.Create(path);

                    if (file == null)
                        throw new Exception("Opening file returned null");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(path + " cannot be opened.  Ignoring.  Exception had message: " + e.Message);
                    continue;
                }

                Debug.WriteLine("Tags in file " + path + ": ");
                Debug.WriteLine(file.TagTypes);
            }
        }
    }
}
