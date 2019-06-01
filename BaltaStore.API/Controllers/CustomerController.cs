using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.ValuesObjects;
using BaltaStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 60)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id:guid}")]
        public GetCustomerQueryResult Get(Guid id)
        {
           return _repository.Get(id);
        }

        [HttpGet]
        [Route("v1/customers/{id:guid}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            return _handler.Handler(command);
        }

        // [HttpPost]
        // [Route("customers/{id:guid}")]
        // public Customer Put([FromBody]CreateCustomerCommand command)
        // {
        //      var name = new Name(command.FirstName, command.LastName);
        //     var document = new Document(command.Document);
        //     var email = new Email(command.Email);

        //     var customer = new Customer(name, document, email, command.Phone);
        //     return customer;
        // }

        // [HttpPost]
        // [Route("customers/{id:guid}")]
        // public object Delete(Guid id)
        // {
        //     return new { Message = "cliente removido com sucesso" };
        // }
    }
}