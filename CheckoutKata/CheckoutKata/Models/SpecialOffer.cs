using CheckoutKata.Interfaces;

namespace CheckoutKata.Models
{
    public class SpecialOffer : ISpecialOffer
    {
        public int Qty { get; set; }
        public decimal SpecialPrice { get; set; }
    }
}