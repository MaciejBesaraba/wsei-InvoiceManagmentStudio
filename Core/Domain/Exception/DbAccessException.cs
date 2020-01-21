namespace Core.Domain.Exception
{
    public class DbAccessException : System.Exception
    {
        public DbAccessException()
        {

        }

        public DbAccessException(string message) : base(message)
        {

        }
    }
}