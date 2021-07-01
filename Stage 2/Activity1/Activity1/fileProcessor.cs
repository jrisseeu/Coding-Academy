using System;

using System.IO;

namespace Activities {
    public class fileProcessor {

        string fileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Contacts.csv";


        public fileProcessor() {
        }

        /// <summary>
        /// The File.ReadAllLines will read the whole file in at one time then creates the string[]
        /// May be more useful to sue the ReadLines() methoed 
        /// </summary>
        public void readAllLinesFiles() {

            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines) {
                var splits = line.Split(',');

                try {
                    Console.WriteLine(splits[1] + " " + splits[2]);
                }
                catch (Exception e) {
                    Console.WriteLine("Exception error: " + e.ToString());
                    return;
                }

            }

        }

        /// <summary>
        /// Read file one line at a time.
        /// 
        /// By having the using the file will be closed at the end automatically
        /// </summary>
        public void readFileUsingStreamReader() {

            try {

                using (StreamReader reader = new StreamReader(fileName)) {

                    string line;

                    while ((line = reader.ReadLine()) != null) {
                        var splits = line.Split(',');
                        Console.WriteLine(splits[1] + " " + splits[2]);
                    }

                }

            }
            catch (Exception e) {
                Console.WriteLine("Exception error: " + e.ToString());

            }
        }

        /// <summary>
        /// Does not read the whole file at one time.  More efficient that readAllLines()
        /// 
        /// Note: will use the StreamReader.ReadLine() but then turns it into a IEnumerable Objet
        /// </summary>
        public void readLines() {

            foreach (string line in File.ReadLines(fileName)) {
                var splits = line.Split(',');

                try {
                    Console.WriteLine(splits[1] + " " + splits[2]);
                }
                catch (Exception e) {
                    Console.WriteLine("Exception error: " + e.ToString());
                    return;
                }

            }

        }


    }
}
