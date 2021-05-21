using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRosterMVC {
    class ClassRosterModel {

        private Instructor aTeacher;
        private List<Student> aStdntList;

        public ClassRosterModel() { }


        public List<Student> StudentList {

            get {
                return aStdntList;
            
            }

        }



        public Instructor Teacher {

            get {
                return aTeacher;
            }

            set {
                aTeacher = value;
            }
        }

        public void addStudentToList(Student aStdnt) {

            if (null == aStdntList) {

                aStdntList = new List<Student>();
                aStdntList.Add(aStdnt);
            } else {
                aStdntList.Add(aStdnt);
            }
        }


        public void addInstructor(string firstName, string lastName, string emailAddress) {

            aTeacher = new Instructor(firstName, lastName, emailAddress);

        }


        public void addStudentToRoster(string firstName, string lastName, string yearInSchl, string gpa) {

            Student aStudent = new Student(firstName, lastName, yearInSchl, gpa);
            addStudentToList(aStudent);
        }
    }
}
