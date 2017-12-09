using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public interface Function<T>
    {

        string Name { get; }
        //Get the name of the function

        string HelpMessage { get; }
        //Tells what the function does and give param format

        string[] ParametersName { get; }
        //Get the list of param

        T Evaluate(string[] args);
        //Evaluate function with given param or throw exception
    }

    public class EvaluationException : Exception
    {
        public EvaluationException(string msg) : base(msg)
        {

        }
    }

}
