using System;

namespace src
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new double[3];
      numbers[0] = 12.9;
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
