using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests;

[TestClass]
public class SubscriptionHandlerTest
{

    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateCreditCardSubscriptionCommand();
        command.FirstName = "Bruce";
        command.LastName = "Wayne";
        command.Document = "00000000000";
        command.PayerEmail = "hello@balta.io2";
        command.CardHolderName = "Bruce W ";
        command.CardNumber = "123456789";
        command.LastTransactionNumber = "12345";
        command.PaymentNumber = "123121";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "WAYNE CORP";
        command.PayerDocument = "12345678911";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "batman@dc.com";
        command.Street = "asdas";
        command.Number = "asdd";
        command.Neighborhood = "asdasd";
        command.City = "as";
        command.State = "as";
        command.Country = "as";
        command.ZipCode = "12345678";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }
}