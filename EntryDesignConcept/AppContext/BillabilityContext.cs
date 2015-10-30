using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntryDesignConcept.Models;
using MySql.Data.MySqlClient;

namespace EntryDesignConcept.AppContext
{
    public class BillabilityContext : DataAccessHelper
    {
        #region -- Private Members --
        private static string _pkField = "billabilityID";
        private static string _tableName = "tblbillability";
        private PositionContext dbPosition = new PositionContext();
        private ActivityContext dbActivity = new ActivityContext();
        #endregion

        #region -- Properties --
        // maps fields in the database to be inserted or updated.
        private List<string> TargetFields
        {
            get
            {
                return new List<string> { "activityID",
                                          "positionID",
                                          "billable" };
            }
        }
        public IEnumerable<Billability> Fetch
        {
            get
            {
                List<Billability> bills = new List<Billability>();
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
                        Billability bill = new Billability();

                        bill.ID = Convert.ToInt32(rd[_pkField]);
                        bill.PositionID = dbPosition.GetAllActivities.Single(p => p.ID == Convert.ToInt32(rd["positionID"]));
                        bill.ActivityID = dbActivity.GetAllActivities.Single(a => a.ID == Convert.ToInt32(rd["activityID"]));
                        bill.Billable = Convert.ToBoolean(rd["billable"]);
                        bills.Add(bill);
                    }

                    myConn.Close();
                }

                return bills;
            }
        }
        #endregion

        #region -- Methods --
        public void Insert(Billability data)
        {
            ExecuteNonQuery(QueryBuilder.Insert(_tableName, TargetFields), SetParams(data));
        }

        public void Update(Billability data, int id)
        {
            ExecuteNonQuery(QueryBuilder.Update(_tableName, TargetFields, id, _pkField), SetParams(data));
        }
        // sets parameters for insert/update
        private Dictionary<string, object> SetParams(Billability data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            result.Add("@activityID", data.ActivityID.ID);
            result.Add("@positionID", data.PositionID.ID);           
            result.Add("@billable", data.Billable);
            return result;
        }
        #endregion    

    }
}