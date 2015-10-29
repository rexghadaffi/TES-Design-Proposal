using EntryDesignConcept.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntryDesignConcept.Controllers
{
    public class EntryController : Controller
    {
        private ActivityContext db = new ActivityContext();
        //
        // GET: /Entry/
        public ActionResult Index()
        {
            return View(db.GetAllActivities);
        }

        
	}
}