using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Exception;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKata
{
    public class Repository:IRepository
    {
        private readonly IEnumerable<Item> _inventory;

        public Repository(IDataSource dataSource)
        {
            _inventory = dataSource.Inventory;
        }

        public Item GetItem(string scannedItem)
        {
                Item item = _inventory
                    .Where(i => i.SKU == scannedItem)
                    .Select(i => i).SingleOrDefault();

            if (item == null)
            {
                throw new ItemNotRecognisedException();
            }

                return item;
        }

        public bool ContainsSpecialOffer(Item scannedItem)
        {
            return scannedItem.SpecialOffer != null;
        }
    }
}
