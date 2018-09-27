using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using Masonic.Blue.Admin.Models;
using Masonic.Blue.Admin.ViewModels;
using Masonic.Blue.Models;

namespace Masonic.Blue.Admin.Controllers
{
    public class ChartersController : Controller
    {
        private MasonicDbContext db = new MasonicDbContext();

        // GET: Charters
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var charters = db.Charters.Include(c => c.BodyType).Include(c => c.LodgeType).Select(
                c => new CharterListVm
                {
                    Id = c.Id,
                    Name = c.Name,
                    Number = c.Number,
                    BodyType = c.BodyType.Type,
                    LodgeType = c.LodgeType.Type,
                    City = c.City
                });
            return Json(new { data = charters }, JsonRequestBehavior.AllowGet);
        }

        // GET: Charters/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charter charter = await db.Charters.FindAsync(id);
            if (charter == null)
            {
                return HttpNotFound();
            }
            return View(charter);
        }

        // GET: Charters/Create
        public ActionResult Create()
        {
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "Id", "Type");
            ViewBag.LodgeTypeId = new SelectList(db.LodgeTypes, "Id", "Type");
            return View();
        }

        // POST: Charters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LodgeTypeId,BodyTypeId,Name,Address,Address2,City,PostalCode,DateCreated,DateModified")] Charter charter)
        {
            if (ModelState.IsValid)
            {
                db.Charters.Add(charter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "Id", "Type", charter.BodyTypeId);
            ViewBag.LodgeTypeId = new SelectList(db.LodgeTypes, "Id", "Type", charter.LodgeTypeId);
            return View(charter);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Charter());
            }
            else
            {
                return View(await db.Charters.FirstOrDefaultAsync(x => x.Id == id));
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(Charter currentCharter)
        {
            if (currentCharter.Id == 0)
            {
                db.Charters.Add(currentCharter);
                await db.SaveChangesAsync();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }

            db.Entry(currentCharter).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
        }

        // GET: Charters/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charter charter = await db.Charters.FindAsync(id);
            if (charter == null)
            {
                return HttpNotFound();
            }
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "Id", "Type", charter.BodyTypeId);
            ViewBag.LodgeTypeId = new SelectList(db.LodgeTypes, "Id", "Type", charter.LodgeTypeId);
            return View(charter);
        }

        // POST: Charters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LodgeTypeId,BodyTypeId,Name,Address,Address2,City,PostalCode,DateCreated,DateModified")] Charter charter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "Id", "Type", charter.BodyTypeId);
            ViewBag.LodgeTypeId = new SelectList(db.LodgeTypes, "Id", "Type", charter.LodgeTypeId);
            return View(charter);
        }

        // GET: Charters/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charter charter = await db.Charters.FindAsync(id);
            if (charter == null)
            {
                return HttpNotFound();
            }
            return View(charter);
        }

        // POST: Charters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Charter charter = await db.Charters.FindAsync(id);
            db.Charters.Remove(charter);
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
