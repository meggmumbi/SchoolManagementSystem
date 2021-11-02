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
    public class ProgramSessionTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: ProgramSessionTables
        public ActionResult Index()
        {
            var programSessionTables = db.ProgramSessionTables.Include(p => p.ProgramTable).Include(p => p.SessionTable).Include(p => p.UserTable);
            return View(programSessionTables.ToList());
        }

        // GET: ProgramSessionTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSessionTable programSessionTable = db.ProgramSessionTables.Find(id);
            if (programSessionTable == null)
            {
                return HttpNotFound();
            }
            return View(programSessionTable);
        }

        // GET: ProgramSessionTables/Create
        public ActionResult Create()
        {
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name");
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: ProgramSessionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramSessionID,UserID,SessionID,ProgramID,Title,RegDate,Description")] ProgramSessionTable programSessionTable)
        {
            if (ModelState.IsValid)
            {
                db.ProgramSessionTables.Add(programSessionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSessionTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSessionTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSessionTable.UserID);
            return View(programSessionTable);
        }

        // GET: ProgramSessionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSessionTable programSessionTable = db.ProgramSessionTables.Find(id);
            if (programSessionTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSessionTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSessionTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSessionTable.UserID);
            return View(programSessionTable);
        }

        // POST: ProgramSessionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramSessionID,UserID,SessionID,ProgramID,Title,RegDate,Description")] ProgramSessionTable programSessionTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programSessionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSessionTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSessionTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSessionTable.UserID);
            return View(programSessionTable);
        }

        // GET: ProgramSessionTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSessionTable programSessionTable = db.ProgramSessionTables.Find(id);
            if (programSessionTable == null)
            {
                return HttpNotFound();
            }
            return View(programSessionTable);
        }

        // POST: ProgramSessionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramSessionTable programSessionTable = db.ProgramSessionTables.Find(id);
            db.ProgramSessionTables.Remove(programSessionTable);
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
