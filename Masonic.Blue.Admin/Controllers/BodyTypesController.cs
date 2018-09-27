using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Masonic.Blue.Admin.Models;
using Masonic.Blue.Models;

namespace Masonic.Blue.Admin.Controllers
{
    public class BodyTypesController : Controller
    {
        private MasonicDbContext db = new MasonicDbContext();

        // GET: BodyTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.BodyTypes.ToListAsync());
        }

        // GET: BodyTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyType bodyType = await db.BodyTypes.FindAsync(id);
            if (bodyType == null)
            {
                return HttpNotFound();
            }
            return View(bodyType);
        }

        // GET: BodyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BodyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type,DateCreated,DateModified")] BodyType bodyType)
        {
            if (ModelState.IsValid)
            {
                db.BodyTypes.Add(bodyType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bodyType);
        }

        // GET: BodyTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyType bodyType = await db.BodyTypes.FindAsync(id);
            if (bodyType == null)
            {
                return HttpNotFound();
            }
            return View(bodyType);
        }

        // POST: BodyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type,DateCreated,DateModified")] BodyType bodyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodyType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bodyType);
        }

        // GET: BodyTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyType bodyType = await db.BodyTypes.FindAsync(id);
            if (bodyType == null)
            {
                return HttpNotFound();
            }
            return View(bodyType);
        }

        // POST: BodyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BodyType bodyType = await db.BodyTypes.FindAsync(id);
            db.BodyTypes.Remove(bodyType);
            await db.SaveChangesAsync();
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
