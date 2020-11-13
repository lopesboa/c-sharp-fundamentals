using System;

namespace src
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new [] {3,12.2,56.3};
      var result = 0.0;
      
      foreach (double number in numbers)
      {
          
      }

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
