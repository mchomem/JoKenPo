namespace JoKenPo.Exceptions;

public class PlayerNameWithNumberException : PlayerException
{
    public PlayerNameWithNumberException(string message = "The name must contain only letters") : base(message) { }
}
