using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class FullName : ValueObject
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNullOrEmpty(FirstName, "FullName.FirsName", "Nome Inválido")
                .IsNullOrEmpty(LastName, "FullName.LastName", "Sobrenome Inválido")
            );        
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}