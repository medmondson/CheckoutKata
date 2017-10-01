# CheckoutKata

CheckoutKata written in a test-first fashion.

Also included is a console app to demonstrate functionality.  To use simply 'scan' each item (typing the SKU and return).  When complete type 'Total' and return.

![Alt text](/CheckoutConsole.png)

### Project notes

Interface to the checkout was modified as `int` isn't suitable for monetary values.

```cs
public interface ICheckout
    {
        void Scan(string item);
        decimal GetTotalPrice();
    }
```
