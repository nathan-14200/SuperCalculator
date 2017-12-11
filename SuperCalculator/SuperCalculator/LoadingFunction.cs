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


        public static Tuple<List<string>, List<char>, List<string>> Operate(string path)
        //Get all function and create a button for each with their symbol
        {
            List<string> helpMessage = new List<string>();
            List<string> operation = new List<string>();
            List<char> acceptedKeys = new List<char>();
            Tuple<List<string>, List<char>, List<string>> result = Tuple.Create(operation, acceptedKeys, helpMessage);

            //Add all digits to the accepted keys
            for (int i = 0; i < 10; i++)
            {
                acceptedKeys.Add(Char.Parse(i.ToString()));
            }

            try
            {
                //string path = Directory.GetCurrentDirectory();
                Assembly dll = Assembly.LoadFile(path);
                Type[] types = dll.GetExportedTypes();
                Console.WriteLine("length of type : " + types.Length);

                foreach(Type type in types)
                {
                    MemberInfo[] members = type.GetMembers(BindingFlags.Public |
                            BindingFlags.Instance | BindingFlags.InvokeMethod);
                    Console.WriteLine("\n" + type.Name + "\n");
                    foreach (MemberInfo member in members)
                    {

                        Console.WriteLine(member.Name);
                        //Only take classes that have function get_Symbol
                        if (!type.ContainsGenericParameters && member.Name == "get_Symbol")
                        {
                            
                            operation.Add(type.Name);

                            object temp = Activator.CreateInstance(type);
                            string s = (string)type.InvokeMember("get_Symbol", BindingFlags.InvokeMethod, null, temp, null);
                            acceptedKeys.Add(Char.Parse(s));

                            string m = (string)type.InvokeMember("get_HelpMessage", BindingFlags.InvokeMethod, null, temp, null);
                            helpMessage.Add(m);

                        }
                    }                    
                }
                //Check the char in acceptedKeys in Console
                Console.WriteLine("Accepted Keys");
                foreach(char c in acceptedKeys)
                {
                    Console.WriteLine(c);
                }
                
                //Check the available functions in Console
                Console.WriteLine("Function's name");
                foreach(string name in operation)
                {
                    Console.WriteLine(name);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Could not get the dll file");
                Console.ReadKey();
                return result;
            }
        }
    }
}
