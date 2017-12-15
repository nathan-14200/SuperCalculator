using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalculator
{
    class Loading
    {
        public static List<string> FromTextFile()
        {
            List<string> loadedHistoric = new List<string>();
            try
            {
                string path = Directory.GetCurrentDirectory();
                using (StreamReader sr = new StreamReader(path + @"\historic.txt"))
                {
                    string line;

                    while((line = sr.ReadLine()) != null)
                    {
                        loadedHistoric.Add(line);
                    }
                }
                return loadedHistoric;
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not load historic\r\n" + e.Message);
                return loadedHistoric;
            }
        }
    }
}
