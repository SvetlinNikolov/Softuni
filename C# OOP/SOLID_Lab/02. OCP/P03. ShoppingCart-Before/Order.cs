namespace P03._ShoppingCart
{
    public abstract class Order
    {
        protected readonly Cart cart;
        private decimal totalPrice;
        public Order(Cart cart)
        {
            this.cart = cart;
        }

        
        public virtual void Checkout()
        {
        }
    }
}
