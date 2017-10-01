using System.Collections.Generic;
using CheckoutKata.Models;

namespace CheckoutKata.Interfaces
{
    public interface IDataSource
    {
        IEnumerable<Item> Inventory { get; set; }
    }
}