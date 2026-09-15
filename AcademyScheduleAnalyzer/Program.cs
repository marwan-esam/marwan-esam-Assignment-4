using System.Globalization;

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

    Console.WriteLine();
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

    Console.WriteLine();
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

    Console.WriteLine();
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

  public static void CheckSessionExistsUsingExists(string[] sessionNames, string targetSession)
  {
    Predicate<string> isTargetSession = session => session == targetSession;
    bool isFound = Array.Exists(sessionNames, isTargetSession);

    if (isFound)
    {
      Console.WriteLine("Session exists.");
    }
    else
    {
      Console.WriteLine("Session does not exist.");
    }

    Console.WriteLine();
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

  public static void FindSessionIndexUsingFindIndex(string[] sessionNames, string targetSession)
  {
    Predicate<string> isSessionFound = session => session == targetSession;
    int index = Array.FindIndex(sessionNames, isSessionFound);
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

  public static int GetSessionIndex(string[] sessions, string targetSession)
  {
    int index = Array.IndexOf(sessions, targetSession);
    return index;
  }

  public static void DisplaySessionDateDetails(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations, string session)
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

    Console.WriteLine();
  }

  public static void DisplayDatesDifference(string[] sessionNames, DateTime[] sessionDates, string firstSession,
    string secondSession)
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

    Console.WriteLine();
  }

  public static void DisplaySessionDatesStatus(string[] sessionNames, DateTime[] sessionDates)
  {
    for (int i = 0; i < sessionNames.Length; i++)
    {
      bool isDateUpcoming = sessionDates[i] > DateTime.Now;
      Console.WriteLine($"{sessionNames[i]} {(isDateUpcoming ? "Upcoming" : "Past")}");
    }

    Console.WriteLine();
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

    Console.WriteLine();
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
      Console.WriteLine($"Enter a date in this format ({dateFormat}): ");
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
      Console.Write("Choose an option: ");
      string? unparsedInput = Console.ReadLine();
      try
      {
        int parsedInput = int.Parse(unparsedInput);
        return parsedInput;
      }
      catch (FormatException e)
      {
        Console.WriteLine("Invalid menu option. Enter a number");
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
        int? index = int.Parse(Console.ReadLine());
        string session = sessionNames[(int)index];
        Console.WriteLine($"\nSession: {session}");
        return session;
      }
      catch (IndexOutOfRangeException e) 
      {
        Console.WriteLine("The selected session index is out of range.");
      }
      catch (ArgumentNullException e)
      {
        Console.WriteLine($"Failed to process input. Error: {e.Message}");
      }
      catch (FormatException e)
      {
        Console.WriteLine("Invalid input format. please enter a number");
      }

      Console.WriteLine();
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
    
    SortSessionNames(sessionNames);
    
    ReverseSessionNames(sessionNames);
    
    FindSessionIndexUsingIndexOf(sessionNames, "Functions");
    
    CheckSessionExistsUsingExists(sessionNames, "python basics");
    
    CheckSessionExistsUsingFind(sessionNames, "C# Basics");
    
    FindSessionIndexUsingFindIndex(sessionNames, "Functions");
    
    CopyArray(sessionNames);

    Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
    Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations)} minutes");
    Console.WriteLine($"Shortest Duration: {GetShortestDuration(sessionDurations)} minutes");
    Console.WriteLine($"Longest Duration: {GetLongestDuration(sessionDurations)} minutes");
    Console.WriteLine();
    
    SortSessionDurations(sessionDurations);

    int valueToBeChangedUsingRef = 5;
    Console.WriteLine($"Value before change: {valueToBeChangedUsingRef}");
    ChangeValueUsingRef(ref valueToBeChangedUsingRef);
    Console.WriteLine($"Value after change (using ref): {valueToBeChangedUsingRef}");
    Console.WriteLine();

    bool isSessionFound = GetSessionIndexAndDurationUsingOut("Date and Time", sessionNames, sessionDurations, out int sessionIndex, out int sessionDuration);
    if (isSessionFound)
    {
      Console.WriteLine($"Index: {sessionIndex}");
      Console.WriteLine($"Duration: {sessionDuration} minutes");
    }
    else
    {
      Console.WriteLine("Session not found.");
    }
    Console.WriteLine();

    int[] sampleArray = { 1, 2, 3, 4 };
    Console.WriteLine("Sample Array before function call:-");
    foreach (int val in sampleArray)
    {
      Console.WriteLine(val);
    }

    ChangeArrayElement(sampleArray);
    Console.WriteLine("Sample Array after function call:-");
    foreach (int val in sampleArray)
    {
      Console.WriteLine(val);
    }
    Console.WriteLine();

    int d1 = CalculateTotalDurations(120, 180);
    int d2 = CalculateTotalDurations(120, 180, 240);
    int d3 = CalculateTotalDurations(60, 90, 120, 180, 240);
    Console.WriteLine($"Total Durations: {d1}");
    Console.WriteLine($"Total Durations: {d2}");
    Console.WriteLine($"Total Durations: {d3}");
    Console.WriteLine();
    
    DisplaySessionDateDetails(sessionNames, sessionDates, sessionDurations, "Arrays");
    
    DisplayDatesDifference(sessionNames, sessionDates, "C# Basics", "Arrays");
    
    DisplaySessionDatesStatus(sessionNames, sessionDates);
    
    FindNextSession(sessionNames, sessionDates);
    
    DisplaySessionDateFormats("Arrays", sessionDates, sessionNames);

    // DateTime readDate = ReadFormattedDate();

    // int menuChoice = HandleNumericInput();

    string sessionName = GetSessionName(sessionNames);
  }
}