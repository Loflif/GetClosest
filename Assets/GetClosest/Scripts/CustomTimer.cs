using System;
using System.Diagnostics;

public class CustomTimer : IDisposable
{
    private readonly string    Name;
    private readonly int       TestCount;
    private readonly Stopwatch StopWatch;


    public CustomTimer(string pName, int pTestCount)
    {
        Name = pName;
        TestCount = pTestCount;
        StopWatch = Stopwatch.StartNew();
    }
    
    public void Dispose()
    {
        StopWatch.Stop();
        float ms = StopWatch.ElapsedMilliseconds;
        UnityEngine.Debug.Log($"{Name} Total: {ms:0.00}\n" +
                              $"{(ms/ TestCount)} ms per test" +
                              $"Number of tests: {TestCount:N0}");
        
    }
}
