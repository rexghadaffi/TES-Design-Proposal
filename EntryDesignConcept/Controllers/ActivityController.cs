using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntryDesignConcept.AppContext;
using EntryDesignConcept.Models;

namespace EntryDesignConcept.Controllers
{
    public class ActivityController : Controller
    {
        private ActivityContext db = new ActivityContext();
        //
        // GET: /Activity/
        public ActionResult Index()
        {
            return View(db.GetAllActivities);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Activity newData)
        {
            db.Insert(newData);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(db.GetAllActivities.Single(a => a.ID == id));
        }

        [HttpPost]
        public ActionResult Edit(Activity updateData, int id)
        {
            db.Update(updateData, id);
            return RedirectToAction("Index");
        }
	}
}