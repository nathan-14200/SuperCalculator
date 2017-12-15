using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace FunctionLibrary
{
    public interface Function<T> : IFunction
    {
        T Evaluate(string[] args);
    }

}
