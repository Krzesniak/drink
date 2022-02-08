namespace DrinnkApp;

public class Zad1
{
    public static void Start(String path)
    {
        var lines = File.ReadAllLines(path);
        List<string> linesToSave = new List<string>();
        foreach (var line in lines)
        {
            var splittedLine = line.Split(",");
            RemoveWhiteSpaces(splittedLine);
            Drink mint = SetDrink(splittedLine);
            linesToSave.Add(splittedLine[0] + ", " + mint.CalculateResultAndReasonOfDrink().Item1);
        }
        File.WriteAllLines("result-5.txt", linesToSave);
    }

    private static Drink SetDrink(string[] splittedLine)
    {
        if (splittedLine[0].Equals("Mięta")) return new Mint(int.Parse(splittedLine[1]), int.Parse(splittedLine[2]));
        else return null;
    }

    private static void RemoveWhiteSpaces(string[] splittedLine)
    {
        for (int i = 0; i < splittedLine.Length; i++)
        {
            splittedLine[i] = splittedLine[i].Replace(" ", "");
        }
    }
}