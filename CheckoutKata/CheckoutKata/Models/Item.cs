using CheckoutKata.Interfaces;

namespace CheckoutKata.Models
{
    public class Item
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public ISpecialOffer SpecialOffer { get; set; }
    }
}