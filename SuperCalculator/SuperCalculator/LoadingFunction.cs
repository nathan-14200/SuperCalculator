using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalculator
{
    class LoadingFunction
    {


        public static Tuple<Dictionary<string, string[]>, List<string>> Operate(string path)
        //Get all function and create a button for each with their Name
        {
            List<string> helpMessage = new List<string>();
            Dictionary<string,string[]> operation = new Dictionary<string, string[]>();
            
            Tuple<Dictionary<string, string[]>, List<string>> result = Tuple.Create(operation, helpMessage);

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
                        //Only take classes that have function get_Name
                        if (!type.ContainsGenericParameters && member.Name == "get_Name")
                        {
                            object temp = Activator.CreateInstance(type);
                            string name = (string)type.InvokeMember("get_Name", BindingFlags.InvokeMethod, null, temp, null);
                            string[] param = (string[])type.InvokeMember("get_ParametersName", BindingFlags.InvokeMethod, null, temp, null);

                            operation[name] = param;

                            string m = (string)type.InvokeMember("get_HelpMessage", BindingFlags.InvokeMethod, null, temp, null);
                            helpMessage.Add(m);

                        }
                    }                    
                }
                
                //Check the available functions in Console
                Console.WriteLine("Function's name");
                foreach(KeyValuePair<string, string[]> name in operation)
                {
                    Console.WriteLine("key : " + name.Key + " " + name.Value.Count());
                }
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur :" + e);
                Console.WriteLine(e);
                Console.WriteLine("Could not get the dll file");
                Console.ReadKey();
                return result;
            }
        }
    }
}
