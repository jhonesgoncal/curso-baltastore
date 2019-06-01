using BaltaStore.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool isValid()
        {
            AddNotifications(new Contract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome precisa ter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome precisa ter no maximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome precisa ter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 100, "LastName", "O sobrenome precisa ter no maximo 100 caracteres")
                .IsEmail(Email, "E-mail", "E-mail inválido")
                .HasLen(Document, 11, "Document", "CPF invalido")
            );
            return base.Valid; 
        }
    }
}