namespace Infrastructure
{
    public class AppProfile : IAppProfile
    {
        // TODO from properties
        private const string CDataSource = @"127.0.0.1";
        private const string CUsername = "postgres";
        private const string CPassword = "postgres";
        private const string CDatabase = "ivms";


        public string DataSource => CDataSource;
        public string Username => CUsername;
        public string Password => CPassword;
        public string Database => CDatabase;
    }
}