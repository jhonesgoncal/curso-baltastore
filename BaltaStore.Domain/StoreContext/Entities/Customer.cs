using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.Entities;
using BaltaStore.Domain.ValuesObjects;
using BaltaStore.Shared.Entities;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {

        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _address = new List<Address>();

            AddNotifications(Name.Notifications);
            AddNotifications(Document.Notifications);
            AddNotifications(Email.Notifications);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }

        private readonly IList<Address> _address;
        public IReadOnlyCollection<Address> Addresses => _address.ToArray();  

        public void AddAddress(Address address)
        {
            // validate

            _address.Add(address);
        }
       
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}