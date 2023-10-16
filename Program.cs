//Name: Muqadas Arshad
//Roll no: BITF20M023
//ASSIGNMENT_04 -TASK(1)
using System;
using System.Data;

namespace Assignment_04
{
    class Program
    {
       
        public static string Solve(string equation)
        {
            try
            {
                // Remove spaces from the input equation
                equation = equation.Replace(" ", "");

                // ********************************* TASK 1 (c) *********************************//
                if (equation.Contains("x"))
                {
                    string[] operands = equation.Split('x');
                    double operand1 = double.Parse(operands[0]);
                    double operand2 = double.Parse(operands[1]);
                    double product = operand1 * operand2;
                    return product.ToString();
                }
                // ********************************* TASK 1 (d) *********************************//
                else if (equation.Contains("/"))
                {
                    string[] operands = equation.Split('/');
                    double operand1 = double.Parse(operands[0]);
                    double operand2 = double.Parse(operands[1]);
                    double quotient = operand1 / operand2;
                    return quotient.ToString("0.######"); 
                }
                // ********************************* TASK 1 (a) *********************************//
                else if (equation.Contains("+"))
                {
                    string[] operands = equation.Split('+');
                    double sum = 0;
                    foreach (string operand in operands)
                    {
                        sum += double.Parse(operand);
                    }
                    return sum.ToString();
                }
                // ********************************* TASK 1 (b) *********************************//
                else if (equation.Contains("-"))
                {
                    string[] operands = equation.Split('-');
                    double difference = double.Parse(operands[0]);
                    for (int i = 1; i < operands.Length; i++)
                    {
                        difference -= double.Parse(operands[i]);
                    }
                    return difference.ToString();
                }
                else
                {
                    String str = "Invalid input";
                    return str;
                    
                }

            }
            catch (Exception ex)
            {
                return "Invalid equation: " + ex.Message;
            }

        }

        // *********************** TASK 1 (e) & TASK 1 (f) & TASK 1 (g) **********************//
        static double SolveExpression(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }


        static string PerformOperation(string expression, int operatorIndex, char operation)
        {
            // Find the operands around the operator
            int leftOperandStart = FindLeftOperandStart(expression, operatorIndex);
            int rightOperandEnd = FindRightOperandEnd(expression, operatorIndex);

            // Extract operands and the operator as strings
            string leftOperandStr = expression.Substring(leftOperandStart, operatorIndex - leftOperandStart).Trim();
            string rightOperandStr = expression.Substring(operatorIndex + 1, rightOperandEnd - operatorIndex - 1).Trim();

            // Validate operands before parsing
            if (!double.TryParse(leftOperandStr, out double leftOperand) || !double.TryParse(rightOperandStr, out double rightOperand))
            {
                Console.WriteLine("Error: Invalid operands in the expression.");
                Environment.Exit(0);
            }

            // Perform the operation and replace it in the expression
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = leftOperand + rightOperandEnd;
                    break;
                case '-':
                    result = leftOperand - rightOperandEnd;
                    break;
                case '*':
                    result = leftOperand * rightOperandEnd;
                    break;
                case '/':
                    if (rightOperandEnd != 0)
                    {
                        result = leftOperand / rightOperandEnd;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero!");
                        Environment.Exit(0);
                    }
                    break;
            }

            // Replace the operation and operands with the result in the expression
            expression = expression.Remove(leftOperandStart, rightOperandEnd - leftOperandStart + 1);
            expression = expression.Insert(leftOperandStart, result.ToString());

            return expression;
        }



        static int FindLeftOperandStart(string expression, int operatorIndex)
        {
            // Find the start index of the left operand
            int leftOperandStart = operatorIndex - 1;
            while (leftOperandStart >= 0 && (char.IsDigit(expression[leftOperandStart]) || expression[leftOperandStart] == '.'))
            {
                leftOperandStart--;
            }

            return leftOperandStart + 1;
        }

        static int FindRightOperandEnd(string expression, int operatorIndex)
        {
            // Find the end index of the right operand
            int rightOperandEnd = operatorIndex + 1;
            while (rightOperandEnd < expression.Length && (char.IsDigit(expression[rightOperandEnd]) || expression[rightOperandEnd] == '.'))
            {
                rightOperandEnd++;
            }

            return rightOperandEnd;
        }


        

        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the equation:");
                string equation = Console.ReadLine();
                string solution = Solve(equation);
                Console.WriteLine("Output: " + solution);

                Console.WriteLine("Enter a mathematical expression:");
                string expression = Console.ReadLine();
                double result = SolveExpression(expression);
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}

