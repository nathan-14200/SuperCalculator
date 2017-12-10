using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuperCalculator
{
    //Name chane to Computer because button name is Compute
    class Computer
    {
        public static string Computing(string input,List<string> function, List<char> s)
            //Precondition: Must take an input with only one or no operator in the input
        {
            string result = "";

            List<char> symbol = s;

            char op = ' ';
            //Get the symbol in the input
            string ope = Regex.Replace(input, @"[\d]", string.Empty);
            Console.WriteLine(ope);
            if(ope.Length == 1)
            {
                op = Char.Parse(ope);
            }
            else
            {
                return "Error length ope";
            }


            try
            {
                string path = Directory.GetCurrentDirectory();
                Assembly dll = Assembly.LoadFile(path + @"\FunctionLibrary.dll");
                Type[] types = dll.GetExportedTypes();
                Console.WriteLine("length of type : " + types.Length);

                //Check if our list contain an operator
                if (symbol.Contains(op))
                {
                    //Check all classes
                    foreach(Type type in types)
                    {
                        //Check if accepted class (has get_Symbol and not generic)
                        if (function.Contains(type.Name))
                        {
                            object temp = Activator.CreateInstance(type);
                            //Get the symbol of the class
                            string sym = (string)type.InvokeMember("get_Symbol", BindingFlags.InvokeMethod, null, temp, null);
                            if (op == Char.Parse(sym))
                            {

                                string[] var = input.Split(op).ToArray();
                                //Compute with Evaluate
                                result = (string)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod, null, temp, new object[] {var});

                                //Check in Console
                                Console.WriteLine("result =" + result);
                                return result;
                            }
                        }
                        
                    }
                }
                else
                {
                    //return input if no operator found (1 = 1)
                    return input;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Could not compute");
                Console.ReadKey();
                result = "Could not get result from function, Check Help message";
                return result;
            }

            return result;
        }

    }
}
