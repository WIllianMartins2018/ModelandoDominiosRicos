using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class CreateCreditCardSubscriptionCommandTests
{

    [TestMethod]
    public void ShouldReturnErrorWhenHadTotalIsInvalid()
    {
        var command = new CreateCreditCardSubscriptionCommand();
        command.Total = -1;

        command.Validate();

        Assert.AreEqual(false, command.IsValid);
    }

}