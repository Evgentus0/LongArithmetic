﻿using Long_Arithmetic_BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Long_Arithmetic
{   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] operations = { "Add", "Subtract", "Multiply", "Divide", "Power" };
            comboBoxOperation.DataSource = operations;
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxFirstOperand.Text) || string.IsNullOrEmpty(textBoxSecondOperand.Text))
                {
                    throw new ArgumentNullException("Enter all operands!");
                }

                var firstOperand = textBoxFirstOperand.Text;
                var secondOperand = textBoxSecondOperand.Text;

                Number num1 = new Number(firstOperand);
                Number num2 = new Number(secondOperand);

                labelRest.Text = "0";

                string result = "";

                switch (comboBoxOperation.Text)
                {
                    case "Add":
                        result = Number.Add(num1, num2).ToString();
                        break;

                    case "Subtract":
                        result = Number.Subtract(num1, num2).ToString();
                        break;

                    case "Multiply":
                        result = Number.Multiply(num1, num2).ToString();
                        break;

                    case "Divide":
                        result = Number.Divide(num1, num2, out Number rest).ToString();
                        labelRest.Text = rest.ToString();
                        break;
                }
                labelResult.Text = result;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}