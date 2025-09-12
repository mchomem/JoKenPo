namespace JoKenPo.Exceptions;

public class PlayerNameTooLongException : PlayerException
{
    public PlayerNameTooLongException(string message = "The player name is too long.") : base(message) { }
}
