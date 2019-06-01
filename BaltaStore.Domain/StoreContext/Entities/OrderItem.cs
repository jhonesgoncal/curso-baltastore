using BaltaStore.Shared.Entities;
using Flunt.Notifications;
using System;

namespace BaltaStore.Domain.StoreContext.Entities 
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            Product.DecreaseQuantity(quantity);

            if (Product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Produto nao tem essa quantidade em estoque");
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        

    }
}