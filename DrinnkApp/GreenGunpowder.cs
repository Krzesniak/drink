namespace DrinnkApp;

public class GreenGunpowder : Drink
{
    public GreenGunpowder(int temp, int time)
    {
        Time = time;
        Temp = temp;
    }
    private int PerfectTemp { get; } = 70;
    private int PerfectTime { get; } = 180;

    public override Tuple<string, string> CalculateResultAndReasonOfDrink()
    {
        var minAndMaxValueForTempInterval =
            new Tuple<int, int>(PerfectTemp - PerfectTemp / 10, PerfectTemp + PerfectTemp / 10);
        var minAndMaxValueForTimeInterval =
            new Tuple<int, int>(PerfectTime - PerfectTime / 10, PerfectTime + PerfectTime / 10);
        if (Time == PerfectTime && PerfectTemp == Temp)
        {
            return new Tuple<string, string>("perfect", "Exactly like in tea-data.txt");
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