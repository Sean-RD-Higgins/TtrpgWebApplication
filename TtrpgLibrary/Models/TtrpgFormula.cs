using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TtrpgLibrary.Models
{

	public class TtrpgFormula
	{
		public int Id { get { return _id; } set { _id = value; } }
		public int FieldId { get { return _fieldId; } set { _fieldId = value; } }
		public string Value { get { return _value; } set { _value = value; } }
		public string Formula { get { return _formula; } set { _formula = value; } }
		public int Priority { get { return _priority; } set { _priority = value; } }

		private int _id;
		private int _fieldId;
		private string _value = string.Empty;
		private string _formula = string.Empty;
		private int _priority;

		public int GetId()
		{
			return _id;
		}
		public void SetId(int _id)
		{
			this._id = _id;
		}
		public int GetFieldId()
		{
			return _fieldId;
		}
		public void SetFieldId(int _fieldId)
		{
			this._fieldId = _fieldId;
		}
        public string GetValue()
		{
			return _value;
		}
		public void SetValue(string _value)
		{
			this._value = _value;
		}
		public string GetFormula()
		{
			return _formula;
		}
		public void SetFormula(string _formula)
		{
			this._formula = _formula;
		}
        public int GetPriority()
		{
			return _priority;
		}
		public void SetPriority(int _priority)
		{
			this._priority = _priority;
		}

	}

}
