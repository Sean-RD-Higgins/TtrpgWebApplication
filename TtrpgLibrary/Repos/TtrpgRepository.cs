using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtrpgLibrary.Models;

namespace TtrpgLibrary.Repos
{

	public class TtrpgRepository
	{
		private readonly TtrpgRepositoryConfiguration _ttrpgRepositoryConfiguration;

		public TtrpgRepository(string connectionString) : this(new TtrpgRepositoryConfiguration(connectionString))
        {

        }
		
		public TtrpgRepository(TtrpgRepositoryConfiguration ttrpgRepositoryConfiguration)
		{
			this._ttrpgRepositoryConfiguration = ttrpgRepositoryConfiguration;
		}

		public List<TtrpgGame> GetTtrpgGameList()
		{

			List<TtrpgGame> ttrpgGameList = new();
			const string getGamesCommand = "SELECT id, name FROM TtrpgGame;";
			MySqlCommand sqlStatement = new(getGamesCommand, _ttrpgRepositoryConfiguration.GetConnection());
			try
			{
				_ttrpgRepositoryConfiguration.GetConnection().Open();
				using (MySqlDataReader rs = sqlStatement.ExecuteReader()) 
				{
					while (rs.Read())
					{
						TtrpgGame game = new();
						int index = 0;
						game.SetId((int)rs[index++]);
						game.SetName((string)rs[index++]);
						ttrpgGameList.Add(game);
					}
				}
				_ttrpgRepositoryConfiguration.GetConnection().Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new List<TtrpgGame>();
			}
			return ttrpgGameList;
		}

		public Ttrpg GetTtrpg(int ttrpgGameId)
		{
			Ttrpg ttrpg = new();
			try
			{
				_ttrpgRepositoryConfiguration.GetConnection().Open();
				{
					// TODO change to view and a single command with many resultsets returned instead.
					const string getGameCommand = "SELECT id, name FROM TtrpgGame WHERE id = @gameid;";
					MySqlCommand sqlStatement = new(getGameCommand, _ttrpgRepositoryConfiguration.GetConnection());
					sqlStatement.Parameters.AddWithValue("@gameid", ttrpgGameId);
					MySqlDataReader rs = sqlStatement.ExecuteReader();
					while (rs.Read())
					{
						int index = 0;
						ttrpg.GetGame().SetId((int)rs[index++]);
						ttrpg.GetGame().SetName((string)rs[index++]);
					}
					rs.Close();
				}

				{
					// TODO change to view.
					const string getGameCommand = @"
						SELECT id, tag, typeid, valuelist, name, TtrpgFields.order
						FROM TtrpgFields 
						WHERE gameid = @gameid
						ORDER BY TtrpgFields.order ASC;
					";
					MySqlCommand sqlStatement = new(getGameCommand, _ttrpgRepositoryConfiguration.GetConnection());
					sqlStatement.Parameters.AddWithValue("@gameid", ttrpgGameId);
					MySqlDataReader rs = sqlStatement.ExecuteReader();
					while (rs.Read())
					{
						TtrpgField field = new();
						int index = 0;
						field.SetId((int)rs[index++]);
						field.SetTag((string)rs[index++]);
						field.SetTypeId((int)rs[index++]);
						field.SetValueListText((string)rs[index++]);
						field.SetName((string)rs[index++]);
						field.Order = (int)rs[index++];
						field.SetGameId(ttrpgGameId);
						ttrpg.GetFieldList().Add(field);
					}
					rs.Close();
				}

				{
					// TODO change to view.
					const string getGameCommand = @"
						SELECT TtrpgFormulas.id, TtrpgFormulas.fieldid, TtrpgFormulas.value, TtrpgFormulas.formula, TtrpgFormulas.priority
						FROM TtrpgFormulas
							INNER JOIN TtrpgFields
								ON TtrpgFields.id = TtrpgFormulas.fieldid
						WHERE TtrpgFields.gameid = @gameid
						ORDER BY TtrpgFormulas.priority ASC;
					";
					MySqlCommand sqlStatement = new(getGameCommand, _ttrpgRepositoryConfiguration.GetConnection());
					sqlStatement.Parameters.AddWithValue("@gameid", ttrpgGameId);
					MySqlDataReader rs = sqlStatement.ExecuteReader();
					while (rs.Read())
					{
						int index = 0;
						TtrpgFormula formula = new();
						formula.SetId((int)rs[index++]);
						formula.SetFieldId((int)rs[index++]);
						formula.SetValue((string)rs[index++]);
						formula.SetFormula((string)rs[index++]);
						formula.SetPriority((int)rs[index++]);
                        TtrpgField fieldList = ttrpg.GetFieldList().First(f => f.GetId() == formula.GetFieldId());
						if(fieldList == null)
                        {
							fieldList = new();
							ttrpg.GetFieldList().Add(fieldList);
						}
						fieldList.AddFormula(formula);
					}
					rs.Close();
				}
				_ttrpgRepositoryConfiguration.GetConnection().Close();
				return ttrpg;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new Ttrpg();
			}
		}
	}
}
