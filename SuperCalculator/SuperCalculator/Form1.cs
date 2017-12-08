using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalculator
{
    public partial class Calculator : Form
    {

        private static List<string> historic = new List<string>();
        //stock the special char used for computing (/,%,+,...)
        private static List<char> acceptedKey = new List<char> { '1', '2', '3', '4', '5',
        '6', '7', '8', '9', '0', '+', '*', '-', '/'};

        public Calculator()
        {
            //Allow on pressed key events
            this.KeyPreview = true;
            InitializeComponent();
            Input.KeyPress += new KeyPressEventHandler(KeypressCheck);
        }


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
            
            //historic.Add(c.ToString());
            //historic_TextChanged(historic, e);
        }


        private void Compute_Click(object sender, EventArgs e)
        {
            string line = Input.Text;
            historic.Add(line);
            historic_TextChanged(historic, e);
            Input.Text = "";
        }

    }
}
