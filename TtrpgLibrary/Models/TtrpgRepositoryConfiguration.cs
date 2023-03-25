using MySqlConnector;

namespace TtrpgLibrary.Models
{

	public class TtrpgRepositoryConfiguration
	{
		private readonly MySqlConnection _databaseConnection;

		public TtrpgRepositoryConfiguration(string databaseConnectionString)
		{
			_databaseConnection = new MySqlConnection(databaseConnectionString);
		}

		public TtrpgRepositoryConfiguration(MySqlConnection databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public MySqlConnection GetConnection()
		{
			return _databaseConnection;
		}
	}
}
