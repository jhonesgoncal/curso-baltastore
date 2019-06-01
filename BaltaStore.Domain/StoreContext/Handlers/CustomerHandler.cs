using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.ValuesObjects;
using BaltaStore.Shared.Commands;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handler(CreateCustomerCommand command)
        {
            if(_repository.CheckDocument(command.Document)){
                AddNotification("Document", "Este CPF já esta em uso");
                return null;
            }

             if(_repository.CheckDocument(command.Email)){
                AddNotification("Email", "Este Email já esta em uso");
                return null;
            }
                

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(customer.Notifications);

            if(Invalid)
                return new CommandResult(true, "Por favor, corrija os erros", Notifications);

            _repository.Save(customer);

            _emailService.Send(email.Address, "contato@jhones.io", "Bem vindo", "bem vindo ao baltaStore");

            return new CommandResult(
                true,
                "Bem vindo ao Balta Store",
                new { Name = name.FirstName, Document= document.ToString(), Email = email.ToString()}
                );
        }

        public ICommandResult Handler(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}