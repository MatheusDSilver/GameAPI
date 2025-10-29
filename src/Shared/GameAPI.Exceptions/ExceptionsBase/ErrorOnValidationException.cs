namespace GameAPI.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : SystemException
    {

        public ErrorOnValidationException()
        {

        }
        public ErrorOnValidationException(string message) : base(message) { }
        public ErrorOnValidationException(string message, Exception innerException) : base(message, innerException) { }


    }
}