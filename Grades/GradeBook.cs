using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{

    // classes are reference types
    // variables hold a pointer value
    // can have multiple variables pointing to the same object

    public class GradeBook
    {
        // class members define
        // 1. state (nouns)
        // 2. behavior (verbs)

        // ctor code snippet -- press tab twice. Easy peasy.
        // constructor
        public GradeBook()
        {
            grades = new List<float>();
            Name = "default value";
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        // This is a field.
        // generic type syntax
        // a list that can hold zero or more floating point numbers


        private List<float> grades;

        // Field initializer syntax
        // List<float> grades = new List<float>();

        public string Name;
        
    }
}
