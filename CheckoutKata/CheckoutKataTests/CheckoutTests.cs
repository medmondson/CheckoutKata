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
                new Item{SKU = "C", Price = 20m},
                new Item{SKU = "D", Price = 15m}
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
        public void TwoIdenticalItemsA_WithoutSpecialOffer_ExpectItemsTotal()
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
        public void TwoIdenticalItemsB_WithSpecialOffer_ExpectTotalToReflectOffer()
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

        [Test]
        public void MultipleItems_WithSpecialOffer_ExpectTotalToReflectOffer()
        {
            //Taken from requirements
            //B, an A, and another B, we’ll recognize the two Bs and price them at 45(for a total price so far of 95).

            //Arrange
            ICheckout checkout = new Checkout(_repository);

            //Act
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(95m, total);
        }

        [Test]
        public void MultipleItems_MultipleSpecialOffers_ExpectTotalToReflectOffer()
        {
            //Arrange
            ICheckout checkout = new Checkout(_repository);

            //Act
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(190m, total);
        }

        [Test]
        public void ManyItems_WithSpecialOffer_ExpectTotalToReflectOffer()
        {
            //Arrange
            ICheckout checkout = new Checkout(_repository);

            //Act
            checkout.Scan("B");
            checkout.Scan("D");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("A");
            checkout.Scan("D");
            checkout.Scan("B");
            checkout.Scan("D");
            checkout.Scan("A");
            checkout.Scan("C");
            checkout.Scan("B");
            checkout.Scan("D");
            checkout.Scan("C");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("C");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");

            //A = 6 = 260
            //B = 6 = 135
            //C = 4 = 80
            //D = 4 = 60
            //Total = 535

            decimal total = checkout.GetTotalPrice();

            //Assert
            Assert.AreEqual(535m, total);
        }
    }
}
