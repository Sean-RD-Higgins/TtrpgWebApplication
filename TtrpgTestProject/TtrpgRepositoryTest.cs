using MySqlConnector;
using TtrpgLibrary.Models;
using TtrpgLibrary.Repos;

namespace TtrpgTestProject
{
    [TestClass]
    public class TtrpgRepositoryTest
    {
        [TestMethod]
        public void GetTtrpgGameList()
        {

            //const string hostAddress = "127.0.0.1";
            const string portNumber = "3306";
            const string databaseName = "epiz_32554537_db";
            //const string DB_URL = "jdbc:mysql://" + hostAddress + ":" + portNumber + "/" + databaseName;
            const string USER = "admin";
            //        const string USER = "epiz_32554537";
            const string PASS = "admin";            //        const string PASS = "nKlShohSQm";
            const string connectionstring = "server=localhost;user=" + USER + ";database=" + databaseName + ";port=" + portNumber + ";password=" + PASS;

            MySqlConnection connection = new(connectionstring);
            TtrpgRepositoryConfiguration ttrpgRepositoryConfiguration = new(connection);
            TtrpgRepository ttrpgRepository = new(ttrpgRepositoryConfiguration);
            List<TtrpgGame> ttrpgGameList = ttrpgRepository.GetTtrpgGameList();
            Assert.IsTrue(ttrpgGameList.Any());
            ttrpgRepository.GetTtrpg(ttrpgGameList[0].GetId());
            Assert.IsNotNull(ttrpgGameList);
            Assert.IsTrue(ttrpgGameList.Any());
            Ttrpg tttrpg = ttrpgRepository.GetTtrpg(ttrpgGameList[0].GetId());
            Assert.IsNotNull(tttrpg);
        }
    }
}