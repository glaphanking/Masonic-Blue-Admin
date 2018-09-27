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
    public class LodgeTypesController : Controller
    {
        private MasonicDbContext db = new MasonicDbContext();

        // GET: LodgeTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.LodgeTypes.ToListAsync());
        }

        // GET: LodgeTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LodgeType lodgeType = await db.LodgeTypes.FindAsync(id);
            if (lodgeType == null)
            {
                return HttpNotFound();
            }
            return View(lodgeType);
        }

        // GET: LodgeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LodgeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type,DateCreated,DateModified")] LodgeType lodgeType)
        {
            if (ModelState.IsValid)
            {
                db.LodgeTypes.Add(lodgeType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lodgeType);
        }

        // GET: LodgeTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LodgeType lodgeType = await db.LodgeTypes.FindAsync(id);
            if (lodgeType == null)
            {
                return HttpNotFound();
            }
            return View(lodgeType);
        }

        // POST: LodgeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type,DateCreated,DateModified")] LodgeType lodgeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lodgeType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lodgeType);
        }

        // GET: LodgeTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LodgeType lodgeType = await db.LodgeTypes.FindAsync(id);
            if (lodgeType == null)
            {
                return HttpNotFound();
            }
            return View(lodgeType);
        }

        // POST: LodgeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LodgeType lodgeType = await db.LodgeTypes.FindAsync(id);
            db.LodgeTypes.Remove(lodgeType);
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
