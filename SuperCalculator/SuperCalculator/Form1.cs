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

        public Calculator()
        {
            InitializeComponent();
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

        // private void input_KeypressCheck(object sender, KeyPressEventArgs e)


        private void Compute_Click(object sender, EventArgs e)
        {
            string line = Input.Text;
            historic.Add(line);
            historic_TextChanged(historic, e);
            Input.Text = "";
        }

    }
}
