using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    // SuperComputer.IFunction
    public interface IFunction
    {
        string Name
        {
            get;
        }

        string HelpMessage
        {
            get;
        }

        string[] ParametersName
        {
            get;
        }
    }

}
