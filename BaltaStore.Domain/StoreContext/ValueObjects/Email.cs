
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.ValuesObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "E-mail", "E-mail inv�lido")
            );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }

    }
}