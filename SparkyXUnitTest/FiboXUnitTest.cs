using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    
    public class FiboXUnitTest
    {
        [Fact]
        public void FiboRange_InputRange_ReturnsListZero()
        {
            //arrange
            Fibo fib = new();
            fib.Range = 1;

            List<int> expectedRange = new() { 0 }; //5-10

            //act
            List<int> result = fib.GetFiboSeries();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedRange, result);
            Assert.True(result.SequenceEqual(expectedRange));
           

        }

        [Fact]
        public void FiboRange_InputRange_ReturnsListList()
        {
            //arrange
            Fibo fib = new();
            fib.Range = 6;

            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 }; //5-10

            //act
            List<int> result = fib.GetFiboSeries();

            //Assert
            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(expectedRange,result);
            Assert.True(result.SequenceEqual(expectedRange));



        }
    }
}
