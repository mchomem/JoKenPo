namespace JoKenPo.Exceptions;

public class PlayerNameTooShortException : PlayerException
{
    public PlayerNameTooShortException(string message = "The player name is too short.") : base(message) { }
}
