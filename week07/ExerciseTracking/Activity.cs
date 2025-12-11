using System;

public abstract class Activity
{
    private string _date;
    private int _length;  // in minutes

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public string GetDate() => _date;
    public int GetLength() => _length;

    // Polymorphic methods (abstract → must be overridden)
    public abstract double GetDistance(); // miles or km
    public abstract double GetSpeed();    // mph or kph
    public abstract double GetPace();     // min per mile or km

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_length} min) - " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}
