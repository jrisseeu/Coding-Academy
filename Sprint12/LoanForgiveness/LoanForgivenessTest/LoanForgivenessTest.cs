using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanForgiveness;
using System;

namespace LoanForgivenessTest {
    [TestClass]
    public class LoanForgivenessTest {
        [TestMethod]
        public void validateLoanTypePass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.hasAllDirectLoans(aLfo);

            //Assert
            Assert.AreEqual(passFail, true, "Loan type check passed - failed");
        }

        [TestMethod]
        public void validateLoanTypFail() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.aLoanType = "TIV";
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.hasAllDirectLoans(aLfo);

            //Assert
            Assert.AreEqual(passFail, false, "Loan type failure check passed - failed");
        }

        [TestMethod]
        public void validateEmployerTypePass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.worksForForgivableEmpl(aLfo);

            //Assert
            Assert.AreEqual(passFail, true, "Employer type check passed - failed");
        }

        [TestMethod]
        public void validateEmployerTypeFail() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.employerType = "FOP"; //For Profit
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.worksForForgivableEmpl(aLfo);

            //Assert
            Assert.AreEqual(passFail, false, "Employer type failure check passed - failed");
        }

        [TestMethod]
        public void validateNumberPaymentsPass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.met120PaymentsMade(aLfo);

            //Assert
            Assert.AreEqual(passFail, true, "Number of payments made check passed - failed");
        }

        [TestMethod]
        public void validateNumberPaymentsFail() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.numPaymentsMade = 119;
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.met120PaymentsMade(aLfo);

            //Assert
            Assert.AreEqual(passFail, false, "Number of payments made failure check passed - failed");
        }

        [TestMethod]
        public void validatePaymentStartDatePass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.isPaymentStartDtValid(aLfo);

            //Assert
            Assert.AreEqual(passFail, true, "Payment Start Date check passed - failed");
        }


        [TestMethod]
        public void validatePaymentStartDateEqualFail() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.paymentStartDt = new DateTime(2007, 10, 01);

            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.isPaymentStartDtValid(aLfo);

            //Assert
            Assert.IsFalse(passFail, "Payment Start Date Equal to cutoff date check passed - failed");
        }

        [TestMethod]
        public void validatePaymentStartDateBeforeFail() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.paymentStartDt = new DateTime(2007, 09, 30);

            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.isPaymentStartDtValid(aLfo);

            //Assert
            Assert.IsFalse(passFail, "Payment Start Date Before cutoff date check passed - failed");
        }


        [TestMethod]
        public void validateNoLatePaymentsPass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.latePaymentsOrWithin15Days(aLfo);

            //Assert
            Assert.IsTrue(passFail, "No Late Payments check passed - failed");
        }

        [TestMethod]
        public void validateLatePaymentsBelow15DaysPass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.anyLatePayments = true;
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.latePaymentsOrWithin15Days(aLfo);

            //Assert
            Assert.IsTrue(passFail, "Late Payments under 15 days check passed - failed");
        }

        [TestMethod]
        public void validateLatePaymentsAt15DaysPass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.anyLatePayments = true;
            aLfo.numDaysLate = 15;
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.latePaymentsOrWithin15Days(aLfo);

            //Assert
            Assert.IsTrue(passFail, "Late Payments and at 15 days check passed - failed");
        }


        [TestMethod]
        public void validateLatePaymentsOver15DaysFail() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.anyLatePayments = true;
            aLfo.numDaysLate = 16;
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.latePaymentsOrWithin15Days(aLfo);

            //Assert
            Assert.IsFalse(passFail, "Late Payments and over 15 days failure check passed - failed");
        }

        [TestMethod]
        public void validateBorrowerRepaymentPlanPass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.borrowerIsInCorrectRepaymentPlan(aLfo);

            //Assert
            Assert.IsTrue(passFail, "Borrower is in correct repayment plan check passed - failed");
        }

        [TestMethod]
        public void validateBorrowerRepaymentPlanFail() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.repaymentPlan = "XYZ";
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.borrowerIsInCorrectRepaymentPlan(aLfo);

            //Assert
            Assert.IsFalse(passFail, "Borrower is in correct repayment plan Fail check passed - failed");
        }
        [TestMethod]
        public void validateBorrowerHoursWorkingPass() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.passedRequiredHoursWorked(aLfo);

            //Assert
            Assert.IsTrue(passFail, "Borrower 40 hours per week check - failed");
        }

        [TestMethod]
        public void validateBorrowerHoursWorkingFail() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.numHoursWorked = 39;
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            bool passFail = aValidator.passedRequiredHoursWorked(aLfo);

            //Assert
            Assert.IsFalse(passFail, "Borrower 40 hours per week check Fail check - failed");
        }


        [TestMethod]
        
        public void doesPersonSatisfyAllRules_hasAllDirectLoansFailExpected() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.aLoanType = "TIV";
           
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            ValidatorResponse aResp = aValidator.doesPersonSatifyAllRules(aLfo);

            //Assert
            Assert.IsFalse(aResp.passFail, "Expected failure of the direct loan check");
        }


        [TestMethod]

        public void doesPersonSatisfyAllRules_borrowerIsInCorrectRepaymentPlanFailExpected() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.repaymentPlan = "XYZ";

            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            ValidatorResponse aResp = aValidator.doesPersonSatifyAllRules(aLfo);

            //Assert
            Assert.IsFalse(aResp.passFail, "Expected failure of the repayment plan check");
        }

        [TestMethod]

        public void doesPersonSatisfyAllRules_isPaymentStartDtValidFailExpected() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.paymentStartDt = new DateTime(2007, 10, 01);

            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            ValidatorResponse aResp = aValidator.doesPersonSatifyAllRules(aLfo);

            //Assert
            Assert.IsFalse(aResp.passFail, "Expected failure of the payment start check");
        }

        [TestMethod]
        public void doesPersonSatisfyAllRules_passedRequiredHoursWorkedFailExpected() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.numHoursWorked = 39;

            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            ValidatorResponse aResp = aValidator.doesPersonSatifyAllRules(aLfo);

            //Assert
            Assert.IsFalse(aResp.passFail, "Expected failure of the number of hours worked check");
        }

        [TestMethod]
        public void doesPersonSatisfyAllRules_latePaymentsOrWithin15DaysFailExpected() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.anyLatePayments = true;
            aLfo.numDaysLate = 16;

            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            ValidatorResponse aResp = aValidator.doesPersonSatifyAllRules(aLfo);

            //Assert
            Assert.IsFalse(aResp.passFail, "Expected failure of the number late payment check");
        }

        [TestMethod]
        public void doesPersonSatisfyAllRules_met120PaymentsMadeFailExpected() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.numPaymentsMade = 119;

            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            ValidatorResponse aResp = aValidator.doesPersonSatifyAllRules(aLfo);

            //Assert
            Assert.IsFalse(aResp.passFail, "Expected failure of the number of payments made check");
        }

        [TestMethod]
        public void doesPersonSatisfyAllRules_worksForForgivableEmplFailExpected() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            aLfo.employerType = "FPT";

            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            ValidatorResponse aResp = aValidator.doesPersonSatifyAllRules(aLfo);

            //Assert
            Assert.IsFalse(aResp.passFail, "Expected failure of the employer type check");
        }

        [TestMethod]
        public void doesPersonSatisfyAllRules_allEditsPassedExpected() {

            //Arrange
            LoanForget aLfo = createPassableObject();
            
            PSLF_Validator aValidator = new PSLF_Validator();

            //Act
            ValidatorResponse aResp = aValidator.doesPersonSatifyAllRules(aLfo);

            //Assert
            Assert.IsTrue(aResp.passFail, "Expected the passing of all edits");
        }




        public LoanForget createPassableObject() {

            LoanForget aLfo = new LoanForget();

            aLfo.aLoanType = "DLP";
            aLfo.anyLatePayments = false;
            aLfo.employerType = "NFP";
            aLfo.fullTimeWorker = true;
            aLfo.numDaysLate = 10;
            aLfo.numHoursWorked = 40;
            aLfo.numPaymentsMade = 121;
            aLfo.paymentStartDt = new DateTime(2009, 02, 20);
            aLfo.repaymentPlan = "IDR";





            return aLfo;
        
        
        }

    }
}
