using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer;

namespace SchoolManagementUI.Controllers
{
    public class TimeTblTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: TimeTblTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            var timeTblTables = db.TimeTblTables.Include(t => t.ClassSubjectTable).Include(t => t.ClassTable).Include(t => t.StaffTable).Include(t => t.TimeTblTable1).Include(t => t.TimeTblTable2).Include(t => t.UserTable);
            return View(timeTblTables.ToList());
        }

        // GET: TimeTblTables/Details/5
        public ActionResult Details(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTblTable timeTblTable = db.TimeTblTables.Find(id);
            if (timeTblTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTblTable);
        }

        // GET: TimeTblTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name");
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name");
            ViewBag.TimeTableID = new SelectList(db.TimeTblTables, "TimeTableID", "Day");
            ViewBag.TimeTableID = new SelectList(db.TimeTblTables, "TimeTableID", "Day");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: TimeTblTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeTableID,UserID,StaffID,StartTime,EndTime,Day,ClassSubjectID,IsActive,ClassID")] TimeTblTable timeTblTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            if (ModelState.IsValid)
            {
                db.TimeTblTables.Add(timeTblTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", timeTblTable.ClassSubjectID);
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", timeTblTable.ClassID);
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", timeTblTable.StaffID);
            ViewBag.TimeTableID = new SelectList(db.TimeTblTables, "TimeTableID", "Day", timeTblTable.TimeTableID);
            ViewBag.TimeTableID = new SelectList(db.TimeTblTables, "TimeTableID", "Day", timeTblTable.TimeTableID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTblTable.UserID);
            return View(timeTblTable);
        }

        // GET: TimeTblTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTblTable timeTblTable = db.TimeTblTables.Find(id);
            if (timeTblTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", timeTblTable.ClassSubjectID);
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", timeTblTable.ClassID);
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", timeTblTable.StaffID);
            ViewBag.TimeTableID = new SelectList(db.TimeTblTables, "TimeTableID", "Day", timeTblTable.TimeTableID);
            ViewBag.TimeTableID = new SelectList(db.TimeTblTables, "TimeTableID", "Day", timeTblTable.TimeTableID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTblTable.UserID);
            return View(timeTblTable);
        }

        // POST: TimeTblTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeTableID,UserID,StaffID,StartTime,EndTime,Day,ClassSubjectID,IsActive,ClassID")] TimeTblTable timeTblTable)
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            if (ModelState.IsValid)
            {
                db.Entry(timeTblTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", timeTblTable.ClassSubjectID);
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", timeTblTable.ClassID);
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", timeTblTable.StaffID);
            ViewBag.TimeTableID = new SelectList(db.TimeTblTables, "TimeTableID", "Day", timeTblTable.TimeTableID);
            ViewBag.TimeTableID = new SelectList(db.TimeTblTables, "TimeTableID", "Day", timeTblTable.TimeTableID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTblTable.UserID);
            return View(timeTblTable);
        }

        // GET: TimeTblTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTblTable timeTblTable = db.TimeTblTables.Find(id);
            if (timeTblTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTblTable);
        }

        // POST: TimeTblTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            TimeTblTable timeTblTable = db.TimeTblTables.Find(id);
            db.TimeTblTables.Remove(timeTblTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
