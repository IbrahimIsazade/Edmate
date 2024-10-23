namespace Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string entityName)
            : base(string.Format("Bad Request", entityName)) { }
    }
}
