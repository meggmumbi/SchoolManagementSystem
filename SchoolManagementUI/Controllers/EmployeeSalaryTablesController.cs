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
    public class EmployeeSalaryTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: EmployeeSalaryTables
        public ActionResult Index()
        {
            var employeeSalaryTables = db.EmployeeSalaryTables.Include(e => e.StaffTable).Include(e => e.UserTable);
            return View(employeeSalaryTables.ToList());
        }

        // GET: EmployeeSalaryTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalaryTable employeeSalaryTable = db.EmployeeSalaryTables.Find(id);
            if (employeeSalaryTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeSalaryTable);
        }

        // GET: EmployeeSalaryTables/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: EmployeeSalaryTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeSalaryID,UserID,StaffID,Amount,SalaryMonth,SalaryYear,SalaryDate,Comments")] EmployeeSalaryTable employeeSalaryTable)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeSalaryTables.Add(employeeSalaryTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", employeeSalaryTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", employeeSalaryTable.UserID);
            return View(employeeSalaryTable);
        }

        // GET: EmployeeSalaryTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalaryTable employeeSalaryTable = db.EmployeeSalaryTables.Find(id);
            if (employeeSalaryTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", employeeSalaryTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", employeeSalaryTable.UserID);
            return View(employeeSalaryTable);
        }

        // POST: EmployeeSalaryTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeSalaryID,UserID,StaffID,Amount,SalaryMonth,SalaryYear,SalaryDate,Comments")] EmployeeSalaryTable employeeSalaryTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeSalaryTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", employeeSalaryTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", employeeSalaryTable.UserID);
            return View(employeeSalaryTable);
        }

        // GET: EmployeeSalaryTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalaryTable employeeSalaryTable = db.EmployeeSalaryTables.Find(id);
            if (employeeSalaryTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeSalaryTable);
        }

        // POST: EmployeeSalaryTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeSalaryTable employeeSalaryTable = db.EmployeeSalaryTables.Find(id);
            db.EmployeeSalaryTables.Remove(employeeSalaryTable);
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
