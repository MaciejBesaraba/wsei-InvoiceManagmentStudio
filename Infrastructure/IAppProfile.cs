namespace Infrastructure
{
    public interface IAppProfile
    {
        string DataSource { get; }
        string Username { get; }
        string Password { get; }
        string Database { get; }
    }
}