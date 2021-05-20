using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorMVC {
    class CalculatorResult {

        private double calcResult;
        private Boolean passOrFail;
        private string failedReasonTxt;


        public double CalcResult {

            get {
                return calcResult;
            }

            set {
                calcResult = value;
            }
        
        }
        public Boolean PassOrFail {

            get {
                return passOrFail;
            }

            set {
                passOrFail = value;
            }

        }

        public string FailedReasonTxt {

            get {
                return failedReasonTxt;
            }

            set {
                failedReasonTxt = value;
            }

        }

        public CalculatorResult(double result, Boolean passFail, string failReasonTxt) {
            calcResult = result;
            passOrFail = passFail;
            failedReasonTxt = failReasonTxt;
        }

        public override string ToString() {
            return "Result:  " + this.CalcResult + "  Good Calc Stat: " + this.PassOrFail + " Fail Reason: " + FailedReasonTxt;
        }


    }
}
