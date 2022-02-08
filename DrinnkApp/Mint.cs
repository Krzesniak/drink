using System.Runtime.CompilerServices;

namespace DrinnkApp;

public class Mint : Drink
{
    public Mint(int temp, int time)
    {
        Time = time;
        Temp = temp;
    }
    private int PerfectTemp { get; } = 96;
    private int PerfectTime { get; } = 300;
    
    public override Tuple<string, string> CalculateResultAndReasonOfDrink()
    {
        var minAndMaxValueForTempInterval =
            new Tuple<int, int>(PerfectTemp - PerfectTemp / 10, PerfectTemp + PerfectTemp / 10);
        var minAndMaxValueForTimeInterval =
            new Tuple<int, int>(PerfectTime - PerfectTime / 10, PerfectTime + PerfectTime / 10);
        if (Time == PerfectTime && PerfectTemp == Temp)
        {
            return new Tuple<string, string>("perfect", "Exactly like expected");
        }

        else if (IsTempInPerfectTempInterval(minAndMaxValueForTempInterval) && IsTimeInPerfectTempInterval(minAndMaxValueForTimeInterval))
        {
            return new Tuple<string, string>("perfect", "Inside 10% deviation range for all parameters");
        }
        else if (Time > PerfectTime || Temp > PerfectTemp)
        {
            return new Tuple<string, string>("yucky", "One of the parameters is above of the deviation range");
        }
        else
        {
            return new Tuple<string, string>("week", "One of the parameters is lower of the deviation range");
        }
        
    }
    
}