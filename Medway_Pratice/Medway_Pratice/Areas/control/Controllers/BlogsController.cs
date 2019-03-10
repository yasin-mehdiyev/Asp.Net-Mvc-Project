using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;

namespace Medway_Pratice.Areas.control.Controllers
{
    public class BlogsController : Controller
    {
        private MedwayEntities db = new MedwayEntities();

        // GET: control/Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: control/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: control/Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: control/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Photo,Date,Text")] Blog blog,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo!=null)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    Photo.SaveAs(path);
                    blog.Photo = filename;
                }
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: control/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: control/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Photo,Date,Text")] Blog blog,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = System.Data.Entity.EntityState.Modified;

                if (Photo != null)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    Photo.SaveAs(path);
                    blog.Photo = filename;
                }
                else
                {
                    db.Entry(blog).Property(b => b.Photo).IsModified = false;
                }
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: control/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: control/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
