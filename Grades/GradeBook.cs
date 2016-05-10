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

        public GradeBook()
        {
            grades = new List<float>();
            // use name, the field (which has first letter lower case), 
            // not the property name, Name (which has first letter upper case)
            name = "Empty";
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


        private List<float> grades;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {

                if (!String.IsNullOrEmpty(value))
                {
                    if (name != value)
                    {
                        NameChanged(name, value);
                    }
                    name = value;
                }
            }
        }

        public NameChangedDelegate NameChanged;

    }
}
