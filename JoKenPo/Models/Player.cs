namespace JoKenPo.Models;

public class Player
{
    public Player(string name)
    {
        CheckValidName(name);

        Name = name.ToUpper();
    }

    public string Name { get; private set; }
    public int Score { get; private set; }

    public Moviment Choose()
    {
        int input = new Random().Next(0, 2);
        var choice = Enum.GetValues<Moviment>()[input];
        return choice;
    }

    public void AddScore() => Score++;

    public static void CheckValidName(string name)
    {
        var length = name.Length;
        var minimumLengthName = 2;
        var maximumLengthName = 10;

        if (length < minimumLengthName)
            throw new PlayerNameTooShortException($"{nameof(PlayerNameTooShortException)}: The player's name is too short. The minimum name length is {minimumLengthName}.");

        if(length > maximumLengthName)        
            throw new PlayerNameTooLongException($"{nameof(PlayerNameTooLongException)}: The player's name is too long. The maximum name length is {maximumLengthName}.");

        if(Regex.IsMatch(name, @"\d+"))
            throw new PlayerNameWithNumberException($"{nameof(PlayerNameWithNumberException)}: The player's name cannot contain numbers.");
    }
}
