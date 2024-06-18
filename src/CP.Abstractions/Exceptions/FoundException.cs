namespace CP.Abstractions.Exceptions
{
    public abstract class FoundException : Exception
    {
        protected FoundException(string message) : base(message) { }
    }
}
