using CheckoutKata.Models;

namespace CheckoutKata.Interfaces
{
    public interface IRepository
    {
        Item GetItem(string scannedItem);
        bool ContainsSpecialOffer(string scannedItem);
    }
}
