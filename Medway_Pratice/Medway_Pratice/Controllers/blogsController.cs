using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;

namespace Medway_Pratice.Controllers
{
    public class blogsController : baseController
    {
        // GET: blogs
        public ActionResult Index(int? month,int? year)
        {
            vwBlog data = new vwBlog
            {
                Dates = db.Blogs.GroupBy(g => new { g.Date.Value.Month,g.Date.Value.Year}).Select(b=>new Dates { Month=b.Key.Month,Year=b.Key.Year}).OrderBy(d=>d.Month).OrderBy(d=>d.Year).ToList()
            };

            data.SelectedMonth = month ?? DateTime.Now.Month;
            data.SelecetedYear = year ?? DateTime.Now.Year;

            if (!data.Dates.Exists(b => b.Month == data.SelectedMonth && b.Year == data.SelecetedYear))
            {
                return HttpNotFound();
            } 

            data.Blogs = db.Blogs.Where(b => b.Date.Value.Year == data.SelecetedYear && b.Date.Value.Month == data.SelectedMonth).OrderByDescending(b => b.Date).ToList();

            return View(data);
        }
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }

            Blog blog = db.Blogs.Find(id);

            if (blog==null)
            {
                return HttpNotFound();
            }

            ViewBag.Blogs = db.Blogs.Where(b => b.Id != id).OrderByDescending(b => b.Date).ToList();

            return View(blog);
        }
    }
}