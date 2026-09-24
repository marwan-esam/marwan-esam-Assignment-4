using System.Globalization;
using System.Text;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsTCPIP;
using TraceReloggerLib;

namespace AcademyScheduleAnalyzer;
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

  public static void SearchSessionByName(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
  {
    Console.Write("Enter session name: ");
    string? sessionName = Console.ReadLine();
    Predicate<string> equalsTargetSession = name => name.Equals(sessionName, StringComparison.OrdinalIgnoreCase);
    
    int index = Array.FindIndex(sessionNames, equalsTargetSession);
    if(index != -1)
    {
      DisplaySession(sessionNames[index], sessionDates[index], sessionDurations[index]);
    } else
    {
      Console.WriteLine("Session not found.");
    }
  }

  public static void SortSessionNames(string[] sessionNames)
  {
    string[] sessionNamesCopy = new string[sessionNames.Length];
    Array.Copy(sessionNames, sessionNamesCopy,sessionNames.Length);
    Array.Sort(sessionNamesCopy, StringComparer.CurrentCultureIgnoreCase);
    for (int i = 0; i < sessionNamesCopy.Length; i++)
    {
      Console.WriteLine(sessionNamesCopy[i]);
    }
  }

  public static void ReverseSessionNames(string[] sessionNames)
  {
    string[] sessionNamesCopy = new string[sessionNames.Length];
    Array.Copy(sessionNames, sessionNamesCopy, sessionNames.Length);
    Array.Reverse(sessionNamesCopy);
    foreach (string name in sessionNamesCopy)
    {
      Console.WriteLine(name);
    }
  }

  public static void FindSessionIndexUsingIndexOf(string[] sessionNames, string session)
  {
    int index = Array.IndexOf(sessionNames, session);
    if (index != -1)
    {
      Console.WriteLine($"Index: {index}");
    }
    else
    {
      Console.WriteLine("Session not found.");
    }

    Console.WriteLine();
  }

  public static void CheckSessionExistsUsingExists(string[] sessionNames)
  {
    Console.Write("Enter session name: ");
    string? targetSession = Console.ReadLine();
    Predicate<string> isTargetSession = session => session.Equals(targetSession, StringComparison.OrdinalIgnoreCase);
    try
    {
      bool isFound = Array.Exists(sessionNames, isTargetSession);
      if (isFound)
      {
        Console.WriteLine("Session exists.");
      }
      else
      {
        Console.WriteLine("Session does not exist.");
      }
    }
    catch (ArgumentNullException e)
    {
      Console.WriteLine("Cannot process array/input");
    }
  }

  public static void CheckSessionExistsUsingFind(string[] sessionNames, string targetSession)
  {
    Predicate<string> isSessionFound = session => session == targetSession;
    string? session = Array.Find(sessionNames, isSessionFound);

    if (session != null)
    {
      Console.WriteLine(session);
    }
    else
    {
      Console.WriteLine("Session not found.");
    }

    Console.WriteLine();
  }

  public static void FindSessionIndexUsingFindIndex(string[] sessionNames)
  {
    Console.Write("Enter session name: ");
    string? targetSession = Console.ReadLine();
    Predicate<string> isSessionFound = session => session.Equals(targetSession, StringComparison.OrdinalIgnoreCase);
    int index = Array.FindIndex(sessionNames, isSessionFound);
    if (index != -1)
    {
      Console.WriteLine($"Index: {index}");
    }
    else
    {
      Console.WriteLine("Session not found.");
    }
  }

  public static void CopyArray(string[] sessionNames)
  {
    string[] sessionNamesCopy = new string[sessionNames.Length];
    Array.Copy(sessionNames, sessionNamesCopy, sessionNames.Length);

    Console.WriteLine("Changing first element to 'Python Basics' in the copied array...\n");
    sessionNamesCopy[0] = "Python Basics";

    Console.WriteLine("Original Array:-");
    foreach (string name in sessionNames)
    {
      Console.WriteLine(name);
    }

    Console.WriteLine();
    
    Console.WriteLine("Copied Array:-");
    foreach (string name in sessionNamesCopy)
    {
      Console.WriteLine(name);
    }

    Console.WriteLine();
  }

  public static int GetTotalDuration(int[] sessionDurations)
  {
    int sum = 0;
    foreach(int duration in sessionDurations)
    {
      sum += duration;
    }
    return sum;
  }

  public static double GetAverageDuration(int[] sessionDurations)
  {
    return GetTotalDuration(sessionDurations) / (double)sessionDurations.Length;
  }

  public static int GetShortestDuration(int[] sessionDurations)
  {
    int shortestDuration = sessionDurations[0];
    foreach (int duration in sessionDurations)
    {
      if (duration < shortestDuration) shortestDuration = duration;
    }

    return shortestDuration;
  }

  public static int GetLongestDuration(int[] sessionDurations)
  {
    int largestDuration = sessionDurations[0];
    foreach (int duration in sessionDurations)
    {
      if (duration > largestDuration) largestDuration = duration;
    }

    return largestDuration;
  }

  public static void SortSessionDurations(int[] sessionDurations)
  {
    int[] sessionDurationsCopy = new int[sessionDurations.Length];
    Array.Copy(sessionDurations, sessionDurationsCopy, sessionDurations.Length);
    Array.Sort(sessionDurationsCopy);

    foreach (int duration in sessionDurationsCopy)
    {
      Console.WriteLine(duration);
    }

    Console.WriteLine();
  }

  public static void ChangeValueUsingRef(ref int value)
  {
    value = 10;
  }

  public static bool GetSessionIndexAndDurationUsingOut(string sessionName, string[] sessionNames, int[] sessionDurations
    ,out int sessionIndex, out int sessionDuration)
  {
    sessionIndex = Array.IndexOf(sessionNames, sessionName);
    if (sessionIndex != -1)
    {
      sessionDuration = sessionDurations[sessionIndex];
      return true;
    }
    sessionDuration = -1;
    return false;
  }

  public static void ChangeArrayElement(int[] arr)
  {
    arr[0] = 10;
  }

  public static int CalculateTotalDurations(params int[] durations)
  {
    int sum = 0;
    foreach (int duration in durations)
    {
      sum += duration;
    }

    return sum;
  }

  public static int GetSessionIndex(string[] sessions, string? targetSession)
  {
    int index = Array.FindIndex(sessions, session => session.Equals(targetSession, StringComparison.OrdinalIgnoreCase));
    return index;
  }

  public static void DisplaySessionDateDetails(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
  {
    Console.Write("Enter session name: ");
    string? session = Console.ReadLine();
    try
    {
      int index = GetSessionIndex(sessionNames, session);
      if (index != -1)
      {
        Console.WriteLine($"Session: {sessionNames[index]}\n");
        Console.WriteLine($"Date: {sessionDates[index].ToString("dd MMMM yyyy")}");
        Console.WriteLine($"Day: {sessionDates[index].DayOfWeek}");
        Console.WriteLine($"Year: {sessionDates[index].Year}");
        Console.WriteLine($"Month: {sessionDates[index].Month}");
        Console.WriteLine($"Day Number: {sessionDates[index].Day}");
        Console.WriteLine($"Start Time: {sessionDates[index].ToString("hh:mm tt")}");
        Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
        Console.WriteLine($"End Time: {sessionDates[index].AddMinutes(sessionDurations[index]).ToString("hh:mm tt")}");
      }
      else
      {
        Console.WriteLine("Session not found.");
      }
    }
    catch (ArgumentNullException e)
    {
      Console.WriteLine("Cannot process array/input");
    }
  }

  public static void DisplayDatesDifference(string[] sessionNames, DateTime[] sessionDates)
  {
    Console.Write("Enter first session name: ");
    string? firstSession = Console.ReadLine();
    Console.Write("Enter second session name: ");
    string? secondSession = Console.ReadLine();
    try
    {
      int firstSessionIndex = GetSessionIndex(sessionNames, firstSession);
      int secondSessionIndex = GetSessionIndex(sessionNames, secondSession);
      if (firstSessionIndex != -1 && secondSessionIndex != -1)
      {
        DateTime firstSessionDate = sessionDates[firstSessionIndex];
        DateTime secondSessionDate = sessionDates[secondSessionIndex];
        int isDateEarlier = DateTime.Compare(firstSessionDate, secondSessionDate);

        TimeSpan dateDifference =
          isDateEarlier < 0 ? secondSessionDate - firstSessionDate : firstSessionDate - secondSessionDate;
        Console.WriteLine($"First Session: {sessionNames[firstSessionIndex]}");
        Console.WriteLine($"Second Session: {sessionNames[secondSessionIndex]}");
        Console.WriteLine();
        Console.WriteLine("Difference:");
        Console.WriteLine($"{dateDifference.TotalDays} days");
        Console.WriteLine($"{dateDifference.TotalHours} hours");
      }
      else
      {
        Console.WriteLine("First Session and/or Second Session not found.");
      }
    }
    catch (ArgumentNullException e)
    {
      Console.WriteLine("Cannot process array/input");
    }
  }

  public static void DisplaySessionDatesStatus(string[] sessionNames, DateTime[] sessionDates)
  {
    for (int i = 0; i < sessionNames.Length; i++)
    {
      bool isDateUpcoming = sessionDates[i] > DateTime.Now;
      Console.WriteLine($"{sessionNames[i]} {(isDateUpcoming ? "Upcoming" : "Past")}");
    }
  }

  public static void FindNextSession(string[] sessionNames, DateTime[] sessionDates)
  {
    int nextSessionIndex = -1;
    DateTime? nextSessionDate = null;
    DateTime currentTime = DateTime.Now;
    
    for (int i = 0; i < sessionDates.Length; i++)
    {
      if (sessionDates[i] > currentTime)
      {
        if (nextSessionDate == null || sessionDates[i] < nextSessionDate)
        {
          nextSessionDate = sessionDates[i];
          nextSessionIndex = i;
        }
      }
    }

    if (nextSessionIndex != -1)
    {
      string nextSessionName = sessionNames[nextSessionIndex];
      TimeSpan? timeRemaining = nextSessionDate - currentTime;
      Console.WriteLine("Next Session:\n");
      Console.WriteLine($"{nextSessionName}");
      Console.WriteLine($"{nextSessionDate?.ToString("dd MMMM yyyy")}");
      Console.WriteLine($"{nextSessionDate?.ToString("hh:mm tt")}");
      Console.WriteLine("\nTime Remaining:");
      Console.WriteLine($"{timeRemaining?.Days} days");
      Console.WriteLine($"{timeRemaining?.Hours} hours");
    }
    else
    {
      Console.WriteLine("No upcoming session after current date and time.");
    }
  }

  public static void DisplaySessionDateFormats(string sessionName, DateTime[] sessionDates, string[] sessionNames)
  {
    int index = Array.IndexOf(sessionNames, sessionName);
    if (index != -1)
    {
      Console.WriteLine(sessionDates[index].ToString("yyyy-MM-dd"));
      Console.WriteLine(sessionDates[index].ToString("dd/MM/yyyy"));
      Console.WriteLine(sessionDates[index].ToString("dd MMMM yyyy"));
      Console.WriteLine(sessionDates[index].ToString("dddd, dd MMMM yyyy"));
      Console.WriteLine(sessionDates[index].ToString("hh:mm tt"));
    }
    else
    {
      Console.WriteLine("Session not found.");
    }

    Console.WriteLine();
  }

  public static DateTime ReadFormattedDate()
  {
    const string dateFormat = "yyyy-MM-dd HH:mm";
    while (true)
    {
      Console.Write($"Enter a date in this format ({dateFormat}): ");
      string? unformattedDate = Console.ReadLine();
      
      bool isFormatCorrect = DateTime.TryParseExact(unformattedDate, dateFormat, null,
        DateTimeStyles.None, out DateTime formattedDate);
      if (isFormatCorrect)
      {
        Console.WriteLine("\nValid format. Date stored successfully.\n");
        return formattedDate;
      }

      Console.WriteLine($"\nIncorrect Date Format. Please enter a date in the following format: {dateFormat}\n" +
                        $"An example would be: {DateTime.Now.ToString(dateFormat)} (Note: hours must be entered in " +
                        $"24-hour format.)\n");
    }
  }

  public static int HandleNumericInput()
  {
    while (true)
    {
      string? unparsedInput = Console.ReadLine();
      try
      {
        int parsedInput = int.Parse(unparsedInput);
        if (parsedInput < 0 || parsedInput > 16)
        {
          throw new InvalidDataException();
        }

        return parsedInput;
      }
      catch (Exception e) when (e is FormatException || e is InvalidDataException)
      {
        Console.WriteLine("Invalid menu option. Enter an integer between 0 and 16");
        Console.Write("Enter a correct option: ");
      }
    }
    
  }

  public static string GetSessionName(string[] sessionNames)
  {
    while (true)
    {
      try
      {
        Console.Write("Enter session index: ");
        int? index = int.Parse(Console.ReadLine()!);
        string session = sessionNames[(int)index];
        Console.WriteLine($"\nSession: {session}");
        return session;
      }
      catch (IndexOutOfRangeException e)
      {
        Console.WriteLine(
          $"The selected session index is out of range. Correct range is from 0 to {sessionNames.Length - 1}");
      }
      catch (ArgumentNullException e)
      {
        Console.WriteLine($"Failed to process input. Error: {e.Message}");
      }
      catch (FormatException e)
      {
        Console.WriteLine("Invalid input format. please enter a number");
      }
      finally
      {
        Console.WriteLine("Input operation finished.");
      }
    }
  }

  public static int ValidateSessionDuration()
  {
    Console.Write("Enter duration: ");
    bool isValidDuration = int.TryParse(Console.ReadLine(), out int duration);
    if (!isValidDuration || duration <= 0) throw new ArgumentException("Duration must be an integer greater than zero.");
    Console.WriteLine("Duration accepted.");
    return duration;
  }

  public static string BuildScheduleReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
  {
    string result = "";
    int size = sessionNames.Length;
    for (int i = 0; i < size; i++)
    {
      result += $"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDurations[i]} minutes\n";
    }

    return result;
  }

  public static string BuildScheduleReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates,
    int[] sessionDurations)
  {
    StringBuilder result = new StringBuilder();
    int size = sessionNames.Length;
    for (int i = 0; i < size; i++)
    {
      result.Append(
        $"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDurations[i]} minutes\n");
    }

    return result.ToString();
  }

  public static void DisplayDurationStatistics(int[] sessionDurations)
  {
    Console.WriteLine($"Total duration: {GetTotalDuration(sessionDurations)}");
    Console.WriteLine($"Longest duration: {GetLongestDuration(sessionDurations)}");
    Console.WriteLine($"Shortest duration: {GetShortestDuration(sessionDurations)}");
    Console.WriteLine($"Average duration: {GetAverageDuration(sessionDurations)}");
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
    
    string menu = """
                  ===================================
                  Academy Schedule Analyzer
                  ===================================
                  1. Display all sessions
                  2. Search for a session
                  3. Sort session names
                  4. Reverse session names
                  5. Find session index
                  6. Check if session exists
                  7. Show duration statistics
                  8. Show session date details
                  9. Show past and upcoming sessions
                  10. Find next session
                  11. Compare two session dates
                  12. Read and validate a custom date
                  13. Select session by index
                  14. Validate session duration
                  15. Generate report using string
                  16. Generate report using StringBuilder
                  0. Exit

                  Choose an option: 
                  """;
    bool isRunning = true;
    while (isRunning)
    {
      Console.Write(menu);
      int choice = HandleNumericInput();
      Console.WriteLine();
      switch (choice)
      {
        case 0:
          Console.WriteLine("Exiting application...");
          isRunning = false;
          break;
        case 1:
          DisplayAllSessions(sessionNames, sessionDates, sessionDurations);
          break;
        case 2:
          SearchSessionByName(sessionNames, sessionDates, sessionDurations);
          break;
        case 3:
          SortSessionNames(sessionNames);
          break;
        case 4:
          ReverseSessionNames(sessionNames);
          break;
        case 5:
          FindSessionIndexUsingFindIndex(sessionNames);
          break;
        case 6:
          CheckSessionExistsUsingExists(sessionNames);
          break;
        case 7:
          DisplayDurationStatistics(sessionDurations);
          break;
        case 8:
          DisplaySessionDateDetails(sessionNames, sessionDates, sessionDurations);
          break;
        case 9:
          DisplaySessionDatesStatus(sessionNames, sessionDates);
          break;
        case 10:
          FindNextSession(sessionNames, sessionDates);
          break;
        case 11:
          DisplayDatesDifference(sessionNames, sessionDates);
          break;
        case 12:
          ReadFormattedDate();
          break;
        case 13:
          GetSessionName(sessionNames);
          break;
        case 14:
          try
          {
            int duration = ValidateSessionDuration();
            Console.WriteLine($"{duration} is a valid duration");
          }
          catch (ArgumentException e)
          {
            Console.WriteLine(e.Message);
          }

          break;
        case 15:
          Console.WriteLine(BuildScheduleReportUsingString(sessionNames, sessionDates, sessionDurations));
          break;
        case 16:
          Console.WriteLine(BuildScheduleReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));
          break;
      }

      if (isRunning)
      {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
      }
    }
  }
}