using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            // Customer customer = new Customer();

            //Act
            string fullName = customer.CombineNames("Ben", "Spark");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
                Assert.AreEqual(fullName, "Hello, Ben Spark");
                Assert.That(fullName, Does.Contain("ben Spark").IgnoreCase);
                Assert.That(fullName, Does.StartWith("Hello,"));
                Assert.That(fullName, Does.EndWith("Spark"));
                Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
            });


        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //arrange
            var customer = new Customer();

            //act


            //assert
            Assert.IsNull(customer.GreetMessage);

        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            //Arrange
            int result = customer.Discount;
            //Act

            //Assert
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.CombineNames("ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.CombineNames("", "Spark"));
            Assert.AreEqual("Empty firstname", exceptionDetails.Message);

            Assert.That(() => customer.CombineNames("", "spark"),
                Throws.ArgumentException.With.Message.EqualTo("Empty firstname"));

            Assert.Throws<ArgumentException>(() => customer.CombineNames("", "Spark"));
            
            Assert.That(() => customer.CombineNames("", "spark"),
                Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThat100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }


        [Test]
        public void CustomerType_CreateCustomerWithMoreThat100Order_ReturnBasicCustomer()
        {
            //Arrange
            customer.OrderTotal = 101;
            //Act
            var result = customer.GetCustomerDetails();
            //Assert
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
