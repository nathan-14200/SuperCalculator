using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace SuperComputer
{
    public interface Function<T> : IFunction
    {
        T Evaluate(string[] args);
    }

}
