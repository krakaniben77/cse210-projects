using System;
public class Fractions
{
    private int _top;
    private int _bottom;

    public Fractions()
    {
        _top = 1;
        _bottom = 1;

    }

    public Fractions(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;

    }
    public Fractions(int top, int bottom)
    {
        _top=top;
        _bottom=bottom;

    }
    public string GetFractionString()
    {
        string text =$"{_top}/{_bottom}";
        return text;
    }
    public Double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;

    }
     
}