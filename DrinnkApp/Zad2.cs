using System.Collections;

namespace DrinnkApp;

public class Zad2
{
    public static void Start(String path)
    {
        var lines = File.ReadAllLines(path);
        List<string> linesToSave = new List<string>();
        linesToSave.Add("RESULT                            ;  REASON_1                              ; REASON_2 ");
        int counter = 0;
        Stack<Tuple<string, string>> results = new Stack<Tuple<string, string>>();
        foreach (var line in lines)
        {
            counter++;
            var splittedLine = line.Split(",");
            RemoveWhiteSpaces(splittedLine);
            Drink drink = SetDrink(splittedLine);
            results.Push(drink.CalculateResultAndReasonOfDrink());
            if (counter == 2)
            {
                counter = 0;
                var result1 = results.Pop();
                var result2 = results.Pop();
               linesToSave.Add(CompareResults(result1, result2));
            }
          
        }
        File.WriteAllLines("result-6.txt", linesToSave);
    }

    private static string CompareResults(Tuple<string,string> result1, Tuple<string,string> result2)
    {
        if (result1.Item1.Equals("perfect") && result2.Item1.Equals("perfect"))
        {
            return "Congratulations, perfect Touareg; " + result1.Item2 + "; " + result2.Item2;
        }
        else return "Sadly, your Touareg is ruined; " + result1.Item2 + "; " + result2.Item2;
    }

    private static Drink SetDrink(string[] splittedLine)
    {
        if (splittedLine[0].Equals("Mięta")) return new Mint(int.Parse(splittedLine[1]), int.Parse(splittedLine[2]));
        else  return new GreenGunpowder(int.Parse(splittedLine[2]), int.Parse(splittedLine[3]));
    }
    
    private static void RemoveWhiteSpaces(string[] splittedLine)
    {
        for (int i = 0; i < splittedLine.Length; i++)
        {
            splittedLine[i] = splittedLine[i].Replace(" ", "");
        }
        
    }
}