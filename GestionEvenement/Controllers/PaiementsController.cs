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
    public class PaiementsController : Controller
    {
        private GestionEvenementEntities db = new GestionEvenementEntities();

        // GET: Paiements
        public async Task<ActionResult> Index()
        {
            return View(await db.Paiement.ToListAsync());
        }

        // GET: Paiements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = await db.Paiement.FindAsync(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // GET: Paiements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paiements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Montant,Libelle,DatePaiement,PaiementAJour")] Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                db.Paiement.Add(paiement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paiement);
        }

        // GET: Paiements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = await db.Paiement.FindAsync(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            PaiementEM paiementAmodifier = new PaiementEM();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Paiement, PaiementEM>());
            var mapper = new Mapper(config);
            paiementAmodifier = mapper.Map<PaiementEM>(paiement);

            return View(paiementAmodifier);
        }

        // POST: Paiements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Montant,Libelle,DatePaiement,PaiementAJour")] Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paiement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paiement);
        }

        // GET: Paiements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = await db.Paiement.FindAsync(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // POST: Paiements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Paiement paiement = await db.Paiement.FindAsync(id);
            db.Paiement.Remove(paiement);
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
