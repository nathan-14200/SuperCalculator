using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalculator
{
    class Buttons
    {
        public static void Init(List<char> symbols)
        {
            foreach(char c in symbols)
            {
                Button button = new Button();
                button.Name = c.ToString();

                
            }
        }

        public static void ButtonClick(object b, EventArgs e)
        {
        }
    }
}
