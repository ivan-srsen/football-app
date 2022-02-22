namespace Football.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public string? Key { get; set; }

        public ValidationException()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, string key)
            : base(message)
        {
            Key = key;
        }

        public ValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
