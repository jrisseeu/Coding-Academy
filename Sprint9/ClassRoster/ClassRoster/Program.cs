using System;
using System.Collections.Generic;

namespace ClassRoster {
    class Program {
        static void Main(string[] args) {


            //Student aStdnt = new Student();
            //aStdnt.Firstname = "Jeff";
            //aStdnt.LastName = "Risseeuw";
            //aStdnt.SchoolYear = "Freshman";
            //Console.WriteLine(aStdnt.ToString());
            //Student aStdnt2 = new Student("Jeffro", "Rizzu", "Junior");
            //Console.WriteLine(aStdnt2.ToString());
            //Instructor aTeacher = new Instructor("Todd", "Teach", "dude@aol.com");
            //Console.WriteLine(aTeacher.ToString());




            //Start Class roster with Teacher info
            Console.Write("Enter Class Roster information ");
            Console.WriteLine("\n"); // Friendly linespacing.
            Console.Write("Instructor First Name: ");
            string teachFirstNm = Console.ReadLine();
            Console.Write("Instructor Last Name: ");
            string teachLastNm = Console.ReadLine();
            Console.Write("Instructor Email Address ");
            string teachEmail = Console.ReadLine();
            Instructor aTeacher = new Instructor(teachFirstNm, teachLastNm, teachEmail);
            

            //setup to get the student info collected
            Boolean keepGoing = true;
            List<Student> stdntList = new List<Student>();


            while (keepGoing) {

                Console.WriteLine("Enter 1 to add a Student to the roster ");
                Console.WriteLine("Enter 2 to print the roster ");
                Console.WriteLine("Enter 3 to quit ");
                

                string option = Console.ReadLine();

                switch (option) {
                    case "1":
                        Console.WriteLine("\n"); // Friendly linespacing.
                        Console.Write("Enter student first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter student last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter student school year: ");
                        string yrInSchool = Console.ReadLine();
                        Console.Write("Enter student GPA: ");
                        string gpa = Console.ReadLine();

                        stdntList.Add(new Student(firstName, lastName, yrInSchool, gpa));
                        Console.WriteLine("\n"); // Friendly linespacing. 
                        break;
                    case "2":
                        Console.WriteLine("\n"); // Friendly linespacing.  
                        Console.WriteLine(aTeacher.ToString());
                        foreach (Student aStudent in stdntList) {
                            Console.WriteLine(aStudent.ToString());
                            Console.WriteLine(aStudent.StudentType);
                        }
                        Console.WriteLine("\n"); // Friendly linespacing.  
                        break;
                    case "3":
                        keepGoing = false;
                        break;
                    default:
                        break;
                }
            }

        }




    }
}
