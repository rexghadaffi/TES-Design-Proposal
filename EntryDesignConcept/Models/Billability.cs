using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntryDesignConcept.Models
{
    public class Billability
    {
        public int ID { get; set; }
        public Position PositionID { get; set; }
        public Activity ActivityID { get; set; }
        public bool Billable { get; set; }      
    }
}