using System;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities 
{
    public class Delivery : Entity
    {

        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            // validar data
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            if(Status != EDeliveryStatus.Delivered)
                Status = EDeliveryStatus.Canceled;
        }
    }
}