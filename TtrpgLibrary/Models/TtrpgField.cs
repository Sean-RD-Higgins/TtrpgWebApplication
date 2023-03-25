using TtrpgLibrary.Enums;

namespace TtrpgLibrary.Models
{

	public class TtrpgField
	{
		public int Id { get { return _id; } set { _id = value; } }
		public int GameId { get { return _gameId; } set { _gameId = value; } }
		public string Name { get { return _name; } set { _name = value; } }
		public string Tag { get { return _tag; } set { _tag = value; } }
		public int TypeId { get { return _typeId; } set { _typeId = value; } }
		public string ValueListText { get { return _valueListText; } set { _valueListText = value; } }
		public List<TtrpgFormula> FormulaList { get { return _formulaList; } set { _formulaList = value; } }

		private int _id;
		private int _gameId;
		private string _name = string.Empty;
		private string _tag = string.Empty;
		private int _typeId;
		private string _valueListText = string.Empty;
		private List<TtrpgFormula> _formulaList = new();

		public TtrpgField()
		{
		}

		public int GetId()
		{
			return _id;
		}
		public void SetId(int _id)
		{
			this._id = _id;
		}
		public int GetGameId()
		{
			return _gameId;
		}
		public void SetGameId(int _gameId)
		{
			this._gameId = _gameId;
		}

		/***
		 * Retrieves the display name to show on the screen.
		 * @return
		 */
		public string GetName()
		{
			return _name;
		}
		public void SetName(string _name)
		{
			this._name = _name;
		}

		/***
		 * Retrieves the tag that is used in the formulas when referencing this field.
		 * @return
		 */
		public string GetTag()
		{
			return _tag;
		}
		public void SetTag(string _tag)
		{
			this._tag = _tag;
		}

		/***
		 * Gets the numeric value of the FieldValueType of this field.
		 * @return
		 */
		public int GetTypeId()
		{
			return _typeId;
		}
		public void SetTypeId(int _typeId)
		{
			this._typeId = _typeId;
		}
		public FieldValueType GetFieldValueType()
        {
			return (FieldValueType)TypeId;
		}
		public void SetFieldValueType(FieldValueType fieldValueType)
        {
			TypeId = (int)fieldValueType;
		}

		/***
		 * Will contain in a single string the comma separated possible values for this field.
		 */
		public string GetValueListText()
		{
			return _valueListText;
		}

		/***
		 * Sets the single string the comma separated possible values for this field.
		 */
		public void SetValueListText(string _valueListText)
		{
			this._valueListText = _valueListText;
		}

		/***
		 * Returns the HTML Input tag type attribute for readonly if it is.
		 */
		public string GetReadonlyAttribute()
        {
			if(TypeId == (int)FieldValueType.Readonly)
            {
				return "readonly";
            }
			return "";
        }

		/***
		 * Retrieves the available values for this field.
		 */
		public List<string> GetValueList()
		{
			// Retrieves the full list of field values from the ValueListText which are comma separatedW.
			List<string> valuestringList = new();
			valuestringList.AddRange(GetValueListText().Split(","));
			return valuestringList;
		}

		public void SetValueList(List<string> valueList)
		{
			_valueListText = string.Join(",", valueList);
		}

		public void SetFormulaList(List<TtrpgFormula> formulaList)
		{
			_formulaList = formulaList;
		}

		public List<TtrpgFormula> GetFormulaList()
		{
			return _formulaList;
		}

		public string GetDefaultValue()
        {
			if(GetFieldValueType() == FieldValueType.Integer)
            {
				return "0";
            }
			return string.Empty;
        }

		public bool HasValueList()
        {
			return ValueListText.Length > 0;
        }
	}

}
