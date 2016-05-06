using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Rasa";
            string name2 = "rasa";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);

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


    }
}
