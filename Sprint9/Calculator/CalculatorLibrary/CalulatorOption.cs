using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLibrary {
    public class CalulatorOption {

        private string selectionType;


        public string selType {
            get {
                return selectionType;
            }
            set  {
                selectionType = value;
            }
        }

        public CalulatorOption() {

        }


        public string requestOptionSelection() {

            // Ask the user to choose an operator.
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            return Console.ReadLine().ToLower();
                        
        }




    }
}   
