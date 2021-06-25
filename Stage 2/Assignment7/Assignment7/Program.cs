using System;

namespace Assignment7 
{
    class Program {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {


            testValueTypes();
            //testStruct();


            //testInterface1();
            //testInterface2();
        }
        /// <summary>
        /// 
        /// </summary>
        private static void testInterface1() {

            IBusinessLogic run = new BusinessLogic();
            run.FindBusinessWithContacts();
        }
        /// <summary>
        /// 
        /// </summary>
        private static void testInterface2() {

            IBusinessLogicDictionary run = new BusinessLogic();
            run.FindBusinessWithContactsUsingDictionary();
        }
        /// <summary>
        /// 
        /// </summary>
        private static void testStruct() {

            // Declare object with new keyword
            DriversLicenseStruct u = new DriversLicenseStruct("Hyderabad", 31);

            // Declare object without new keyword
            DriversLicenseStruct u1;
            Console.WriteLine("Name: {0}, Location: {1}, Age: {2}", DriversLicenseStruct.name, u.location, u.age);

            // Initialize Fields
            u1.location = "Guntur";
            u1.age = 32;
            Console.WriteLine("Name: {0}, Location: {1}, Age: {2}", DriversLicenseStruct.name, u1.location, u1.age);
            Console.WriteLine("\nPress Enter Key to Exit..");
            Console.ReadLine();

        }
        /// <summary>
        /// 
        /// </summary>
        private static void testValueTypes() {
            int num1 = 5;
            int num2 = 10;
            Console.WriteLine(num1 + " " + num2);
            Square(num1, num2);
            Console.WriteLine(num1 + " " + num2);
            Console.WriteLine("Press Enter Key to Exit..");
            Console.ReadLine();
        }

        /// <summary>
        ///   Showing how value types work
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Square(int a, int b)
        {
            a = a * a;
            b = b * b;
            Console.WriteLine(a + " " + b);
        }

        private static void testReferenceTypes() {
            Person p1 = new Person();
            Person p2 = new Person();
            p1.age = 5;
            p2.age = 10;
            Console.WriteLine(p1.age + " " + p2.age);
            Square(p1, p2);
            Console.WriteLine(p1.age + " " + p2.age);
            Console.WriteLine("Press Any Key to Exit..");
            Console.ReadLine();

        }
        

        /// <summary>
        ///  Showing how reference types work
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Square(Person a, Person b)
        {
            a.age = a.age * a.age;
            b.age = b.age * b.age;
            Console.WriteLine(a.age + " " + b.age);
        }


    }
}
