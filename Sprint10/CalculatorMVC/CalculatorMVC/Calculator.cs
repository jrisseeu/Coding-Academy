using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorMVC {
    public class Calculator {

        private double number1;
        private double number2;
        private string operation;


        public double Number1 {
            get {
                return number1;
            }
            set {
                number1 = value;
            }
        }

        public double Number2 {
            get {
                return number2;
            }
            set {
                number2 = value;
            }
        }

        public string Operation {
            get {
                return operation;
            }
            set {
                operation = value;
            }
        }

        public Calculator() {
            number1 = 0;
            number2 = 0;
            operation = "";
        }

        public Calculator(double aNumber1, double aNumber2, string aOperation) {
            number1 = aNumber1;
            number2 = aNumber2;
            operation = aOperation;
        }
    }
}
