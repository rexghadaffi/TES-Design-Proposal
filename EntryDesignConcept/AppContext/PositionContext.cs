using EntryDesignConcept.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntryDesignConcept.AppContext
{
    public class PositionContext : DataAccessHelper
    {
        #region -- Private Members --
        private static string _pkField = "positionID";
        private static string _tableName = "tblposition";

        #endregion

        #region -- Properties --
        // maps fields in the database to be inserted or updated.
        private List<string> TargetFields
        {
            get
            {
                return new List<string> { "name" };
            }
        }
        public IEnumerable<Position> GetAllActivities
        {
            get
            {
                List<Position> positions = new List<Position>();
                using (MySqlConnection myConn = MySqlConn)
                {
                    MySqlCommand cmd = new MySqlCommand
                    {
                        CommandText = QueryBuilder.SelectAll(_tableName),
                        Connection = myConn
                    };
                    myConn.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        Position position = new Position();

                        position.ID = Convert.ToInt32(rd[_pkField]);
                        position.Name = rd["name"].ToString();
                        positions.Add(position);
                    }

                    myConn.Close();
                }

                return positions;
            }
        }
        #endregion

        #region -- Methods --
        public void Insert(Position data)
        {
            ExecuteNonQuery(QueryBuilder.Insert(_tableName, TargetFields), SetParams(data));
        }

        public void Update(Position data, int id)
        {
            ExecuteNonQuery(QueryBuilder.Update(_tableName, TargetFields, id, _pkField), SetParams(data));
        }
        // sets parameters for insert/update
        private Dictionary<string, object> SetParams(Position data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            result.Add("@name", data.Name);

            return result;
        }
        #endregion    

    }
}