using SuperComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperComputer
{
    public class Minus : SuperComputer.Function<string>
    {
        public string HelpMessage
        {
            get
            {
                return "Does the difference between a and b (a-b)";
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
                return "Could not compute Minus function";
            }
        }
    }
}
