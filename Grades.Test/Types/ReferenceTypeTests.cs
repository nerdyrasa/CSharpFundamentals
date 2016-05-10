using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test.Types
{

    [TestClass]
    public class TypeTests
    {
        #region Arrays

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);

        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        #endregion

        #region Immutability

        // Immutability

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        // Even though a strings are reference types, they
        // act like a value type.

        [TestMethod]
        public void ToUpperCaseString()
        {
            string name = "rasa";
            name = name.ToUpper();

            Assert.AreEqual("RASA", name);
        }

        #endregion

        #region ref and out

        [TestMethod]
        public void UseRefKeyword()
        {
            // The compiler checks whether a ref parameter has been assigned a value before
            // calling the method.
            int number = 44; // Initialized.
            TestRefKeyword(ref number);

            Assert.AreEqual(45, number);
        }

        private void TestRefKeyword(ref int i)
        {
            i += 1;
        }

        [TestMethod]
        public void UseOutKeyword()
        {
            int number = 4;  // can be initialized but it doesn't make sense to initialize
                             // since the called method method is required to assign a value 
                             // before the method returns.
            TestOutKeyword(out number);

            Assert.AreEqual(16, number);

        }

        private void TestOutKeyword(out int i)
        {
            i = 15;
            i += 1;
        }

        // You can't use the ref and out keywords for async methods or iterator methods.
        #endregion

        #region reference and values types and passing parameters
        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Rasa";
            string name2 = "rasa";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);

        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";

        }

        [TestMethod]
        public void VariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Rasa's Book";
            Assert.AreEqual(g1.Name, g2.Name);
            

        }

        [TestMethod]
        public void VariablesHoldAValue()
        {
            int num1 = 4;
            Int32 num2 = 4;

            Assert.AreEqual(num1, num2);

        }
        #endregion

        #region Enums
        [TestMethod]
        public void TryOutEnums()
        {
            EmployeeType testEmployeeType = EmployeeType.Seasonal;
            string output=null;
            if (testEmployeeType==EmployeeType.Seasonal)
            {
                output = "Employee type is seasonal";
            }

            Assert.AreEqual("Employee type is seasonal", output);
        }

        #endregion


    }
}

// enum 

public enum EmployeeType
{
    FullTime=0,
    PartTime=1,
    Seasonal=2,
    Contract=3

}
