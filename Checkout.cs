using System;
namespace eCommerce
{
    public class Checkout : Cart
    {
        public Checkout(string Name, int Size) : private cart(Name, Size)
        {
              protected override bool CanTransportCart(Cart cart)
        }

        {
             return true;
        }
    }
}
