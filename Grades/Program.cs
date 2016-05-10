using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello. This is the grade book program");

            GradeBook book = new GradeBook();
            //The following is verbose. C# has a shorter syntax that means this
            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            // subscribe
            book.NameChanged += OnNameChanged;

            // want to prevent being able to assign null to NameChanged
            // use events instead of raw delegates
            
            //book.NameChanged = null;

            book.Name = "Rasa's Grade Book";
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            Console.WriteLine(book.Name);

            // Setting it up this way gives a separation between the act of
            // computing statistics and storing the statistics
            // You can often reduce the complexity of an application, by adding
            // more classes. This abstracts away the complexity.
            GradeStatistics stats = book.ComputeStatistics();
            //Console.WriteLine(stats.AverageGrade);
            WriteResult("Average", stats.AverageGrade);
            //Console.WriteLine(stats.HighestGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            //Console.WriteLine(stats.LowestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Using params", 2, 3, 4);


            Console.WriteLine("End of Program");
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}.");
        }



        static void WriteResult(string description, float result)
        {
            // Console.WriteLine(description + ": " + result);
            Console.WriteLine($"{description}: {result:F2}");

           //  Console.WriteLine();
        }

        static void WriteResult(string description, params int[] results)
        {
            foreach (var item in results)
            {
                // Console.WriteLine(description + ": " + item);
                // Console.WriteLine("{0}: {1}", description, item);

                // string interpolation new in C#6
                Console.WriteLine($"{description}: {item}");

            }
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }
    }
}
