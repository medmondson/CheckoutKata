using System.Collections.Generic;
using NUnit.Framework;
using CheckoutKata;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Dictionary<string, decimal> _items;

        [SetUp]
        public void Setup()
        {
            _items = new Dictionary<string, decimal>
            {
                { "A", 50m},
                { "B", 30m}
            };
        }

        [Test]
        public void SingleItemA_ExpectItemTotal()
        {
            //Arrange
            ICheckout checkout = new Checkout(_items);

            //Act
            checkout.Scan("A");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(50m, total);
        }

        [Test]
        public void TwoItems_WithoutSpecialOffer_ExpectItemsTotal()
        {
            //Arrange
            ICheckout checkout = new Checkout(_items);

            //Act
            checkout.Scan("A");
            checkout.Scan("B");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(80m, total);
        }

        [Test]
        public void TwoIdenticalItems_WithoutSpecialOffer_ExpectItemsTotal()
        {
            //Arrange
            ICheckout checkout = new Checkout(_items);

            //Act
            checkout.Scan("A");
            checkout.Scan("A");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(100m, total);
        }
    }
}
