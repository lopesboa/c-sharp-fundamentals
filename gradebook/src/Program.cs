using System;
using System.Collections.Generic;

namespace src
{
  class Program
  {
    static void Main(string[] args)
    {
    //   var numbers = new[] { 3, 12.2, 56.3 };
      var grades = new List<double>() { 3, 12.2, 56.3 };
      grades.Add(9.8);
    //   grades.Count;
      var result = 0.0;

      foreach (double number in grades)
      {
        result += number;
      }
      Console.WriteLine(result);
      result /= grades.Count;
      Console.WriteLine($"The avarage grade is {result:N2}");

      if (args.Length > 0)
      {
        Console.WriteLine($"Hello {args[0]}!");
      }
      else
      {
        Console.WriteLine("Hello World!");
      }
    }
  }
}
