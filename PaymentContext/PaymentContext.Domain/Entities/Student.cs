using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(FullName fullName, Document document, Email email)
        {
            FullName = fullName; 
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(fullName, document, email);
        }

        public FullName FullName { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {

            var hasSubscriptionActive = false;

            foreach (var item in _subscriptions)
            {
                if (item.Active)
                    hasSubscriptionActive = true;
            }

            if (!hasSubscriptionActive)
                _subscriptions.Add(subscription);

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você ja tem uma assinatura ativa")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscriptions.Payments", 
                    "Esta assinatura não possui pagamentos")
                
            );  
        }
    }


}