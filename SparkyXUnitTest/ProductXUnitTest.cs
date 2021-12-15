using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    
    public class ProductXUnitTest
    {
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            //arrange
            Product product = new Product() { Price = 50 };

            //act
            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            //Assert
            Assert.Equal(40, result);
        }

        [Fact]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            //Arrange
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);
            Product product = new Product() { Price = 50 };

            //act
            var result = product.GetPrice(customer.Object);

            //Assert
            Assert.Equal(40, result);
        }
    }

}
