﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class Add : Function<string>
    {

        string Function<string>.Symbol
        {
            get
            {
                return "+";
            }
        }

        string Function<string>.Name
        {
            get
            {
                return "Add";
            }
        }

        string Function<string>.HelpMessage
        {
            get
            {
                return "Does the sum of 2 numbers";
            }
        }

        string[] Function<string>.ParametersName
        {
            get
            {
                string[] param = new string[2];
                param.SetValue("float a", 0);
                param.SetValue("float b", 1);

                return param;
            }
        }

        public string Evaluate(string[] args)
        {
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);

                string result = (a + b).ToString();
                return result;
            }
            catch
            {
                return "Could not compute Add function";
            }
        }
    }
}