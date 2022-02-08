namespace DrinnkApp;

public abstract class Drink
{
    protected int Temp { get; set; }
    protected int Time { get; set; }
    public abstract Tuple<string, string> CalculateResultAndReasonOfDrink();
    
    protected  bool IsTempInPerfectTempInterval(Tuple<int, int> minAndMaxValueForTempInterval)
    {
        return Temp >= minAndMaxValueForTempInterval.Item1 && Temp <= minAndMaxValueForTempInterval.Item2;
    }
    protected  bool IsTimeInPerfectTempInterval(Tuple<int, int> minAndMaxValueForTempInterval)
    {
        return Time >= minAndMaxValueForTempInterval.Item1 && Time <= minAndMaxValueForTempInterval.Item2;
    }
}