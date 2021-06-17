using System;


namespace Activities {


    class Program {


        static void Main(string[] args) {

            //DoActivityThree();
            DoActivityFour();
        }


        public static void DoActivityOne() {

            fileProcessor aProc = new fileProcessor();


            aProc.readAllLinesFiles();
            aProc.readFileUsingStreamReader();
            aProc.readLines();


        }

        public static void DoActivityTwo() {

            FileParser aParser = new FileParser();

           // aParser.ReadContactJsonFile();

            aParser.ReadContactXmlFile();
        }

        public static void DoActivityThree() {

            FileParserHeight aParser = new FileParserHeight();

            aParser.ReadContactJsonFile();

            
        }

        public static void DoActivityFour()
        {

            FileParserBizAndContacts aParser = new FileParserBizAndContacts();

            //aParser.startProcess();
            //aParser.startProcess3();
            aParser.startProcess4();
        }


    }
}
