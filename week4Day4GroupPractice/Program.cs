using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week4Day4GroupPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            List<int> testScores = new List<int>();

            Console.WriteLine("Please enter ten test scores between 0-100. Enter a score: ");
            testScores.Add(int.Parse(Console.ReadLine()));

            while (testScores.Count < 10)
            {
                Console.WriteLine("You have entered " + (testScores.Count) + ",");
                testScores.Add(int.Parse(Console.ReadLine()));
            }

            int total = 0;

            for (counter = 0; counter < testScores.Count; counter++)
            {
                total += testScores[counter];
            }
            //Console.WriteLine("The sum of your scores is {0}.", total);
            int avg = total / testScores.Count;
            //Console.WriteLine("The average of your scores is {0}.", avg);

            int[] convertedArray = testScores.ToArray();
            WriteScores(convertedArray, total, avg);
            ReadScores();

        }

        static void WriteScores(int[] testScores, int total, int avg)
        {
            using (StreamWriter scores = new StreamWriter("scores.txt"))
            {
                foreach (int score in testScores)
                {
                    scores.WriteLine(score);
                }
                scores.WriteLine("The sum of the scores is {0}", total);
                scores.WriteLine("The average of all of the scores is {0}", avg);
            }
        }

        static void ReadScores()
        {
            string fileName = "scores.txt";
            try
            {
                StreamReader reader = new StreamReader("scores.txt");
                using (reader)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Your file {0} was not found.", fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Invalid directory in the file path.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Cannot open the file {0}.", fileName);
            }
        }
            //using (StreamWriter scores = new StreamWriter("scores.txt"))
            //{
            //    foreach(int score in testScores)
            //    {
            //        scores.WriteLine(score);
            //    }
            //    scores.WriteLine("The sum of scores is " + total);
            //    scores.WriteLine("The average grade is " + avg);
            //}
        }
    }

