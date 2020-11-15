namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Lopes Grade Book");
      book.AddGrade(89.3);
      book.AddGrade(90.5);
      book.AddGrade(77.5);
      book.ShowStatistics();
    }
  }
}
