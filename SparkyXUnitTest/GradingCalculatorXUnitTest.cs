using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
   
    public class GradingCalculatorXUnitTest
    {
        private GradingCalculator gradingCalculator;
       
        public GradingCalculatorXUnitTest()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Fact]
        public void GradingCalculator_Score95Attendance90_ReturnA()
        {
            //Arrange
           
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("A", result);
          
        }

        [Fact]
        public void GradingCalculator_Score85Attendance90_ReturnB()
        {
            //Arrange
           
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("B", result);
            
        }


        [Fact]
        public void GradingCalculator_Score65Attendance90_ReturnC()
        {
            //Arrange
           
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("C", result);
           
        }
        [Fact]
        public void GradingCalculator_Score95Attendance65_ReturnB()
        {
            //Arrange
            
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("B", result);
           
        }

        [Theory]
        [InlineData(95,55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GradingCalculator_Score95Attendance55_ReturnF(int a, int b)
        {
            //Arrange
           
            gradingCalculator.Score = a;
            gradingCalculator.AttendancePercentage = b;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert           
            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90, "A")] //A
        [InlineData(85, 90, "B")] //B
        [InlineData(65, 90, "C")] //C
        [InlineData(95, 65, "B")] //B
        [InlineData(95, 55, "F")] //F
        [InlineData(65, 55, "F")] //F
        [InlineData(50, 90, "F")] //F
        public void GradingCalculator_AllScoreAttendance_ReturnGrade(int a, int b, string exp)
        {
            //Arrange
           
            gradingCalculator.Score = a;
            gradingCalculator.AttendancePercentage = b;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal(exp, result);
        }
    }
}
