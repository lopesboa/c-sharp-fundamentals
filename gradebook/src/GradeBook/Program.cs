using System;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Lopes Grade Book");
      book.GradeAdded += OnGradeAdded;

      var done = false;
      while (!done)
      {
        Console.WriteLine("Insert a grade or press 'q' to quit");
        var input = Console.ReadLine();
        if (input == "q")
        {
          done = true;
          continue;
        }

        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          Console.WriteLine("**");
        }
      }

      var stats = book.GetStatistics();

      book.Name = "";

      Console.WriteLine(Book.CATEGORY);
      Console.WriteLine($"For the book named {book.Name}");
      Console.WriteLine($"The lowest grade is {stats.Low}");
      Console.WriteLine($"The highest grade is {stats.High}");
      Console.WriteLine($"The avarage grade is {stats.Avarage:N1}");
      Console.WriteLine($"The letter grade is {stats.Letter}");
    }

    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added");
    }
  }
}
