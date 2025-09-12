Console.Title = "JaKenPo";

while (true)
{
    Console.Clear();
    new GameManager(totalRounds: 3).Start();
    Console.Clear();

    var input = string.Empty;

    while (true)
    {
        Console.WriteLine("Do you want to play again? (Y/N)");
        input = Console.ReadLine()?.ToLower();

        var acceptableOptions = new List<string>() { "y", "n" };
        
        if (!acceptableOptions.Contains(input!))
        {
            Console.WriteLine("Choose Y or N options.");
            Console.ReadKey();
            Console.Clear();
            continue;
        }

        break;
    }

    if (input!.Equals("n"))
    {
        break;
    }
}
