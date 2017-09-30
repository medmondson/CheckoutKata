using System.Collections.Generic;
using NUnit.Framework;
using CheckoutKata;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private IRepository _repository;

        [SetUp]
        public void Setup()
        {
            var items = new List<Item>
            {
                new Item{SKU = "A", Price = 50m, SpecialOffer = new SpecialOffer {Qty = 3, SpecialPrice = 130m}},
                new Item{SKU = "B", Price = 30m, SpecialOffer = new SpecialOffer {Qty = 2, SpecialPrice = 45m}},
                new Item{SKU = "C", Price = 20m}
            };

            _repository = new Repository(items);
        }

        //test adding twice to dictionary

        [Test]
        public void SingleItemA_ExpectItemTotal()
        {
            //Arrange
            ICheckout checkout = new Checkout(_repository);

            //Act
            checkout.Scan("A");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(50m, total);
        }

        [Test]
        public void SingleItemC_ExpectItemTotal()
        {
            //Arrange
            ICheckout checkout = new Checkout(_repository);

            //Act
            checkout.Scan("C");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(20m, total);
        }

        [Test]
        public void TwoItems_WithoutSpecialOffer_ExpectItemsTotal()
        {
            //Arrange
            ICheckout checkout = new Checkout(_repository);

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
            ICheckout checkout = new Checkout(_repository);

            //Act
            checkout.Scan("A");
            checkout.Scan("A");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(100m, total);
        }

        [Test]
        public void TwoIdenticalItems_WithSpecialOffer_ExpectTotalToReflectOffer()
        {
            //Arrange
            ICheckout checkout = new Checkout(_repository);

            //Act
            checkout.Scan("B");
            checkout.Scan("B");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(45m, total);
        }
    }
}
