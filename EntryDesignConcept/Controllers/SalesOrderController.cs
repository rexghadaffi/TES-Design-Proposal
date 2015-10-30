using EntryDesignConcept.AppContext;
using EntryDesignConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntryDesignConcept.Controllers
{
    public class SalesOrderController : Controller
    {
        private SalesOrderContext db = new SalesOrderContext();
        private OrganizationContext dbOrg = new OrganizationContext();
        private TeamContext dbTeam = new TeamContext();
        private UserContext dbUser = new UserContext();

        public ActionResult Index()
        {
            return View(db.GetAllUsers);
        }
        public ActionResult Create()
        {
            CreateDropDowns();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SalesOrder newData)
        {
            CreateDropDowns();
            db.Insert(newData);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {

            SalesOrder user = db.GetAllUsers.Single(a => a.ID == id);
            SetDropDowns(user);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(SalesOrder updatedData, int id)
        {
            SetDropDowns(updatedData);
            db.Update(updatedData, id);
            return RedirectToAction("Index");
        }

        public void CreateDropDowns()
        {
            ViewBag.Manager = new SelectList(dbUser.GetAllUsers, "ID", "Fullname");
            ViewBag.BusinessUnit = new SelectList(dbOrg.Fetch, "ID", "Name");
            ViewBag.Team = new SelectList(dbTeam.Fetch, "ID", "Name");
        }

        public void SetDropDowns(SalesOrder user)
        {
            ViewBag.Manager = new SelectList(dbUser.GetAllUsers, "ID", "Fullname", user.Manager.ID);
            ViewBag.BusinessUnit = new SelectList(dbOrg.Fetch, "ID", "Name", user.Organization.ID);
            ViewBag.Team = new SelectList(dbTeam.Fetch, "ID", "Name", user.Team.ID);
        }
	}
}