using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        private readonly IList<OrderItem> _items;
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        private readonly IList<Delivery> _deliveries;
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void AddItem(Product product, decimal quantity)
        {
            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} nao tem {quantity} items em estoque.");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }

        public void Pay()
        {
            // Fazer pagamento
            Status = EOrderStatus.Paid;

            // a cada 5 produtos eh uma nova entrega
            var deliveries = new List<Delivery>();
            var delivery = new Delivery(DateTime.Now.AddDays(5));
            deliveries.Add(delivery);
            var count = 0;

            foreach( var item in _items)
            {
                if(count == 5)
                {
                    count = 0;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            deliveries.ForEach(x =>  _deliveries.Add(x));
        }

        public void Ship()
        {
            _deliveries.ToList().ForEach( x => x.Ship());
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }

        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (!_items.Any())
                AddNotification("Produto", "Nao tem produtos nesse pedido.");
        }
    }
}