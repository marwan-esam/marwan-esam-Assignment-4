using System.Text;
using BenchmarkDotNet.Attributes;
namespace AcademyScheduleAnalyzer.Benchmarks;

[MemoryDiagnoser]
public class StringBenchmark
{
    private readonly string _stringToBeAdded = "test string concatenation";

    [Params(100, 1000, 10000, 100000)] public int Iterations;
    
    [Benchmark]
    public void StringConcatenation()
    {
        string result = "";
        for (int i = 0; i < Iterations; i++)
        {
            result += _stringToBeAdded;
        }
    }

    [Benchmark]
    public void StringBuilderConcatenation()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < Iterations; i++)
        {
            result.Append(_stringToBeAdded);
        }
    }
}
