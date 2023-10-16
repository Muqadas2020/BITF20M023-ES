//Name: Muqadas Arshad
//Roll no: BITF20M023
//ASSIGNMENT_04 -TASK(2)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASSIGNMENT_04  //TASK-2
{
    
    public partial class Calculator : Form
    {
        Double result = 0;
        String operation = "";
        bool operationPerformed = false;
        String firstnum, secondnum;
       

        public Calculator()
        {
            InitializeComponent();
            //this.KeyPress += new KeyPressEventHandler(Calculator_KeyPress);
        }
        




        private void Calculator_Load(object sender, EventArgs e)
        {
            //this.Focus();
        }

        private void n_click(object sender, EventArgs e)
        {
            if ((textBox.Text == "0") || (operationPerformed))
            {
                textBox.Clear();
            }
            operationPerformed = false;
            Button number = (Button)sender;
            if (number.Text == ".")
            {
                if (!textBox.Text.Contains("."))
                {
                    textBox.Text = textBox.Text + number.Text;
                }

            }
            else
            {
                textBox.Text = textBox.Text + number.Text;
            }
        }

        private void operators_click(object sender, EventArgs e)
        {
            Button arithmetic_operation = (Button)sender;
            if (result != 0)
            {
                nequal.PerformClick();
                operation = arithmetic_operation.Text;
                label1.Text = result + " " + operation;
                operationPerformed = true;
            }
            else
            {
                operation = arithmetic_operation.Text;
                result = Double.Parse(textBox.Text);
                label1.Text = result + " " + operation;
                operationPerformed = true;
            }
            firstnum = label1.Text;
        }



        private void nequal_Click(object sender, EventArgs e)
        {
            secondnum = textBox.Text;

            if (Double.TryParse(secondnum, out double operand))
            {
                switch (operation)
                {
                    case "+":
                        textBox.Text = (result + operand).ToString();
                        break;
                    case "-":
                        textBox.Text = (result - operand).ToString();
                        break;
                    case "*":
                    case "x":
                    case "X":
                        textBox.Text = (result * operand).ToString();
                        break;
                    case "/":
                        if (operand != 0)
                        {
                            textBox.Text = (result / operand).ToString();
                        }
                        else
                        {
                            textBox.Text = "Error"; // Handle division by zero error
                        }
                        break;
                    default:
                        textBox.Text = "Error"; // Handle unsupported operation
                        break;
                }

                // No need to parse the text again, as the TryParse method succeeded
                result = operand;
                label1.Text = "";
                operationPerformed = true;

                if (DisplayHistory.Text == "No History yet.")
                {
                    DisplayHistory.Clear();
                    DisplayHistory.AppendText("History");
                }

                DisplayHistory.AppendText("\n " + firstnum + " " + secondnum + " = ");
                DisplayHistory.AppendText(textBox.Text + "\n");
            }
            else
            {
                textBox.Text = "Error"; // Handle invalid input (non-numeric input)
                                        // You might want to display an error message or handle this situation differently based on your requirements.
            }
        }





        private void nclear_click(object sender, EventArgs e)
        {
            textBox.Clear();
            textBox.Text = "0";
            // Reset operation and result for new calculation
            operation = "";
            result = 0;
            label1.Text = "";
        }

        private void nbackspace_Click(object sender, EventArgs e)
        {
            if(textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
            }
            if(textBox.Text=="")
            {
                textBox.Text = "0";
                result = 0;

            }
        }
    }
}
