using System.Configuration;

namespace Infrastructure
{
    public class AppProfile : IAppProfile
    {
        // TODO from properties
        private const string DefaultDataSource = @"127.0.0.1";
        private const string DefaultUsername = "postgres";
        private const string DefaultPassword = "postgres";
        private const string DefaultDatabase = "ivms";

        public string DataSource { get; }
        public string Username { get; }
        public string Password { get; }
        public string Database { get; }
        
        public AppProfile()
        {
            DataSource = DefaultDataSource;
            Username = DefaultUsername;
            Password = DefaultPassword;
            Database = DefaultDatabase;
        }
        
        public AppProfile(string dataSource, string username, string password, string database)
        {
            DataSource = dataSource;
            Username = username;
            Password = password;
            Database = database;
        }

        public static AppProfile FromConfig()
        {
            return new AppProfile(
                ConfigurationSettings.AppSettings.Get("datasource"),
                ConfigurationSettings.AppSettings.Get("username"),
                ConfigurationSettings.AppSettings.Get("password"),
                ConfigurationSettings.AppSettings.Get("database")
            );
        }
    }
}