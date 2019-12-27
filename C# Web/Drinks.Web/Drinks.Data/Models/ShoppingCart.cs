using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Drinks.Data.Models
{
    public class ShoppingCart
    {
        private readonly DrinksDbContext context;

        public ShoppingCart(DrinksDbContext context)
        {
            this.context = context;
        }
        public string Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<DrinksDbContext>();
            string cartId = session.GetString("CartId")
                            ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { Id = cartId };
        }

        public void AddToCart(Drink drink, int amount)
        {
            var shoppingCartItem = this.context.ShoppingCartItems.SingleOrDefault(
                s => s.Drink.Id == drink.Id && s.ShoppingCartId == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = Id,
                    Drink = drink,
                    Amount = amount
                };

                this.context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            this.context.SaveChanges();
        }

        public int RemoveFromCart(Drink drink)
        {

            var shoppingCartItem = this.context.ShoppingCartItems.SingleOrDefault(
                s => s.Drink.Id == drink.Id && s.ShoppingCartId == Id);

            var localAmount = 0;

            if (shoppingCartItem != null && shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                this.context.ShoppingCartItems.Remove(shoppingCartItem);
            }

            this.context.SaveChanges();
            return localAmount;

        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       this.context.ShoppingCartItems.Where(c => c.ShoppingCartId == Id)
                           .Include(s => s.Drink)
                           .ToList());
        }
        public void ClearCart()
        {
            var cartItems = this.context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == Id);

            this.context.ShoppingCartItems.RemoveRange(cartItems);

            this.context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = this.context.ShoppingCartItems.Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Drink.Price * c.Amount).Sum();
            return total;
        }
    }
}
