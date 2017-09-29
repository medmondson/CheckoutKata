using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout:ICheckout
    {
        private readonly Dictionary<string, decimal> _inventory;
        private readonly List<string> _items;

        public Checkout(Dictionary<string, decimal> inventory)
        {
            _inventory = inventory;
            _items = new List<string>();
        }

        public void Scan(string item)
        {
            _items.Add(item);
        }

        public decimal GetTotalPrice()
        {
            decimal amount = 0;

            foreach (var item in _items)
            {
                decimal itemValue = _inventory
                                    .Where(i => i.Key == item)
                                    .Select(i => i.Value)
                                    .Sum();

                amount = amount + itemValue;
            }

            return amount;
        }
    }
}
