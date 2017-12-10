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


        public static List<string> Operate()
        //Get all function and create a button for each with their symbol
        {
            List<string> operation = new List<string>();
            List<char> acceptedKeys = new List<char>();

            for (int i = 0; i < 10; i++)
            {
                acceptedKeys.Add(Char.Parse(i.ToString()));
            }

            try
            {
                string path = Directory.GetCurrentDirectory();
                Assembly dll = Assembly.LoadFile(path + @"\FunctionLibrary.dll");
                Type[] types = dll.GetExportedTypes();
                Console.WriteLine("length of type : " + types.Length);

                foreach(Type type in types)
                {
                    Console.WriteLine(type.Name);
                    operation.Add(type.Name);

                    MemberInfo[] members = type.GetMembers(BindingFlags.Public |
                        BindingFlags.Instance | BindingFlags.InvokeMethod);

                    Console.WriteLine();
                    foreach(MemberInfo member in members)
                    {
                        Console.WriteLine(member.Name);
                    }

                    //object temp = Activator.CreateInstance(type);
                    //acceptedKeys.Add((char)type.InvokeMember("get_Symbol", BindingFlags.InvokeMethod, null, temp,null));

                }
                Console.WriteLine("Accepted Keys");
                foreach(char c in acceptedKeys)
                {
                    Console.WriteLine(c);
                }
                return operation;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Could not get the dll file");
                Console.ReadKey();
                return operation;
            }
        }
    }
}
