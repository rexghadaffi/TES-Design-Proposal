using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntryDesignConcept.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
    }
}