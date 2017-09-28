using NUnit.Framework;
using CheckoutKata;

namespace CheckoutKataTests
{
    [TestFixture]
    public class UnitTest1
    {
        //SimplePrice 

        [Test]
        public void SingleItemA_ExpectTotal50()
        {
            //Arrange
            ICheckout checkout = new Checkout();
            checkout.Scan("A");

            //Act
            int total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(total, 50);
        }
    }
}
