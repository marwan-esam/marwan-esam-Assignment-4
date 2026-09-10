class Program
{
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
  }
}