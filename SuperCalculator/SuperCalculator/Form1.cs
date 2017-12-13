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
using System.IO;

namespace SuperCalculator
{
    public partial class Calculator : Form
    {

        private static List<string> historic = new List<string>();
        //stock the special char used for computing (/,%,+,...)
        private static string filePath = "";
        
        private static string currentFunction = "";
        private static Dictionary<string,string[]> function = new Dictionary<string, string[]>();
        private static List<string> helpMessage = new List<string>();
        private static List<Button> myButton = new List<Button>();
        private static List<TextBox> myInputs = new List<TextBox>();
        private static List<Label> myLabels = new List<Label>();


        public Calculator()
        {
            //Allow on pressed key events
            this.KeyPreview = true;
            AllocConsole();
            //Initialize default available function
            string path = Directory.GetCurrentDirectory();
            var data = LoadingFunction.Operate(path + @"\FunctionLibrary.dll");
            function = data.Item1;
            helpMessage = data.Item2;
            
            InitializeComponent();
            
 
        }
        //Allow to get Console while in Window mode
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.Selectable, false);
            this.AcceptButton = Compute;
        }

        private void UpdateHistoric(List<string> allInputs, string result)
        {
            string line = currentFunction + " : " + allInputs[0];
            for(int i =1; i < allInputs.Count(); i++)
            {
                line += " and " + allInputs[i];
            }



            historic.Add(line);
            historic.Add("=" + result);
            //Using AppendText makes the scrollbar to follow new line
            Result.AppendText(line + "\r\n");
            Result.AppendText("=" + result + "\r\n");
            //#Obsolete historic_TextChanged(historic, e);

            //clear all inputs
            foreach(TextBox textbox in myInputs)
            {
                textbox.Text = "";
            }
        }

        private void KeypressCheck(object sender, KeyPressEventArgs e)
            //Check if pressed key is a digit, a point or a control key 
            //otherwise handle the char and it doesn't appear in Input.Text
        {
            
            if( !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar!=',')
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
            TextBox input = (TextBox)sender;

            int InputSize = input.Text.Length;
            //input can't start with a point
            if(InputSize < 1 && !Char.IsDigit(e.KeyChar))
            {
                 return false;
            }
            //one point per line
            int point = 0;
            for (int i = 0; i < input.Text.Count(); i++)
            {
                if (input.Text[i] == ',')
                {
                    point += 1;
                }
            }
            if (e.KeyChar == ',' && point > 0)
            {
                return false;
            }
            return true;
        }


        private void Compute_Click(object sender, EventArgs e)
        {
            List<string> allInputs = new List<string>();

            foreach(TextBox t in myInputs)
            {
                allInputs.Add(t.Text);
            }

            //Result type must accept toString()
            string result = Computer.Computing(currentFunction, allInputs, filePath).ToString();
            //Add to historic to save later in text file
            UpdateHistoric(allInputs, result);

            
            
        }

        private bool CheckMultipleOperator(string input)
            //Useless for now
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


        private void InitInputs()
        {
            DestroyInputs();
            

            fName.Text = "Selected Function: " + currentFunction;
            int x = 60;
            
            Console.WriteLine("size = " + function.Count());

            foreach (KeyValuePair<string, string[]> el in function)
            {
                if (el.Key == currentFunction)
                {
                    for (int i = 0; i < el.Value.Count(); i++)
                    {
                        Label name = new Label();
                        name.Location = new Point(0, 40 * i + 300);
                        name.Text = el.Value[i];
                        name.Width = 50;
                        TextBox textbox = new TextBox();
                        textbox.Name = el.Key;
                        textbox.KeyPress += new KeyPressEventHandler(KeypressCheck);

                        textbox.Location = new Point(x, 40 * i + 300);
                        this.Controls.Add(name);
                        this.Controls.Add(textbox);
                        myInputs.Add(textbox);
                        myLabels.Add(name);                    
                    }
                }
            }

        }


        private void DestroyInputs()
        {
            foreach (TextBox textbox in myInputs)
            {
                this.Controls.Remove(textbox);
            }

            foreach(Label label in myLabels)
            {
                this.Controls.Remove(label);
            }

            myInputs = new List<TextBox>();
            myLabels = new List<Label>();
        }

        
        private void InitButtons()
        {
            //Delete all existing button an reinit myButton
            DestroyButton();

            int x = 400;
            int i = 0;
            Console.WriteLine("size = " + function.Count());

            foreach(KeyValuePair<string, string[]> el in function)
            {
                if (i < 10)
                {
                    Button button = new Button();
                    button.Name = el.Key;
                    button.Text = el.Key;
                    
                    button.Location = new Point(x, 40 * i + 10);
                    button.Click += new EventHandler(ButtonClick);
                    button.AutoSize = true;
                    
                    //Show HelpMessage while mouse on button
                    button.Tag = helpMessage[i];
                    button.MouseHover += new EventHandler(Button_MouseHover);

                    this.Controls.Add(button);
                    myButton.Add(button);

                    i++;
                }
                else
                {
                    i = 0;
                    x += 100;
                }               
            }            
        }


        private void Button_MouseHover(object sender, EventArgs e)
        {
            //Allow ToolTip when mouse over button
            Button button = (Button)sender;
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(button, button.Tag.ToString());
        }


        private void DestroyButton()
        {
            foreach(Button button in myButton)
            {
                this.Controls.Remove(button);
            }

            myButton = new List<Button>();
        }


        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            currentFunction = button.Text;
            InitInputs();
            //Button must execute the right function

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string result = Save.ToText(historic);
            Result.AppendText(result);
            historic = new List<string>();
        }

        private void ChargeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog SearchDialog = new OpenFileDialog();
            SearchDialog.InitialDirectory = "c:\\";
            SearchDialog.Filter = "dll files (*.dll)|*.dll";
            SearchDialog.FilterIndex = 2;
            SearchDialog.RestoreDirectory = true;
            try
            {
                if(SearchDialog.ShowDialog() == DialogResult.OK)
                {                    
                    filePath = SearchDialog.FileName;
                    Console.WriteLine(filePath);
                    //Must update our list
                    var data = LoadingFunction.Operate(filePath);
                    function = data.Item1;
                    helpMessage = data.Item2;
                    InitButtons();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
    }
}

