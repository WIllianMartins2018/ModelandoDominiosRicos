using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests;

[TestClass]
public class StudentQueriesTests
{
    private IList<Student>? _students;

    public StudentQueriesTests()
    {
        for (var i = 0; i <= 10; i++) {
            _students?.Add(new Student(
                new FullName("Aluno", i.ToString()),
                new Document("111111111" + i.ToString(), EDocumentType.CPF),
                new Email(i.ToString() + "@balta.io")
            ));
        }
    }


    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
        var exp = StudentQueries.GetStudentInfo("12345678911"); 
        var stun = _students?.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, stun);
    }
}