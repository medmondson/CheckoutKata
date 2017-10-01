using System;
using CheckoutKata;

namespace Checout
{
    class Program
    {
        static void Main()
        {
            Database ds = new Database();
            Checkout co = new Checkout(new Repository(ds));

            Console.WriteLine("Begin scanning items. Type 'Total' when complete");

            bool scanning = true;

            while (scanning)
            {
                var input = Console.ReadLine();

                if (input != "Total")
                {
                    co.Scan(input);
                }
                else
                {
                    scanning = false;

                    var totalprice = co.GetTotalPrice();
                    Console.WriteLine($"The total price is: {totalprice}");
                    Console.Read();
                }
            }
        }
    }
}
