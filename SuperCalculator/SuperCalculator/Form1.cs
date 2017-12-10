using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public partial class Calculator : Form
    {

        private static List<string> historic = new List<string>();
        //stock the special char used for computing (/,%,+,...)
        private static List<char> acceptedKey = new List<char>();
        private static List<string> function = new List<string>();

        public Calculator()
        {
            //Allow on pressed key events
            this.KeyPreview = true;
            AllocConsole();
            //Initialize available function
            function = LoadingFunction.Operate().Item1;
            acceptedKey = LoadingFunction.Operate().Item2;

            InitializeComponent();
            Input.KeyPress += new KeyPressEventHandler(KeypressCheck);
 
        }
        //Allow to get Console while in Window mode
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.AcceptButton = Compute;
        }

        private void historic_TextChanged(object sender, EventArgs e)
        {
            string text = "";

            foreach(string line in historic)
            {
                text += line + "\r\n";
            }

            Result.Text = text;
        }

        private void KeypressCheck(object sender, KeyPressEventArgs e)
            //Check if pressed key is a digit or an accepted key (+control keys)
            //otherwise handle the char and it doesn't appear in Input.Text
        {
            
            if(!acceptedKey.Contains(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if(!Char.IsControl(e.KeyChar) && !InputLineCheck(sender, e))
            {
                e.Handled = true;
            }
        }


        private bool InputLineCheck(object sender, KeyPressEventArgs e)
        {
            int InputSize = Input.Text.Length;
            //input can't start with an operator
            if(InputSize < 1 && !Char.IsDigit(e.KeyChar))
            {
                 return false;
            }
            //2 operators can't be next to each other
            else if(InputSize > 1 && !Char.IsDigit(e.KeyChar) &&!Char.IsDigit(Input.Text[InputSize-1]))
                {
                    return false;
                }

            return true;
        }


        private void Compute_Click(object sender, EventArgs e)
        {
            string line = Input.Text;

            if(CheckMultipleOperator(line))
            {
                string result = Computer.Computing(line, function, acceptedKey);
                historic.Add(line);
                historic.Add(">>" + result);
                historic_TextChanged(historic, e);
                Input.Text = "";
            }
            else
            {
                MessageBox.Show("Only one operator per compute");
            }
            
        }

        private bool CheckMultipleOperator(string input)
        {
            bool test = true;
            //Delete all numbers from input text
            string op = Regex.Replace(input, @"[\d]", string.Empty);

            if(op.Length > 1)
            {
                test = false;
                return test;
            }
            else
            {
                return test;
            }
        }

    }
}
