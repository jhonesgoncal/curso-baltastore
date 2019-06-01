
using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Domain.ValuesObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome precisa ter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome precisa ter no maximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome precisa ter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 100, "LastName", "O sobrenome precisa ter no maximo 100 caracteres")
            );
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}