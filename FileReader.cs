using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace WallsStart
{
    internal class FileReader
    {
        private string fileName = "level_one.txt";
        private string pathAndFileName;

        public FileReader()
        {
            // TODO - Check if path is ok when game is built?
            string docPath = System.IO.Path.GetFullPath("../../../Content");
            pathAndFileName = Path.Combine(docPath, fileName);
            //Debug.WriteLine(pathAndFileName);
        }
        public string ReadFile()
        {
            try
            {
                using (var sr = new StreamReader(pathAndFileName))
                {
                    //Debug.Write(sr.ReadToEnd());
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                //Console.WriteLine(e.Message);
            }
            return null;
        }

    }
}