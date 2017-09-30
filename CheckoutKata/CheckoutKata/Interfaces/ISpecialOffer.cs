namespace CheckoutKata.Interfaces
{
    public interface ISpecialOffer
    {
        int Qty { get; set; }
        decimal SpecialPrice { get; set; }
    }
}