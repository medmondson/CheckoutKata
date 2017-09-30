using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKata
{
    public class Repository:IRepository
    {
        private readonly IEnumerable<Item> _inventory;

        public Repository(IEnumerable<Item> inventory)
        {
            _inventory = inventory;
        }

        public Item GetItem(string scannedItem)
        {
                Item item = _inventory
                    .Where(i => i.SKU == scannedItem)
                    .Select(i => i).Single();

                return item;
        }

        public bool ContainsSpecialOffer(string scannedItem)
        {
            bool query = _inventory
                .Where(i => i.SKU == scannedItem)
                .Any(i => i.SpecialOffer != null);

            return query;
        }
    }
}
