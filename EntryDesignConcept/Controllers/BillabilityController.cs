using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntryDesignConcept.Models;
using EntryDesignConcept.AppContext;

namespace EntryDesignConcept.Controllers
{
    public class BillabilityController : Controller
    {
        private BillabilityContext db = new BillabilityContext();
        //
        // GET: /Billability/
        public ActionResult Index()
        {
            return View(db.Fetch);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Billability newData)
        {
            db.Insert(newData);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {            
            return View(db.Fetch.Single(a => a.ID == id));
        }
        [HttpPost]
        public ActionResult Edit(Billability updatedData, int id)
        {
            db.Update(updatedData, id);
            return RedirectToAction("Index");
        }
	}
}