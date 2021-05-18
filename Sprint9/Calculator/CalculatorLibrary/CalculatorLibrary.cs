using System;

namespace CalculatorLibrary
{
    public class Calculator {

        private double number1;
        private double number2;


        public double Number1 {
            get { return number1; }
            set { Number1 = value; }
        }

        public double Number2 {
            get { return number2; }
            set { Number2 = value; }
        }

        public Calculator() {
            number1 = 0;
            number2 = 0;
        }

           public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0) {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
    }
}
