﻿using System;
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
    public class AnnualTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: AnnualTables
        public ActionResult Index()
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            var annualTables = db.AnnualTables.Include(a => a.ProgramTable).Include(a => a.UserTable).Where(p=>p.IsActive==true);
            return View(annualTables.ToList());
        }

        // GET: AnnualTables/Details/5
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
            AnnualTable annualTable = db.AnnualTables.Find(id);
            if (annualTable == null)
            {
                return HttpNotFound();
            }
            return View(annualTable);
        }

        // GET: AnnualTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables.Where(p=>p.IsActive==true), "ProgramID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: AnnualTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnnualTable annualTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            annualTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.AnnualTables.Add(annualTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramID = new SelectList(db.ProgramTables.Where(P=>P.IsActive==true), "ProgramID", "Name", annualTable.ProgramID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", annualTable.UserID);
            return View(annualTable);
        }

        // GET: AnnualTables/Edit/5
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
            AnnualTable annualTable = db.AnnualTables.Find(id);
            if (annualTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables.Where(P => P.IsActive == true), "ProgramID", "Name", annualTable.ProgramID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", annualTable.UserID);
            return View(annualTable);
        }

        // POST: AnnualTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( AnnualTable annualTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            annualTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.Entry(annualTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables.Where(P => P.IsActive == true), "ProgramID", "Name", annualTable.ProgramID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", annualTable.UserID);
            return View(annualTable);
        }

        // GET: AnnualTables/Delete/5
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
            AnnualTable annualTable = db.AnnualTables.Find(id);
            if (annualTable == null)
            {
                return HttpNotFound();
            }
            return View(annualTable);
        }

        // POST: AnnualTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");

            }
            AnnualTable annualTable = db.AnnualTables.Find(id);
            db.AnnualTables.Remove(annualTable);
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