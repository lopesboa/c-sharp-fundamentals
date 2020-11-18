using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      Name = name;
    }

    public void AddLetterGrade(char letter)
    {
      switch (letter)
      {
        case 'A':
          AddGrade(90);
          break;
        case 'B':
          AddGrade(80);
          break;
        case 'C':
          AddGrade(70);
          break;
        default:
          AddGrade(0);
          break;
      }
    }
    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        grades.Add(grade);
      }
      else
      {
        Console.WriteLine("Invalid value");
      }
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Avarage = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;


      //FOREACH
      // var index = 0;
      // foreach (var grade in grades)
      // {
      //   result.Low = Math.Min(grade, result.Low);
      //   result.High = Math.Max(grade, result.High);
      //   result.Avarage += grade;
      // }

      // WHILE & DO LOOP
      // do
      // {
      //   result.Low = Math.Min(grades[index], result.Low);
      //   result.High = Math.Max(grades[index], result.High);
      //   result.Avarage += grades[index];
      //   index++;
      // } while(index < grades.Count);

      // while (index < grades.Count)
      // {
      //   result.Low = Math.Min(grades[index], result.Low);
      //   result.High = Math.Max(grades[index], result.High);
      //   result.Avarage += grades[index];
      //   index++;
      // }

      //FOR LOOP
      for (var index = 0; index < grades.Count; index++)
      {
        result.Low = Math.Min(grades[index], result.Low);
        result.High = Math.Max(grades[index], result.High);
        result.Avarage += grades[index];
      }
      result.Avarage /= grades.Count;

      return result;

    }

    private List<double> grades;
    public string Name;
  }
}