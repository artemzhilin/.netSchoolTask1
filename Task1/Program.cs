using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var firstOperand = ReadNumber("Enter the first operand: ");
            var secondOperand = ReadNumber("Enter the second operand: ");
            var operation = ReadOperation();
            double result;
            try
            {
                result = Calculate(firstOperand, secondOperand, operation);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Unexpected operation! Exit program");
                return;
            }
            Console.WriteLine("{0} {1} {2} = {3}", firstOperand, operation, secondOperand, result);
        }

        private static double ReadNumber(string prompt)
        {
            double number;
            Console.WriteLine(prompt);
            var userNumber = Console.ReadLine();
            while (!double.TryParse(userNumber, out number))
            {
                Console.WriteLine("Incorrect number! Try again: ");
                userNumber = Console.ReadLine();
            }
            
            return number;
        }

        private static char ReadOperation()
        {
            char[] operations = {'+', '-', '*', '/'};
            Console.WriteLine("Enter operation (+ - * /): ");
            var operation = Convert.ToChar(Console.Read());
            
            // Getting rid of new line characters (\r\n)
            Console.ReadLine();
            
            while (!operations.Contains(operation))
            {
                Console.WriteLine("Incorrect operation! Please try again: ");
                operation = Convert.ToChar(Console.Read());
                
                // Getting rid of new line characters (\r\n)
                Console.ReadLine();
            }

            return operation;
        }

        /// <summary>
        /// Calculation method
        /// </summary>
        /// <remarks>
        /// Accepts only + - * / operations
        /// </remarks>
        /// <param name="operand1">A double precision number</param>
        /// <param name="operand2">A double precision number</param>
        /// <param name="operation">A character</param>
        /// <returns>The result of calculation</returns>
        /// <exception cref="InvalidOperationException">Throws when invalid or unexpected operation comes</exception>
        private static double Calculate(double operand1, double operand2, char operation)
        {
            double result;
            switch (operation)
            {
                case '+':
                    result = operand1 + operand2;
                    break;
                case '-':
                    result = operand1 - operand2;
                    break;
                case '*':
                    result = operand1 * operand2;
                    break;
                case '/':
                    result = operand1 / operand2;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return Math.Round(result, 2);
        }
    }
}