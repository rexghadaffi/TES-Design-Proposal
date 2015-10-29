using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntryDesignConcept.Models
{
    public class Entry
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int ActivityID { get; set; }
        public int PositionID { get; set; }
    }
}