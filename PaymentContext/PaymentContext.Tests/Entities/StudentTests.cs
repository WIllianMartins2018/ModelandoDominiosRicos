using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    private readonly Student _student;
    private readonly Subscription _subscription;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly FullName _name;

    public StudentTests()
    {
        _name = new FullName("Bruce", "Wine");
        _document = new Document("00000000000", EDocumentType.CPF);
        _email = new Email("brucewine@balta.com.br");
        _address = new Address("Rua X", "1", "Centro", "City", "State", "Country", "00000");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);

    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new BoletoPayment("1234", "10", DateTime.Now, DateTime.Now.AddDays(3), 10, 10,
    "Bruce", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
        var payment = new BoletoPayment("1234", "10", DateTime.Now, DateTime.Now.AddDays(3), 10, 10,
    "Bruce", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }

}