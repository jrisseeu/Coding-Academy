using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorMVC {
    class CalculatorModel {


        public CalculatorModel() {

        }


        public CalculatorResult doCalcOperation(Calculator aCalcObject) {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            Boolean success = true;
            string failReasTx = "";

            // Use a switch statement to do the math.
            switch (aCalcObject.Operation) {
                case "a":
                    result = aCalcObject.Number1 + aCalcObject.Number2;
                    break;
                case "s":
                    result = aCalcObject.Number1 - aCalcObject.Number2;
                    break;
                case "m":
                    result = aCalcObject.Number1 * aCalcObject.Number2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (aCalcObject.Number2 != 0) {
                        result = aCalcObject.Number1 / aCalcObject.Number2;
                    }
                    else {
                        success = false;
                        failReasTx = "Cannot divide by zero.  Please start over.";
                    }
                    break;
                // Return text for an incorrect option entry.  should never get here, but just in case.
                default:
                    success = false;
                    failReasTx = "Invalid operation pressed.  Please start over.";
                    break;
            }

            return new CalculatorResult(result, success, failReasTx);

        }

    }
}
