using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RestaurentAndFood.Classes
{
    public class Logger
    {
        public void writeFile(string path, string content, int lineNumber)
        {
            ErrorModel er = new ErrorModel
            {
                LineNumber = lineNumber > 0 ? lineNumber : 0,
                Date = DateTime.Now,
                ErrorMessage = content,
                FilePath = path
            };

            File.AppendAllText(path, "\n" + JsonConvert.SerializeObject(er));
            
        }

        public string[] readFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }

        public bool exists(string textFile)
        {

            if (File.Exists(textFile))
            {
                return true;
            }
            return false;
        }
    }
}