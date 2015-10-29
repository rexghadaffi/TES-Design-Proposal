using EntryDesignConcept.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntryDesignConcept.AppContext
{
    public class UserContext : DataAccessHelper
    {
        #region -- Private Members --
        private static string _pkField = "userID";
        private static string _tableName = "tbluser";
        private PositionContext dbPosition = new PositionContext();
        #endregion

        #region -- Properties --
        // maps fields in the database to be inserted or updated.
        private List<string> TargetFields
        {
            get
            {
                return new List<string> { "name",
                                          "positionID" };
            }
        }
        public IEnumerable<User> GetAllUsers
        {
            get
            {
                List<User> users = new List<User>();
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
                        User user = new User();

                        user.ID = Convert.ToInt32(rd[_pkField]);
                        user.Fullname = rd["name"].ToString();
                        user.PositionID = Convert.ToInt32(rd["positionID"]);
                        user.PositionName = dbPosition.GetAllActivities.Single(p => p.ID == user.PositionID).Name;
                        users.Add(user);
                    }

                    myConn.Close();
                }

                return users;
            }
        }
        #endregion

        #region -- Methods --
        public void Insert(User data)
        {
            ExecuteNonQuery(QueryBuilder.Insert(_tableName, TargetFields), SetParams(data));
        }

        public void Update(User data, int id)
        {
            ExecuteNonQuery(QueryBuilder.Update(_tableName, TargetFields, id, _pkField), SetParams(data));
        }
        // sets parameters for insert/update
        private Dictionary<string, object> SetParams(User data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            result.Add("@name", data.Fullname);
            result.Add("@positionID", data.PositionID);

            return result;
        }
        #endregion    

    }
}