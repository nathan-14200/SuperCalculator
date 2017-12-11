﻿using System;
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
        private static List<char> acceptedKey = new List<char>();
        private static List<string> function = new List<string>();
        private static List<Button> myButton = new List<Button>();

        public Calculator()
        {
            //Allow on pressed key events
            this.KeyPreview = true;
            AllocConsole();
            //Initialize default available function
            string path = Directory.GetCurrentDirectory();
            function = LoadingFunction.Operate(path + @"\FunctionLibrary.dll").Item1;
            acceptedKey = LoadingFunction.Operate(path + @"\FunctionLibrary.dll").Item2;


            InitButtons(acceptedKey);
            InitializeComponent();
            Input.KeyPress += new KeyPressEventHandler(KeypressCheck);
 
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

        private void historic_TextChanged(object sender, EventArgs e)
            //Useless for now
            //Maybe for load data?
        {
            string text = "";

            foreach(string line in historic)
            {
                text += line + "\r\n";
            }

            //Result.Text = text;
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
                //Result type must accpet toString()
                string result = Computer.Computing(line, function, acceptedKey).ToString();

                //Add to historic to save later in text file
                historic.Add(line);
                historic.Add("=" + result);

                //Using AppendText makes the scrollbar to follow new line
                Result.AppendText(line + "\r\n");
                Result.AppendText("=" + result + "\r\n");
                //#Obsolete historic_TextChanged(historic, e);
                Input.Text = "";
            }
            else
            {
                MessageBox.Show("Only one operator per compute");
                Input.Text = "";
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

        
        private void InitButtons(List<char> symbol)
        {
            //Delete all existing button an reinit myButton
            DestroyButton();

            int x = 450;
            int size = 0;
            int i = 0;
            Console.WriteLine("size = " + symbol.Count());

            while (size < symbol.Count())
            {
                if (i < 10)
                {
                    Button button = new Button();
                    button.Name = symbol[size].ToString();
                    button.Text = symbol[size].ToString();
                    button.Location = new Point(x, 40 * i + 10);
                    button.Click += new EventHandler(ButtonClick);
                    button.AutoSize = true;
                    this.Controls.Add(button);
                    i++;
                    size++;

                    myButton.Add(button);
                }
                else
                {
                    i = 0;
                    x += 100;
                }               
            }            
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
            //Button pressed must respect InputLineCheck
            KeyPressEventArgs key = new KeyPressEventArgs(Char.Parse(button.Text));
            if (InputLineCheck(sender, key))
            {
                Input.AppendText(button.Text);
            }


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
                    string filePath = SearchDialog.FileName;
                    Console.WriteLine(filePath);
                    //Must update our list
                    function = LoadingFunction.Operate(filePath).Item1;
                    acceptedKey = LoadingFunction.Operate(filePath).Item2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
    }
}

