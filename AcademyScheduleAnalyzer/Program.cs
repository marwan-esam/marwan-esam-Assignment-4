using System.Buffers;
using System.Data.Common;
using System.Security.Cryptography;

class Program
{

  public static void DisplaySession(string sessionName, DateTime sessionDate, int sessionDuration)
  {
    Console.WriteLine(sessionName);
    Console.WriteLine($"Date: {sessionDate.ToString("dd MMMM yyyy")}");
    Console.WriteLine($"Start Time: {sessionDate.ToString("hh:mm tt")}");
    Console.WriteLine($"Duration: {sessionDuration} minutes");
    Console.WriteLine();
  }
  public static void DisplayAllSessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
  {
    int numberOfSessions = sessionNames.Length;

    for(int i = 0 ; i < numberOfSessions ; i++)
    {
      Console.Write($"{i + 1}. ");
      DisplaySession(sessionNames[i], sessionDates[i], sessionDurations[i]);
    }
  }

  public static void SearchSessionByName(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations, string sessionName)
  {
    Predicate<string> equalsTargetSession = name => name == sessionName;
    int index = Array.FindIndex(sessionNames, 0, sessionNames.Length, equalsTargetSession);
    if(index != -1)
    {
      DisplaySession(sessionNames[index], sessionDates[index], sessionDurations[index]);
    } else
    {
      Console.WriteLine("Session not found.");
    }
  }
  public static void Main(string[] args)
  {
    string[] sessionNames =
    {
      "C# Basics",
      "Arrays",
      "Functions",
      "Date and Time",
      "Exception Handling"
    };

    DateTime[] sessionDates =
    {
      new DateTime(2026, 9, 10, 18, 0, 0),
      new DateTime(2026, 9, 13, 18, 0, 0),
      new DateTime(2026, 9, 17, 18, 0, 0),
      new DateTime(2026, 9, 20, 18, 0, 0),
      new DateTime(2026, 9, 24, 18, 0, 0)
    };

    int[] sessionDurations =
    {
      180,
      240,
      180,
      240,
      180
    };

    DisplayAllSessions(sessionNames, sessionDates, sessionDurations);

    SearchSessionByName(sessionNames, sessionDates, sessionDurations, "something");
  }
}