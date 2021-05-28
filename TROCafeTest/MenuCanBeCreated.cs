using System;
using Xunit;

namespace TROCafeTest
{
    public class MenuCanBeCreated
    {
        [Theory]
        [InlineData(0, "COFFEE", "Coffee", 1.50)]
        [InlineData(0, "TEA", "Tea", 1.20)]
        [InlineData(0, "HOTCHOC", "Hot Chocolate", 2.00)]
        [InlineData(0, "SUGAR", "Sugar", 0.10)]
        [InlineData(0, "MILK", "Milk", 0.30)]
        [InlineData(0, "MALLOWS", "Marshmallows", 0.60)]
        public void MenuCreation(int Id, string sku, string description, decimal cost)
        {

        }
    }
}
