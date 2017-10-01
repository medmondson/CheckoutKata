using System.Collections.Generic;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKata.DataSource
{
    public class DataSource : IDataSource
    {
        public IEnumerable<Item> Inventory { get; set; }
    }
}
