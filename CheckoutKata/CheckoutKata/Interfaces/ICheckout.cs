namespace CheckoutKata.Interfaces
{
    public interface ICheckout
    {
        void Scan(string item);
        decimal GetTotalPrice(); //modified to decimal
    }
}
