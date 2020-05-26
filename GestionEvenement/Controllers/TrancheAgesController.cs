using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionEvenement.Models.Model;
using GestionEvenement.Models;
using AutoMapper;

namespace GestionEvenement.Controllers
{
    public class TrancheAgesController : Controller
    {
        private GestionEvenementEntities db = new GestionEvenementEntities();

        // GET: TrancheAges
        public async Task<ActionResult> Index()
        {
            return View(await db.TrancheAge.ToListAsync());
        }

        // GET: TrancheAges/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrancheAge trancheAge = await db.TrancheAge.FindAsync(id);
            if (trancheAge == null)
            {
                return HttpNotFound();
            }
            return View(trancheAge);
        }

        // GET: TrancheAges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrancheAges/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Libelle,AgeMin,AgeMax")] TrancheAge trancheAge)
        {
            if (ModelState.IsValid)
            {
                db.TrancheAge.Add(trancheAge);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(trancheAge);
        }

        // GET: TrancheAges/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrancheAge trancheAge = await db.TrancheAge.FindAsync(id);
            if (trancheAge == null)
            {
                return HttpNotFound();
            }
            TrancheAgeEM trancheAgeAmodifier = new TrancheAgeEM();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TrancheAge, TrancheAgeEM>());
            var mapper = new Mapper(config);
            trancheAgeAmodifier = mapper.Map<TrancheAgeEM>(trancheAge);

            return View(trancheAgeAmodifier);
        }

        // POST: TrancheAges/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Libelle,AgeMin,AgeMax")] TrancheAge trancheAge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trancheAge).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trancheAge);
        }

        // GET: TrancheAges/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrancheAge trancheAge = await db.TrancheAge.FindAsync(id);
            if (trancheAge == null)
            {
                return HttpNotFound();
            }
            return View(trancheAge);
        }

        // POST: TrancheAges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TrancheAge trancheAge = await db.TrancheAge.FindAsync(id);
            db.TrancheAge.Remove(trancheAge);
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
