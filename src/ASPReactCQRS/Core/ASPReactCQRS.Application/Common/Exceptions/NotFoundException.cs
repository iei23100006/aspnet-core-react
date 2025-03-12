namespace ASPReactCQRS.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
         public NotFoundException(string message) : base(message)
        {
        }
    }
}