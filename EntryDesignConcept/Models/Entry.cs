using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntryDesignConcept.AppContext;

namespace EntryDesignConcept.Models
{
    public class Entry
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public IEnumerable<Billability> Billability { get; set; }
    }

    public class ActivitiesViewModel 
    {
        public int PositionID { get; set; }
        public IEnumerable<Billability> Billability 
        {
            get 
            {
                BillabilityContext db = new BillabilityContext();
                return db.Fetch.Where(b => b.PositionID.ID == this.PositionID);
            }
        }
    }
}