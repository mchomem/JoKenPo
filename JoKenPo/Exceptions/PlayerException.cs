namespace JoKenPo.Exceptions;

public abstract class PlayerException : Exception
{
    protected PlayerException(string message) : base(message) { }
}
