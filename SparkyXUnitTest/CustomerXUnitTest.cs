using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
   
    public class CustomerXUnitTest
    {
        private Customer customer;

       
        public CustomerXUnitTest()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            // Customer customer = new Customer();

            //Act
            string fullName = customer.CombineNames("Ben", "Spark");

            //Assert
           
            Assert.Equal("Hello, Ben Spark", customer.GreetMessage);          
            Assert.Contains(("ben Spark").ToLower(), customer.GreetMessage.ToLower());
            Assert.StartsWith("Hello,", customer.GreetMessage);
            Assert.EndsWith("Spark", customer.GreetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
            


        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //arrange
            var customer = new Customer();

            //act


            //assert
            Assert.Null(customer.GreetMessage);

        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            //Arrange
            int result = customer.Discount;
            //Act

            //Assert
            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.CombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.CombineNames("", "Spark"));
            Assert.Equal("Empty firstname", exceptionDetails.Message);

            Assert.Throws<ArgumentException>(() => customer.CombineNames("", "Spark"));

          
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThat100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();

            Assert.IsType<BasicCustomer>(result);
        }


        [Fact]
        public void CustomerType_CreateCustomerWithMoreThat100Order_ReturnBasicCustomer()
        {
            //Arrange
            customer.OrderTotal = 101;
            //Act
            var result = customer.GetCustomerDetails();
            //Assert
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
