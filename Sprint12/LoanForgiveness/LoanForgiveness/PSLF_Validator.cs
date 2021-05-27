using System;
using System.Collections.Generic;
using System.Text;

namespace LoanForgiveness {
    public class PSLF_Validator {

        private string[] validEmployerTypes = { "NFP", "STA", "FED", "TRB" };
        DateTime cutoff = new DateTime(2007, 10, 01);

        public ValidatorResponse doesPersonSatifyAllRules(LoanForget aLfo) {

                if (!hasAllDirectLoans(aLfo)) {
                    return new ValidatorResponse(false, "Borrower did not have DLP loans: Received " +aLfo.aLoanType) ;
                }

                if (!borrowerIsInCorrectRepaymentPlan(aLfo)) {
                    return new ValidatorResponse(false, "Borrower is not in an IDR Repayment Plan: Received " +aLfo.repaymentPlan);
                }

                if (!isPaymentStartDtValid(aLfo)) {
                    return new ValidatorResponse(false, "Borrower repayment start date has to be after 10-01-2007: Received " +aLfo.paymentStartDt);
                }

                if (!passedRequiredHoursWorked(aLfo)) {
                    return new ValidatorResponse(false, "Borrower has to be working 40 hours: Received " +aLfo.numHoursWorked);
                }

                if (!latePaymentsOrWithin15Days(aLfo)) {
                    return new ValidatorResponse(false, "Borrower has to late payment check failed: Received " + aLfo.anyLatePayments + " days late: " +aLfo.numDaysLate);
                }

                if (!met120PaymentsMade(aLfo)) {
                    return new ValidatorResponse(false, "Borrower has to make 120 consecutive payments: Received " + aLfo.numPaymentsMade);
                }   

                if (!worksForForgivableEmpl(aLfo)) {
                    return new ValidatorResponse(false, "Borrower does not work for an eligible employer: Received " + aLfo.employerType);
                }

                //If all edits pass, the borrower is eligible
                return new ValidatorResponse(true, "");
        }

        public bool hasAllDirectLoans(LoanForget aLfo) {

            if (aLfo.aLoanType == "DLP") {
                return true;
            } else
                return false;
            
        }

        public bool isPaymentStartDtValid(LoanForget aLfo) {

            

            int result = DateTime.Compare(aLfo.paymentStartDt, cutoff);

            bool valid = false;
            if (result > 0) {
                valid = true;
            }

            return valid;

        }


        public bool passedRequiredHoursWorked(LoanForget aLfo) {

            if (aLfo.numHoursWorked >= 40) {
                return true;
            }
            else
                return false;
        }

        public bool latePaymentsOrWithin15Days(LoanForget aLfo) {

            bool passed = true;
            if (aLfo.anyLatePayments) {
                if (aLfo.numDaysLate > 15) {
                    passed = false;
                }
            }

            return passed;

        }

        public bool met120PaymentsMade(LoanForget aLfo) {

            bool passed = true;
            if (aLfo.numPaymentsMade < 120) {
                passed = false;
            }

            return passed;

        }

        public bool worksForForgivableEmpl(LoanForget aLfo) {

            bool passed = false;
            for (int i = 0; i < validEmployerTypes.Length; i++) {
                if (aLfo.employerType.Equals(validEmployerTypes[i])) {
                    passed = true;
                }
            }

            return passed;

        }

        public bool borrowerIsInCorrectRepaymentPlan(LoanForget aLfo) {

            bool passed = false;
            if (aLfo.repaymentPlan == "IDR") {
                passed = true;
            } 

            return passed;
        }

    }
}
