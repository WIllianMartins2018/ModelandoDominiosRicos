using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand : Notifiable<Notification>, ICommand
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }

        #region Dados Específicos da transação
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
        #endregion

        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Payer { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate() 
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "Total não pode ser zero")
            ); 
        }


    }
}