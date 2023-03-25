// See https://aka.ms/new-console-template for more information
using MySqlConnector;
using TtrpgLibrary.Models;
using TtrpgLibrary.Repos;

const string databaseName = "epiz_32554537_db";
const string portNumber = "3306";
const string USER = "admin";
const string PASS = "admin";
const string connectionstring = "server=localhost;user=" + USER + ";database=" + databaseName + ";port=" + portNumber + ";password=" + PASS;

List<TtrpgGame> ttrpgGameList = new();
string input = "";

try
{
    MySqlConnection connection = new(connectionstring);
    TtrpgRepositoryConfiguration ttrpgRepositoryConfiguration = new(connection);
    TtrpgRepository ttrpgRepository = new(ttrpgRepositoryConfiguration);
    ttrpgGameList = ttrpgRepository.GetTtrpgGameList();
    ttrpgRepository.GetTtrpg(ttrpgGameList[0].GetId());
} catch (Exception e)
{
    Console.WriteLine("Unable to connect. " + e.Message + "  Creating an empty game.");
    ttrpgGameList.Add(new TtrpgGame());
    Console.Write("Please enter a new game name. \n >");
    ttrpgGameList[0].SetName(_name: Console.ReadLine() ?? "Game 1");
}

while (!input.Equals("exit"))
{
    Console.Write("Please enter an action: 'exit'. \n >");
    input = Console.ReadLine() ?? string.Empty;
}