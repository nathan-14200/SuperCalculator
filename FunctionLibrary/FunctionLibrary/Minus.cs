using FunctionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class Minus : Function<string>
    {
        public string HelpMessage
        {
            get
            {
                return "does the difference between two numbers";
            }
        }

        public string Name
        {
            get
            {
                return "Minus";
            }
        }

        public string[] ParametersName
        {
            get
            {
                string[] param = new string[2];
                param.SetValue("double a", 0);
                param.SetValue("double b", 1);

                return param;
            }
        }

        public string Symbol
        {
            get
            {
                return "-";
            }
        }

        public string Evaluate(params string[] args)
        {
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);

                double result = a - b;
                return result.ToString();
            }
            catch
            {
                return "Could not compute Minus function ";
            }
        }
    }
}
