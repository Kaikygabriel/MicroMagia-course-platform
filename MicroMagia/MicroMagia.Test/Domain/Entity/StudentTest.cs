using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Exceptions;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Domain.Entity;

public class StudentTest
{
     private readonly User UserValid = new(new Email("teste@gmail.com"), "skaldjflajdk");
     
     private const string? NameNull = null; 
     [Fact]
     public void Should_Return_Exception_If_NameIsNull()
     {
          Assert.Throws<StudentException>(()
               => new Student(NameNull,UserValid));
     }
     
     private const string NameSmall = "te";
     [Fact]
     public void Should_Return_Exception_If_NameSmall()
     {
          Assert.Throws<StudentException>(()
               => new Student(NameSmall,UserValid));
     }
     
     private const string NameValid= "teste";
     [Fact]
     public void Should_Return_NotNull_If_NameValid()
     {
          var student = new Student(NameValid, UserValid);
          Assert.NotNull(student);
     }
     
     [Fact] 
     public void Should_ConvertStudent_For_Premium()
     {
        var student = new Student(NameValid, UserValid);
        student.ConvertToPremium();
        Assert.True(student.IsPremium);
     }
}