using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class FullName : ValueObject
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

             if (string.IsNullOrEmpty(FirstName))
                AddNotification("FirstName", "Nome Inválido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}