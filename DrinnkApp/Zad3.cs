namespace DrinnkApp;

public class Zad3
{
    public static void Start()
    {
        Console.Write("Podaj nazwe herbaty (mozliwe do wyboru mieta/gunpowder zielony: ");
        string name = Console.ReadLine();
        Console.Write("Podaj temperature wody: ");
        int temp = Convert.ToInt32(Console.ReadLine());
        Console.Write("Podaj czas parzenia: ");
        int time = Convert.ToInt32(Console.ReadLine());
        Drink drink;
        if (name.ToLower().Equals("mieta")) drink = new Mint(temp, time);
        else if (name.ToLower().Contains("gunpowder") || name.ToLower().Contains("zielony") ||
            name.Equals("gunpowder zielony")) drink = new GreenGunpowder(temp, time);
        else
        {
            Console.Write("Podano nieznany napoj!");
            return;
        }

        var result = drink.CalculateResultAndReasonOfDrink();
        Console.WriteLine("Wynik:  " + result.Item1);
        Console.WriteLine("Przyczyna:  " + result.Item2);
    }
}