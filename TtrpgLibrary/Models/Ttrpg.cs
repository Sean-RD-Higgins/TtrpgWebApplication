namespace TtrpgLibrary.Models
{
    public class Ttrpg
    {
		public TtrpgGame Game { get { return _game; } set { _game = value; } }
		public List<TtrpgField> FieldList { get { return _fieldList; } set { _fieldList = value; } }

		private TtrpgGame _game;
		private List<TtrpgField> _fieldList;

		public Ttrpg()
		{
			_game = new TtrpgGame();
            _fieldList = new List<TtrpgField>();
		}

		public void SetGame(TtrpgGame ttrpgGame)
		{
			_game = ttrpgGame;
		}

		public void SetFieldList(List<TtrpgField> fieldList)
		{
			_fieldList = fieldList;
		}

		public TtrpgGame GetGame()
		{
			return _game;
		}

		public List<TtrpgField> GetFieldList()
		{
			return _fieldList;
		}

	}
}