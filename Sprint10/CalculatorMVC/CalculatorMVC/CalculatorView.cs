using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorMVC {
    class CalculatorView {

        public enum OperationType { a, s, m, d };


        public CalculatorView() { }

        public void startCalculatorUp() {

            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to your calculator  ");
            Console.WriteLine("----------------------------");
        }


        public double getUserInputNumber(string whichEntry) {

            Console.Write("Enter your " + whichEntry + " number, and then press Enter: ");
            string numInput = Console.ReadLine();

            double cleanNum = 0;
            while (!double.TryParse(numInput, out cleanNum)) {
                Console.Write("This is not valid input. Please enter a number: ");
                numInput = Console.ReadLine();
            }

            return cleanNum;
        }

        public string whatOperationDoesUserWant() {

            // Ask the user to choose an operator.
            Console.Clear();
            Console.WriteLine("Enter the option of the operation you want to perform with the numbers?  ");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string opValue = Console.ReadLine().ToLower();

            while (!validateOperationValue(opValue)) {
                Console.Write("This is not valid operation. Please enter a valid option: ");
                opValue = Console.ReadLine();
            }

            return opValue;

        }

        //Validate the user input of the operation to be performed.  If not valid, return false, otherwise true
        private Boolean validateOperationValue(string op) {

            Boolean validOption = false;
            foreach (OperationType val in Enum.GetValues(typeof(OperationType))) {
                string check = val.ToString();
                if (check.Equals(op.ToString())) {
                    validOption = true;
                }
            }
            return validOption;
        }


        public Boolean displayResultsAndNextStep(double result, Boolean passFailCalc, string failReason) {

            Boolean keepGoing = true;
            Console.Clear();

            if (!passFailCalc) {
                Console.WriteLine("Error encounterd: " +failReason + "\n");
            }
            else {
                Console.WriteLine("Your result: {0:0.##}\n", result);
            }
            
            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Press 'N' to close the app, or press any other key to continue  ");

            if (Console.ReadLine().ToUpper() == "N") {
                keepGoing = false;
            } else {
                Console.Clear();
            }

            return keepGoing;
        }


    }
}
