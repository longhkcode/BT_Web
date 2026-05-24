namespace StopWatch;

using System;

class StopWatch
{
    private DateTime startTime;
    private DateTime endTime;

    public DateTime StartTime
    {
        get { return startTime; }
    }

    public DateTime EndTime
    {
        get { return endTime; }
    }

    public StopWatch()
    {
        startTime = DateTime.Now;
    }

    public void Start()
    {
        startTime = DateTime.Now;
    }

    public void Stop()
    {
        endTime = DateTime.Now;
    }

    public double GetElapsedTime()
    {
        return (endTime - startTime).TotalMilliseconds;
    }
}