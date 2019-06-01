using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;

namespace BaltaStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return new List<ListCustomerQueryResult>();
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            return new GetCustomerQueryResult();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return new CustomerOrdersCountResult();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return new List<ListCustomerOrdersQueryResult>();
        }

        public void Save(Customer customer)
        {
            
        }
    }
}