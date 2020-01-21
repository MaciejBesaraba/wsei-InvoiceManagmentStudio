namespace Core.Domain.Exception
{
    public class DataIntegrityException : System.Exception
    {
        public DataIntegrityException()
        {

        }

        public DataIntegrityException(string message) : base(message)
        {

        }
    }
}