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
            GradeBook book = new GradeBook();

            // book.NameChanged += OnNameChanged;
            // book.Name = "Rasa's Grade Book";
            // SpeakGradeBookName(book.Name);

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}.");
        }


        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }


        static void WriteResult(string description, params int[] results)
        {
            foreach (var item in results)
            {
                Console.WriteLine($"{description}: {item}");
            }
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void SpeakGradeBookName(string gradebookName)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak($"Hello. This is {gradebookName}.");
        }
    }
}
