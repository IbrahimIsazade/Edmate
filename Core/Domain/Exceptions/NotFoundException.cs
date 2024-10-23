namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName)
            : base(string.Format("Entity not found", entityName))
        {

        }
    }
}
