using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalculator
{
    class LoadingFunction
    {
        public static void Operate()
            //Get all function and create a button for each with their symbol
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                Assembly dll = Assembly.LoadFile(path + @"\FunctionLibrary.dll");
                Type[] types = dll.GetExportedTypes();
                Console.WriteLine("length of type : " + types.Length);

                foreach(Type type in types)
                {
                    Console.WriteLine(type.Name);
                }
            }
            catch
            {
                Console.WriteLine("Could not get the dll file");
                Console.ReadKey();
            }
        }

    }
}
