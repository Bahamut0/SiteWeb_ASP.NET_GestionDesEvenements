using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionEvenement.Models;
using GestionEvenement.Models.Model;
using AutoMapper;

namespace GestionEvenement.Controllers
{
    public class PlanningsController : Controller
    {
        private GestionEvenementEntities db = new GestionEvenementEntities();

        // GET: Plannings
        public async Task<ActionResult> Index()
        {
            return View(await db.Planning.ToListAsync());
        }

        // GET: Plannings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planning planning = await db.Planning.FindAsync(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            return View(planning);
        }

        // GET: Plannings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plannings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Horaire,EstDispo")] Planning planning)
        {
            if (ModelState.IsValid)
            {
                db.Planning.Add(planning);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(planning);
        }

        // GET: Plannings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planning planning = await db.Planning.FindAsync(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            PlanningEM planingAmodifier = new PlanningEM();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Planning, PlanningEM>());
            var mapper = new Mapper(config);
            planingAmodifier = mapper.Map<PlanningEM>(planning);

            return View(planingAmodifier);
        }

        // POST: Plannings/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Horaire,EstDispo")] Planning planning)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planning).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(planning);
        }

        // GET: Plannings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planning planning = await db.Planning.FindAsync(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            return View(planning);
        }

        // POST: Plannings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Planning planning = await db.Planning.FindAsync(id);
            db.Planning.Remove(planning);
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
