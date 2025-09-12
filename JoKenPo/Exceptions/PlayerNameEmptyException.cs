namespace JoKenPo.Exceptions;

public class PlayerNameEmptyException : PlayerException
{
    public PlayerNameEmptyException(string message = "Name is requerid") : base(message) { }
}
