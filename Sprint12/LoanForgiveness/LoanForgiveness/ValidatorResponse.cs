using System;
using System.Collections.Generic;
using System.Text;

namespace LoanForgiveness {
     public class ValidatorResponse {

        public Boolean passFail {
            get; set;
        }
        public string failErrorTx {
            get; set;
        }

        public ValidatorResponse() {
        }

        public ValidatorResponse(bool aPassFail, string aFailErrorTxt) {
            this.passFail = aPassFail;
            this.failErrorTx = aFailErrorTxt;
        }


    }
}
