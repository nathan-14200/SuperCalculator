using SuperComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperComputer
{
    public class Minus : SuperComputer.Function<double>
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
                string[] param = new string[2] { "double a", "double b" };

                return param;
            }
        }


        public double Evaluate(params string[] args)
        {
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);

                double result = a - b;
                return result;
            }
            catch 
            {
                throw new EvaluationException("Could not compute Minus function");
            }
        }
    }
}
