using EntryDesignConcept.AppContext;
using EntryDesignConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntryDesignConcept.Controllers
{
    public class PositionController : Controller
    {
        private PositionContext db = new PositionContext();
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
        public ActionResult Create(Position newData)
        {
            db.Insert(newData);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(db.GetAllActivities.Single(a => a.ID == id));
        }

        [HttpPost]
        public ActionResult Edit(Position updateData, int id)
        {
            db.Update(updateData, id);
            return RedirectToAction("Index");
        }
	}
}