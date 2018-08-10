using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShopWithShoppingCart.Models;
using System.IO;

namespace OnlineShopWithShoppingCart.Controllers
{
    [Authorize(Users = "admin@gmail.com")]
    public class DebartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Debartments
        public ActionResult Index()
        {
            var debartments = db.Debartments.Include(d => d.Category);
         

            return View(debartments.ToList());
           
        }

        // GET: Debartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debartment debartment = db.Debartments.Find(id);
            if (debartment == null)
            {
                return HttpNotFound();
            }
            return View(debartment);
        }

        // GET: Debartments/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Debartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Debartment debartment, HttpPostedFileBase uploads)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/upload"), uploads.FileName);
                uploads.SaveAs(path);
                debartment.Image = uploads.FileName;

                db.Debartments.Add(debartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", debartment.CategoryId);
            return View(debartment);
        }

       

        // GET: Debartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debartment debartment = db.Debartments.Find(id);
            if (debartment == null)
            {
                return HttpNotFound();
            }
            return View(debartment);
        }

        // POST: Debartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Debartment debartment = db.Debartments.Find(id);
            db.Debartments.Remove(debartment);
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
