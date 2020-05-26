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
    public class AdressesController : Controller
    {
        private GestionEvenementEntities db = new GestionEvenementEntities();

        // GET: Adresses
        public async Task<ActionResult> Index()
        {
            return View(await db.Adresse.ToListAsync());
        }

        // GET: Adresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresse adresse = await db.Adresse.FindAsync(id);
            if (adresse == null)
            {
                return HttpNotFound();
            }
            return View(adresse);
        }

        // GET: Adresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adresses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Numero,Rue,CodePostal,Ville")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                db.Adresse.Add(adresse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(adresse);
        }

        // GET: Adresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresse adresse = await db.Adresse.FindAsync(id);
            if (adresse == null)
            {
                return HttpNotFound();
            }

            AdresseEM adresseAmodifier = new AdresseEM();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Adresse, AdresseEM>());
            var mapper = new Mapper(config);
            adresseAmodifier = mapper.Map<AdresseEM>(adresse);

            return View(adresseAmodifier);
        }

        // POST: Adresses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Numero,Rue,CodePostal,Ville")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(adresse);
        }

        // GET: Adresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresse adresse = await db.Adresse.FindAsync(id);
            if (adresse == null)
            {
                return HttpNotFound();
            }
            return View(adresse);
        }

        // POST: Adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Adresse adresse = await db.Adresse.FindAsync(id);
            db.Adresse.Remove(adresse);
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
