using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTest
    {
        private GradingCalculator gradingCalculator;
        [SetUp]
        public void SetUp()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GradingCalculator_Score95Attendance90_ReturnA()
        {
            //Arrange
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.AreEqual("A", result);
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GradingCalculator_Score85Attendance90_ReturnB()
        {
            //Arrange
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.AreEqual("B", result);
            Assert.That(result, Is.EqualTo("B"));
        }


        [Test]
        public void GradingCalculator_Score65Attendance90_ReturnC()
        {
            //Arrange
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.AreEqual("C", result);
            Assert.That(result, Is.EqualTo("C"));
        }
        [Test]
        public void GradingCalculator_Score95Attendance65_ReturnB()
        {
            //Arrange
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.AreEqual("B", result);
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95,55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GradingCalculator_Score95Attendance55_ReturnF(int a, int b)
        {
            //Arrange
            gradingCalculator.Score = a;
            gradingCalculator.AttendancePercentage = b;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert           
            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")] //A
        [TestCase(85, 90, ExpectedResult = "B")] //B
        [TestCase(65, 90, ExpectedResult = "C")] //C
        [TestCase(95, 65, ExpectedResult = "B")] //B
        [TestCase(95, 55, ExpectedResult = "F")] //F
        [TestCase(65, 55, ExpectedResult = "F")] //F
        [TestCase(50, 90, ExpectedResult = "F")] //F
        public string GradingCalculator_AllScoreAttendance_ReturnGrade(int a, int b)
        {
            //Arrange
            gradingCalculator.Score = a;
            gradingCalculator.AttendancePercentage = b;
            return gradingCalculator.GetGrade();
        }
    }
}
