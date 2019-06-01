using System;
using System.Collections.Generic;
using BaltaStore.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }


        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
        public bool isValid()
        {
            AddNotifications(new Contract()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificiador do cliente invalido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
            );
            return base.Valid;

        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}