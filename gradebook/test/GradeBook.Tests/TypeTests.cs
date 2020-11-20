using System;
using Xunit;

namespace GradeBook.Tests
{

  public delegate string WriteLogDelegate(string logMessage);

  public class TypeTests
  {
    int count = 0;

    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
      WriteLogDelegate log = ReturnMessage;
      log += ReturnMessage;
      log += IncrementCount;

      var result = log("Hello");

      Assert.Equal(3, count);
    }
    string IncrementCount(string message)
    {
      count++;
      return message;
    }
    string ReturnMessage(string message)
    {
      count++;
      return message;
    }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
      var x = GetInt();
      SetInt(ref x);

      Assert.Equal(42, x);
    }
    [Fact(DisplayName = "CSharpCanPassByRef")]
    public void CSharpCanPassByRef()
    {
      var book1 = GetBook("Book 1");
      GetBookAndSetNameByRef(out book1, "New book");

      Assert.Equal("New book", book1.Name);
    }
    [Fact]
    public void CSharpPssByValue()
    {
      var book1 = GetBook("Book 1");
      GetBookAndSetName(book1, "New book");

      Assert.Equal("Book 1", book1.Name);
    }
    [Fact]
    public void CanSetNameFromReference()
    {
      var book1 = GetBook("Book 1");
      SetName(book1, "New book name");

      Assert.Equal("New book name", book1.Name);
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
      Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
      var book1 = GetBook("Book 1");
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));
    }
    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
      string name = "Lopes";
      var upper = MakeUpperCase(name);

      Assert.Equal("Lopes", name);
      Assert.Equal("LOPES", upper);
    }

    Book GetBook(string name)
    {
      return new Book(name);
    }

    private void SetName(Book book, string name)
    {
      book.Name = name;
    }
    private void GetBookAndSetName(Book book, string name)
    {
      book = new Book(name);
    }
    private void GetBookAndSetNameByRef(out Book book, string name)
    {
      book = new Book(name);
    }
    private int GetInt()
    {
      return 3;
    }
    private void SetInt(ref int x)
    {
      x = 42;
    }
    private string MakeUpperCase(string parameter)
    {
      return parameter.ToUpper();
    }
  }
}
