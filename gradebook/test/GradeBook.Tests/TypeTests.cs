using System;
using Xunit;

namespace GradeBook.Tests
{
  public class TypeTests
  {
    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
      var x = GetInt();
      SetInt(x);

      Assert.Equal(3, x);
    }
    [Fact]
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
    private void SetInt(int x)
    {
      x = 42;
    }
  }
}
