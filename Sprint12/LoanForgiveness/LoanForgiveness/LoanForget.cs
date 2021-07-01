using System;
using System.Collections.Generic;
using System.Text;

namespace LoanForgiveness {
    public class LoanForget {

        public string aLoanType;
        public DateTime paymentStartDt {get; set;}
        public Boolean fullTimeWorker {get; set;}
        public int numHoursWorked {get; set;}
        public Boolean anyLatePayments {get; set;}
        public int numDaysLate {get; set;}
        public string repaymentPlan {get; set;}
        public int numPaymentsMade {get; set;}
        public string employerType {get;set;}

        public LoanForget() {

        }



    }
}
