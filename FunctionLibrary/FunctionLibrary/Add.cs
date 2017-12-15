using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperComputer
{
    public class Add : Function<double>, IFunction
    {

        public string Name
        {
            get
            {
                return "Add";
            }
        }

        public string HelpMessage
        {
            get
            {
                return "Does the sum of 2 numbers";
            }
        }

        public string[] ParametersName
        {
            get
            {
                string[] param = new string[2] { "float a", "flaot b" };

                return param;
            }
        }

        public double Evaluate(params string[] args)
        {
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);

                double result = a + b;
                
                return result;
            }
            catch
            {
                throw new EvaluationException("Could not compute Add function");
            }
        }
    }
}
