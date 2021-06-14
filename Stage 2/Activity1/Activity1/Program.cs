using System;


namespace Activities {


    class Program {


        static void Main(string[] args) {

            DoActivityThree();
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


    }
}
