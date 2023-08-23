using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void TestMethod1()
    {
        var subscription = new Subscription(null);
        var student = new Student("Willian", "Martins", "000", "estudos@gmail.com");
        student.AddSubscription(subscription);

    }
}