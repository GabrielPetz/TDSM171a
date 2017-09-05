using GuitarsShop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuitarsShop.Models;
using System.Net;
using System.Data.Entity;

namespace GuitarsShop.Controllers
{
    public class GuitarsController : Controller
    {
        private readonly EFContext _context = new EFContext();
        // GET: Guitars
        public ActionResult Index()
        {
            return View(_context.Guitars.OrderBy(g => g.Brand));
        }

        #region Create

        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guitar guitar)
        {
            _context.Guitars.Add(guitar);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region Edit

        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var guitar = _context.Guitars.Find(id.Value);

            if (guitar == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(guitar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(guitar).State = EntityState.Modified;
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var guitar = _context.Guitars.Find(id.Value);

            if (guitar == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(guitar);
        }
        #endregion

        #region Delete

        public ActionResult Delete(long? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var guitar = _context.Guitars.Find(id.Value);

            if (guitar == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(guitar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                var s = _context.Guitars.Find(guitar.GuitarId);

                _context.Guitars.Remove(s);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(guitar);
        }
        #endregion
    }
}