using System;
using System.Collections.Generic;

namespace GradeBook
{

  public delegate void GradeAddedDelegate(object sender, EventArgs args);


  public class NameObject
  {
    public NameObject(string name)
    {
      Name = name;
    }
    public string Name
    {
      get;
      set;
    }
  }

  public class Book : NameObject
  {
    public Book(string name) : base(name)
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
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    public event GradeAddedDelegate GradeAdded;
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

      switch (result.Avarage)
      {
        case var d when d >= 90.0:
          result.Letter = 'A';
          break;
        case var d when d >= 80.0:
          result.Letter = 'B';
          break;
        case var d when d >= 70.0:
          result.Letter = 'C';
          break;
        case var d when d >= 60.0:
          result.Letter = 'D';
          break;
        case var d when d >= 50.0:
          result.Letter = 'E';
          break;
        default:
          result.Letter = 'F';
          break;
      }

      return result;

    }

    private List<double> grades;

    //Long hand syntax
    // public string Name
    // {
    //   get
    //   {
    //     return name;
    //   }

    //   set
    //   {
    //     if (!string.IsNullOrEmpty(value))
    //     {
    //       name = value;
    //     }
    //   }
    // }

    private string name;
    // readonly string category = "Science";
    public const string CATEGORY = "Science";

  }
}