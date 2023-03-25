using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TtrpgLibrary.Models
{

    public class TtrpgGame
    {

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        private int _id;
        private string _name;

        public TtrpgGame(int _id, string _name)
        {
            this._id = _id;
            this._name = _name;
        }

        public TtrpgGame()
        {
            _id = 0;
            _name = "";
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int _id)
        {
            this._id = _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string _name)
        {
            this._name = _name;
        }
    }

}
