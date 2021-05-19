using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRoster {
    class Student : Person {


        private string schoolYear;
        private string studentType;  //A, B, C, D or F
        private double gradePointAvg;

        public string SchoolYear {

            get {
                return schoolYear;
            }

            set {
                schoolYear = value;
            }
        }

        public string StudentType {

            get {
                return studentType;
            }

            set {
                studentType = value;
            }
        
        }


        public double GradePointAvg {

            get {
                return gradePointAvg;
            }

            set {
                gradePointAvg = value;
            }
        }


        public Student() : base() {
        }

        public Student(string aFirstName, string aLastName, string aSchoolYear) :base(aFirstName, aLastName) {

            schoolYear = aSchoolYear;

        }

        public Student(string aFirstName, string aLastName, string aSchoolYear, string gpa) : base(aFirstName, aLastName) {

            schoolYear = aSchoolYear;

            determineStudentType(gpa);

        }

        private void determineStudentType(string gpa) {

            double newGpa = new double();

            try {
                newGpa = Convert.ToDouble(gpa);
            } catch (Exception) {
                this.studentType = "TBD";
                return;
            }
            

            if (newGpa >= 3.5) {
                this.studentType = "A";

            }
            else if (newGpa >= 3.0 && newGpa < 3.5) {
                this.studentType = "B";
            }
            else if (newGpa >=  2.5 && newGpa < 3.0) {
                this.studentType = "C";
            }
            else if (newGpa >= 2.0 && newGpa < 2.5) {
                this.studentType = "D";
            }
            else if (newGpa < 2.0) {
                this.studentType = "F";

            }
        }

        public override string ToString() {

            if (this.StudentType == "") {
                return "Student: " + this.Firstname + " " + this.LastName + " Year: " + this.SchoolYear;
            }
            else {
                return "Student: " + this.Firstname + " " + this.LastName + " Student Type: " +this.StudentType + " Year: " + this.SchoolYear;
            }

            
        
        }




    }
}
