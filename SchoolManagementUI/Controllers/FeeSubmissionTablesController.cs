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
    public class FeeSubmissionTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: FeeSubmissionTables
        public ActionResult Index()
        {
            var feeSubmissionTables = db.FeeSubmissionTables.Include(f => f.ClassTable).Include(f => f.ProgramTable).Include(f => f.StudentTable).Include(f => f.UserTable);
            return View(feeSubmissionTables.ToList());
        }

        // GET: FeeSubmissionTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeSubmissionTable feeSubmissionTable = db.FeeSubmissionTables.Find(id);
            if (feeSubmissionTable == null)
            {
                return HttpNotFound();
            }
            return View(feeSubmissionTable);
        }

        // GET: FeeSubmissionTables/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: FeeSubmissionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubmissionFeeID,UserID,ClassID,StudentID,Amount,ProgramID,SubmissionDate,FeesMonth,Description")] FeeSubmissionTable feeSubmissionTable)
        {
            if (ModelState.IsValid)
            {
                db.FeeSubmissionTables.Add(feeSubmissionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", feeSubmissionTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", feeSubmissionTable.ProgramID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", feeSubmissionTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", feeSubmissionTable.UserID);
            return View(feeSubmissionTable);
        }

        // GET: FeeSubmissionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeSubmissionTable feeSubmissionTable = db.FeeSubmissionTables.Find(id);
            if (feeSubmissionTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", feeSubmissionTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", feeSubmissionTable.ProgramID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", feeSubmissionTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", feeSubmissionTable.UserID);
            return View(feeSubmissionTable);
        }

        // POST: FeeSubmissionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubmissionFeeID,UserID,ClassID,StudentID,Amount,ProgramID,SubmissionDate,FeesMonth,Description")] FeeSubmissionTable feeSubmissionTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feeSubmissionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", feeSubmissionTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", feeSubmissionTable.ProgramID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", feeSubmissionTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", feeSubmissionTable.UserID);
            return View(feeSubmissionTable);
        }

        // GET: FeeSubmissionTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeSubmissionTable feeSubmissionTable = db.FeeSubmissionTables.Find(id);
            if (feeSubmissionTable == null)
            {
                return HttpNotFound();
            }
            return View(feeSubmissionTable);
        }

        // POST: FeeSubmissionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeeSubmissionTable feeSubmissionTable = db.FeeSubmissionTables.Find(id);
            db.FeeSubmissionTables.Remove(feeSubmissionTable);
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
