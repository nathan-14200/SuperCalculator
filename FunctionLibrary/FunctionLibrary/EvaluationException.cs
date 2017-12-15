using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    // SuperComputer.EvaluationException


    public class EvaluationException : Exception
    {
        public EvaluationException(string msg) : base(msg)
        {
        }
    }

}
