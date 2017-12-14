using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalculator
{
    //Name chane to Computer because button name is Compute
    class Computer
    {
        public static string Computing(string function,List<string> allinputs, string path)
            //Precondition: Must take an input with only one or no operator in the input
        {
            string result = "";

            try
            {
                
                Assembly dll = Assembly.LoadFile(path);
                Type[] types = dll.GetExportedTypes();
                Console.WriteLine("length of type : " + types.Length);
               
                //Check all classes
                foreach(Type type in types)
                {
                    MemberInfo[] members = type.GetMembers(BindingFlags.Public |
                            BindingFlags.Instance | BindingFlags.InvokeMethod);
                    foreach (MemberInfo member in members)
                    {
                        //Check if accepted class (has get_Name and not generic)
                        if (!type.ContainsGenericParameters && member.Name == "get_Name")
                        {
                            object temp = Activator.CreateInstance(type);
                            //Get the symbol of the class
                            string name = (string)type.InvokeMember("get_Name", BindingFlags.InvokeMethod, null, temp, null);
                            if (function == name)
                            {
                                string[] var = allinputs.ToArray();
                                //Compute with Evaluate
                                result = type.InvokeMember("Evaluate", BindingFlags.InvokeMethod, null, temp, new object[] { var }).ToString();
                                //Check in Console
                                Console.WriteLine("result =" + result);
                                return result;
                            }
                        }
                    }                 
                }

                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e);
                Console.WriteLine("Could not compute");
                Console.ReadKey();
                result = "Could not get result from function, Check Help message";
                return result;
            }
        }
    }
}
