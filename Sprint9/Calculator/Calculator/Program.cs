using System;
using CalculatorLibrary;

namespace CalculatorProgram
{
    
    class Program
    {
        static void Main(string[] args) {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            CalulatorOption calcOption = new CalulatorOption();


            while (!endApp) {
                // Declare variables and set to empty.
                double result = 0;

                double cleanNum1 = getUserInputNumber("first");
                double cleanNum2 = getUserInputNumber("second");
                String op = calcOption.requestOptionSelection();

                try {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result)) {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    } else Console.WriteLine("Your result: {0:0.##}\n", result);
                } catch (Exception e) {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }

        //pull the numbers from the user input
        public static double getUserInputNumber(string numberId) {

            // Ask the user to type the first number.
            Console.Write("Type your " + numberId + " number, and then press Enter: ");
            string numInput = Console.ReadLine();
           
            double cleanNum = 0;
            while (!double.TryParse(numInput, out cleanNum)) {
                Console.Write("This is not valid input. Please enter a number: ");
                numInput = Console.ReadLine();
            }

            return cleanNum;
        }

    }



}