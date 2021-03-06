﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskScheduler.Models;
using Microsoft.AspNet.Identity;

namespace TaskScheduler.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userAccountRole = db.UserAccounts.Where(u => u.ApplicationUserId == userId).First().UserRole;
            if (userAccountRole == "Manager")
            {
                return View(db.Projects.ToList());
            }
            else
            {
                return RedirectToAction("EmployeeIndex", "Projects");
            }
        }

        public ActionResult EmployeeIndex()
        {
            var userId = User.Identity.GetUserId();
            var userAccountRole = db.UserAccounts.Where(u => u.ApplicationUserId == userId).First().UserRole;
            var userAccountName = db.UserAccounts.Where(u => u.ApplicationUserId == userId).First().FirstName;
            var empProject = (from proj in db.Projects
                             where proj.assignedTo.Contains(userAccountName)
                             select proj).ToList();
            return View(empProject);
        }

        // GET: Projects/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        [Authorize]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var userAccountRole = db.UserAccounts.Where(u => u.ApplicationUserId == userId).First().UserRole;
            
            var emps = (from emp in db.UserAccounts
                       where emp.UserRole.Contains("Employee")
                       select emp.FirstName).ToList();
            ViewBag.empNames = new string[emps.Count];
            for (var i = 0; i < emps.Count; i++)
            {
                ViewBag.empNames[i] = emps[i];
            }
                if (userAccountRole == "Manager")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("ErrorLogin", "Account");
                }
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "id,name,projectDesc,assignedTo,startDate,endDate,status")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            var userId = User.Identity.GetUserId();
            var userAccountRole = db.UserAccounts.Where(u => u.ApplicationUserId == userId).First().UserRole;
            var emps = (from emp in db.UserAccounts
                        where emp.UserRole.Contains("Employee")
                        select emp.FirstName).ToList();
            ViewBag.empNames = new string[emps.Count];
            for (var i = 0; i < emps.Count; i++)
            {
                ViewBag.empNames[i] = emps[i];
            }
            if (userAccountRole == "Manager")
            {
                ViewBag.Role = "Manager";
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "id,name,projectDesc,assignedTo,startDate,endDate,status")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            var userId = User.Identity.GetUserId();
            var userAccountRole = db.UserAccounts.Where(u => u.ApplicationUserId == userId).First().UserRole;
            if (userAccountRole == "Manager")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Project project = db.Projects.Find(id);
                if (project == null)
                {
                    return HttpNotFound();
                }
                return View(project);
            }
            else
            {
                return RedirectToAction("ErrorLogin", "Account");
            }
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
