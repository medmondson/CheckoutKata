using System.Collections.Generic;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;

namespace Checkout
{
    public class Database : IDataSource
    {
        public IEnumerable<Item> Inventory { get; set; }

        public Database()
        {
            Inventory = new List<Item>
                {
                    new Item{SKU = "A", Price = 50m, SpecialOffer = new SpecialOffer {Qty = 3, SpecialPrice = 130m}},
                    new Item{SKU = "B", Price = 30m, SpecialOffer = new SpecialOffer {Qty = 2, SpecialPrice = 45m}},
                    new Item{SKU = "C", Price = 20m},
                    new Item{SKU = "D", Price = 15m}
                };
        }
    }
}
