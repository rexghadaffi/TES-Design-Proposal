using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntryDesignConcept.Models;
using MySql.Data.MySqlClient;
namespace EntryDesignConcept.AppContext
{
    public class ActivityContext : DataAccessHelper
    {
        #region -- Private Members --
        private static string _pkField = "activityID";
        private static string _tableName = "tblactivity";

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
        public IEnumerable<Activity> GetAllActivities
        {
            get
            {
                List<Activity> activities = new List<Activity>();
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
                        Activity activity = new Activity();

                        activity.ID = Convert.ToInt32(rd[_pkField]);
                        activity.Name = rd["name"].ToString();
                        activities.Add(activity);
                    }

                    myConn.Close();
                }

                return activities;
            }
        }
        #endregion

        #region -- Methods --
        public void Insert(Activity data)
        {
            ExecuteNonQuery(QueryBuilder.Insert(_tableName, TargetFields), SetParams(data));
        }

        public void Update(Activity data, int id)
        {
            ExecuteNonQuery(QueryBuilder.Update(_tableName, TargetFields, id, _pkField), SetParams(data));
        }
        // sets parameters for insert/update
        private Dictionary<string, object> SetParams(Activity data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            result.Add("@name", data.Name);

            return result;
        }
        #endregion    


    }
}