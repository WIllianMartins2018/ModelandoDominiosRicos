using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor

    [TestMethod]
    public void SouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    public void SouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("54762313000106", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);

    }

    [TestMethod]
    public void SouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    public void SouldReturnSuccessWhenCPFIsValid()
    {
        var doc = new Document("85518633041", EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}