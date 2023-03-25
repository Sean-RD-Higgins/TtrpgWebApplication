using TtrpgLibrary.Models;

namespace TtrpgWebApplication.Models
{
    public class GameSelectPageModel
	{
		public List<TtrpgGame> GameList { get; set; }

		public GameSelectPageModel(List<TtrpgGame> gameList)
		{
			GameList = gameList;
		}
	}
}
