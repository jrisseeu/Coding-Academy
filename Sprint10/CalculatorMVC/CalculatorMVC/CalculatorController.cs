using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorMVC {
    class CalculatorController {

        CalculatorModel aCalcModel;
        CalculatorView aCalcView;

        public CalculatorController() {

            Boolean keepGoing = true;

            while (keepGoing) {

                aCalcModel = new CalculatorModel();
                aCalcView = new CalculatorView();
                
                aCalcView.startCalculatorUp();
                Calculator aCalc = new Calculator(aCalcView.getUserInputNumber("first"), 
                                                  aCalcView.getUserInputNumber("second"), 
                                                  aCalcView.whatOperationDoesUserWant());

                //call the calculator Model passing in the calculator object and get the result.
                CalculatorResult aResult = aCalcModel.doCalcOperation(aCalc);

                keepGoing = aCalcView.displayResultsAndNextStep(aResult.CalcResult, aResult.PassOrFail, aResult.FailedReasonTxt);
            }
           
        }


    }





}
