using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly IRepository _repository;
        private readonly List<string> _scannedItems;

        public Checkout(IRepository repository)
        {
            _repository = repository;
            _scannedItems = new List<string>();
        }

        public void Scan(string item)
        {
            _scannedItems.Add(item);
        }

        public decimal GetTotalPrice()
        {
            decimal amount = 0;

            var specialOffers = new List<Item>();

            foreach (var scannedItem in _scannedItems)
            {
                var item = _repository.GetItem(scannedItem);
               
                if (_repository.ContainsSpecialOffer(scannedItem))
                {
                    specialOffers.Add(item);
                }
                else
                {
                    amount = amount + item.Price;
                }
            }

            decimal specialOfferValue = CalculateSpecialOfferValue(specialOffers);

            return amount + specialOfferValue;
        }

        private decimal CalculateSpecialOfferValue(IEnumerable<Item> specialOffer)
        {
            var specialOfferValue = 0m;

            var query = specialOffer.GroupBy(x => new{x.SKU, x.Price});

            foreach (var itemGroup in query)
            {
                var groupCount = itemGroup.Count();

                var offer = itemGroup.Select(x => x.SpecialOffer).First();

                var howManyDeals = groupCount / offer.Qty;
                var nonDeals = groupCount % offer.Qty;

                var dealValue = howManyDeals * offer.SpecialPrice;
                var nonDealValue = nonDeals * itemGroup.Key.Price;

                specialOfferValue = specialOfferValue + dealValue + nonDealValue;

            }

            return specialOfferValue;

        }

    }
}
