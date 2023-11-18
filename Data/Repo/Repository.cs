using Microsoft.Data.SqlClient;

namespace BlazerServerCoaching.Data.Repo
{
    public abstract class Repository : IRepository
    {


        private IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        protected SqlConnection GetConnection()
        {
            string? connectionString = config.GetConnectionString("Default");

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public abstract void Load();
    }
}
