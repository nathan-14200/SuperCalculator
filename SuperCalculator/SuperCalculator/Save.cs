using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalculator
{
    class Save
    {
        public static string ToText(List<string> historic)
        {
            string path = Directory.GetCurrentDirectory();
            try
            {
                using (StreamWriter file = File.AppendText("historic.txt"))
                {
                    foreach(string line in historic)
                    {
                        file.WriteLine(line);
                    }

                    return "Successfully saved\r\n";
                }
            }
            catch
            {
                return "Error could not save\r\n";
            }
            
        }
    }
}
