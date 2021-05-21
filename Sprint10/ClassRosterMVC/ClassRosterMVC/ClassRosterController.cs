using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRosterMVC {
    class ClassRosterController {

        ClassRosterView aView;
        ClassRosterModel aModel;
        const string instr = "Instructor";
        const string stdnt = "Student";





        public ClassRosterController() {


            aView = new ClassRosterView();
            aModel = new ClassRosterModel();
            aView.startClassRoster();


            aModel.addInstructor(aView.collectNameInfo(instr, "First"),
                                 aView.collectNameInfo(instr, "Last"),
                                 aView.collectInstructorEmail());

            bool keepGoing = true;
            
            while (keepGoing) {

                string op = aView.startStudentEntry();
                Console.WriteLine("User selected " + op);

                switch (op) {
                    case "1":
                        aModel.addStudentToRoster(aView.collectNameInfo(stdnt, "First"), 
                                                  aView.collectNameInfo(stdnt, "Last"), 
                                                  aView.collectStudentYear(), 
                                                  aView.collectStudentGPA());
                        break;
                    case "2":
                        aView.displayInstructor(aModel.Teacher);
                        aView.displayStudentList(aModel.StudentList);

                        break;
                    case "3":
                        aView.displayInstructor(aModel.Teacher);
                        aView.displayStudentList(aModel.StudentList);
                        keepGoing = false;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
