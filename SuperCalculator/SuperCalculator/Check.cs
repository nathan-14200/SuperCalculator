using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalculator
{
    class Check
    {
        public static bool CheckInputs(List<TextBox> myInputs, string currentFunction)
        {
            //Check if a function is selected and no blank inputs
            if(currentFunction.Count() < 1)
            {
                return false;
            }
            foreach (TextBox textbox in myInputs)
            {
                if (textbox.Text.Length < 1)
                {
                    return false;
                }
            }

            return true;
        } 
    }
}
