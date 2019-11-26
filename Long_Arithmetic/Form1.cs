using Long_Arithmetic_BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Long_Arithmetic
{   
    public partial class Form1 : Form
    {
        private double _timeSecond;
        private int _timeMinute;
        private ulong _timeHour;
        private int _countOfEqutation;
        public Form1()
        {
            InitializeComponent();
            string[] operations = { "Add", "Subtract", "Multiply", "Divide", "Power", "Module", "Sqrt", "China theoreme" };
            comboBoxOperation.DataSource = operations;
            _timeSecond = 0;
            _timeMinute = 0;
            _timeHour = 0;
            _countOfEqutation = 0;
        }

        private async void ButtonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxFirstOperand.Text) || string.IsNullOrEmpty(textBoxSecondOperand.Text))
                {
                    if (comboBoxOperation.SelectedValue.ToString() != "Sqrt")
                    {
                        throw new ArgumentNullException("Enter all operands!");

                    }
                }

                var firstOperand = textBoxFirstOperand.Text;
                var secondOperand = textBoxSecondOperand.Text;
                if(comboBoxOperation.SelectedValue.ToString() == "Sqrt")
                {
                    secondOperand = "0";
                }

                Number num1 = new Number(firstOperand);
                Number num2 = new Number(secondOperand);

                Number module=new Number();
                if (checkBoxUseModule.Checked)
                {
                    module = new Number(textBoxModule.Text);
                }

                labelRest.Text = "0";

                Number result = new Number();
                timer.Interval = 10;
                timer.Start();

                switch (comboBoxOperation.Text)
                {
                    case "Add":
                        if (checkBoxUseModule.Checked)
                        {
                            result = await Number.ModuleAsync(Number.Add(num1, num2), module);
                        }
                        else
                        {
                            result = await Number.AddAsync(num1, num2);
                        }
                        break;

                    case "Subtract":
                        if (checkBoxUseModule.Checked)
                        {
                            result = await Number.ModuleAsync(Number.Subtract(num1, num2), module);
                        }
                        else
                        {
                            result = await Number.SubtractAsync(num1, num2);
                        }
                        break;

                    case "Multiply":
                        if (checkBoxUseModule.Checked)
                        {
                            result = await Number.ModuleAsync(Number.Multiply(num1, num2), module);
                        }
                        else
                        {
                            result = await Number.MultiplyAsync(num1, num2);
                        }
                        break;

                    case "Divide":
                        var res = await Number.DivideAsync(num1, num2);
                        result = res.result;
                        labelRest.Text = res.rest.ToString();
                        break;
                    case "Power":
                        if (checkBoxUseModule.Checked)
                        {
                            result =await Number.ExponentWithModuleAsync(num1, num2, module);
                        }
                        else
                        {
                            result = await Number.ExponentAsync(num1, num2);
                        }
                        break;
                    case "Module":
                        if (checkBoxUseModule.Checked)
                        {
                            result = await Number.ModuleAsync(Number.Module(num1, num2), module);
                        }
                        else
                        {
                            result = await Number.ModuleAsync(num1, num2);
                        }
                        break;
                    case "Sqrt":
                        if (checkBoxUseModule.Checked)
                        {
                            result = await Number.ModuleAsync(Number.Sqrt(num1), module);
                        }
                        else
                        {
                            result = Number.Sqrt(num1);
                        }
                        break;
                }
                timer.Stop();
                string resultString = result.ToString();
                using (StreamWriter writer = new StreamWriter(@"C:\Users\Evgentus\Desktop\result.txt", false))
                {
                    await writer.WriteLineAsync(resultString);  // асинхронная запись в файл
                }
                labelResult.Text = resultString;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void CheckBoxUseModule_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseModule.Checked)
            {
                textBoxModule.Enabled = true;
            }
            else
            {
                textBoxModule.Enabled = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timeSecond += 0.01;

            if (_timeSecond >= 60)
            {
                _timeMinute++;
                _timeSecond = 0;
            }
            if (_timeMinute >= 60)
            {
                _timeHour++;
                _timeMinute = 0;
            }
            timeLabel.Text = $"{_timeHour} h, {_timeMinute} m, {_timeSecond} s";
        }

        private void ComboBoxOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (ComboBox)sender;
            if (list.SelectedValue.ToString() == "Sqrt")
            {
                textBoxSecondOperand.Enabled = false;
                return;
            }
            textBoxSecondOperand.Enabled = true;
        }

        private void ButtonAddEquation_Click(object sender, EventArgs e)
        {

            _countOfEqutation++;

            Label count = new Label();
            Point pcount = new Point(700, 40 * _countOfEqutation + 180);
            count.Location = pcount;
            count.Name = "labelEquation" + _countOfEqutation.ToString();

            count.Text = _countOfEqutation.ToString() + ".";
            this.Controls.Add(count);

            Label x = new Label();
            Point px = new Point(730, 40 * _countOfEqutation + 180);
            x.Location = px;
            x.Name = "labelX" + _countOfEqutation.ToString();

            count.Text = "X = ";
            this.Controls.Add(x);


            TextBox first = new TextBox();
            Point pfirst = new Point(760, 40 * _countOfEqutation + 180);
            first.Location = pfirst;

            Size sizef = new Size(150, 20);
            first.Size = sizef;

            first.Name = "textBoxEquationFirst" + _countOfEqutation.ToString();

            this.Controls.Add(first);


            Label mod = new Label();
            Point pmod = new Point(790, 40 * _countOfEqutation + 180);
            mod.Location = pmod;
            mod.Name = "labelMod" + _countOfEqutation.ToString();

            count.Text = "mod";
            this.Controls.Add(mod);

            TextBox second = new TextBox();
            Point psecond = new Point(820, 40 * _countOfEqutation + 180);
            second.Location = psecond;

            Size sizes = new Size(150, 20);
            second.Size = sizes;

            second.Name = "textBoxEquationecond" + _countOfEqutation.ToString();

            this.Controls.Add(second);
        }
    }
}
