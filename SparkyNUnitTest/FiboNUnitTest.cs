using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class FiboNUnitTest
    {
        [Test]
        public void FiboRange_InputRange_ReturnsListZero()
        {
            //arrange
            Fibo fib = new();
            fib.Range = 1;
            
            List<int> expectedRange = new() { 0 }; //5-10

            //act
            List<int> result = fib.GetFiboSeries();

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedRange));
            Assert.That(result, Is.Ordered);
            Assert.AreEqual(expectedRange, result);

            //Assert.That(result, Does.Contain(7));
            //Assert.That(result, Is.Not.Empty);
            //Assert.That(result.Count, Is.EqualTo(3));
            //Assert.That(result, Has.No.Member(6));
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);

        }

        [Test]
        public void FiboRange_InputRange_ReturnsListList()
        {
            //arrange
            Fibo fib = new();
            fib.Range = 6;

            List<int> expectedRange = new() { 0,1,1,2,3,5 }; //5-10

            //act
            List<int> result = fib.GetFiboSeries();

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedRange));
            //Assert.That(result, Is.Ordered);
            Assert.AreEqual(expectedRange, result);

            //Assert.That(result, Does.Contain(6));
            //Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Has.No.Member(4));
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);

        }
    }
}
