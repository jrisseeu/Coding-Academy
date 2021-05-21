using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassRosterMVC {
    class ClassRosterView {

        private string[] OperationType = { "1", "2", "3", "4" };
        private string[] SchoolYear = { "FR", "SO", "JR", "SR" };
       

        public ClassRosterView() {
        }

        public void startClassRoster() {

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Welcome to your class roster maintenance application  ");
            Console.WriteLine("------------------------------------------------------");
        }

        public string startStudentEntry() {

          
            Console.WriteLine("Enter 1 to add a Student to the roster ");
            Console.WriteLine("Enter 2 to print the roster ");
            Console.WriteLine("Enter 3 to print the roster and quit ");
            Console.WriteLine("Enter 4 to quit ");
            Console.WriteLine();

            string opValue = Console.ReadLine();
            Console.Write("user selected " + opValue);

            while (!validateOperationValue(opValue)) {
                Console.Write("This is not valid operation. Please enter a valid option: ");
                opValue = Console.ReadLine();
            }

            return opValue;
        }

        private Boolean validateOperationValue(string op) {

            Boolean validOption = false;
            for (int i = 0; i < OperationType.Length; i++) {
                if (op.Equals(OperationType[i])) {
                    validOption = true;
                }
            }

            return validOption;
        }

        public string collectNameInfo(string aPerson, string fieldPart) {

            
            Console.Write("Enter the " +aPerson +" " + fieldPart + " Name: ");
            string name = Console.ReadLine();

            while (String.IsNullOrEmpty(name)) {
                Console.Write("Please add the " + aPerson + " " + fieldPart + " Name: ");
                name = Console.ReadLine();
            }

            return name;
        }

        public string collectStudentGPA() {

            Console.Write("What is the students GPA ");
            string gpa = Console.ReadLine().ToUpper();

            while (String.IsNullOrEmpty(gpa)) {
                Console.Write("Please provide the student gpa: ");
                gpa = Console.ReadLine().ToUpper();
                
            }

            return gpa;

        }

        public string collectStudentYear() {

            Console.Write("What year is the student in school (FR, SO, JR, SR) ");
            string year = Console.ReadLine().ToUpper();

            while (String.IsNullOrEmpty(year)) {
                Console.Write("Please provide the student year: ");
                year = Console.ReadLine().ToUpper();
               ;
            }

            while (!validateStudentYearValue(year)) {
                Console.Write("Please provide (FR, SO, JR, SR) ");
                year = Console.ReadLine().ToUpper();
            }

            string retVal = "";
            switch (year) {
                case "FR":
                    retVal = "Freshman";
                    break;
                case "SO":
                    retVal = "Sophmore";
                    break;
                case "JR":
                    retVal = "Junior";
                    break;
                case "SR":
                    retVal = "Senior";
                    break;
                default:
                    retVal = "TBD";
                    break;
            }

            return retVal;
        }

        private Boolean validateStudentYearValue(string op) {

            Boolean validOption = false;
            for (int i = 0; i < SchoolYear.Length; i++) {
                if (op.Equals(SchoolYear[i])) {
                    validOption = true;
                }
            }

            return validOption;
        }


        public string collectInstructorEmail() {

            Console.Write("Enter the Instructor Email Address: ");
            string email = Console.ReadLine();

            while (!validateEmail(email)) {
                Console.Write("Invalid Email address, please enter valid email address: ");
                email = Console.ReadLine();
            }

            Console.Clear();
            return email;
        }

        private Boolean validateEmail(string emailAdr) {
           
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailAdr);
            bool validEmail = false;
            if (match.Success) {
                validEmail = true;
            }

            return validEmail;
    
        }




        public void displayInstructor(Instructor aTeacher) {

            Console.WriteLine(aTeacher.ToString());
        
        }

        public void displayStudentList(List<Student> stdntList) {

            foreach (Student aStudent in stdntList) {
                Console.WriteLine(aStudent.ToString());
            }


        }


    }
}
