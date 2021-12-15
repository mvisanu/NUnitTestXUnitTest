using Bongo.Models.ModelValidations;
using NUnit.Framework;

namespace Bongo.Models.Tests
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {
        [Test]
        [TestCase(100, ExpectedResult = true)]
        [TestCase(-100, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        public bool DateValidator_InputExpectedDateRage_DateValidity(int addTime)
        {
            //Arrange
            DateInFutureAttribute dateInFutureAttribute = new(() => DateTime.Now);

            //Act
            return dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(addTime));

            //Assert
           // Assert.AreEqual(true, result);
        }

        [Test]
        public void DateValidator_NotValidDate_ReturnErrorMessage()
        {
            var result = new DateInFutureAttribute();

            Assert.AreEqual("Date must be in the future", result.ErrorMessage);
        }
    }
}