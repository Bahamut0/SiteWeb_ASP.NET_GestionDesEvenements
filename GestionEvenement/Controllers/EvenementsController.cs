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
using System.Configuration;
using System.IO;
using System.Web.Security;

namespace GestionEvenement.Controllers
{
    
    public class EvenementsController : Controller
    {
        private GestionEvenementEntities db = new GestionEvenementEntities();

        // GET: Evenements
        

        public async Task<ActionResult> Index()
        {
            var evenement = db.Evenement.Include(e => e.Adresse).Include(e => e.TrancheAge).Include(e => e.Type);
            return View(await evenement.ToListAsync());
        }

        // GET: Evenements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenement evenement = await db.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        // GET: Evenements/Create
        [Authorize(Roles = "Administrateur")]
        public ActionResult Create()
        {
            ViewBag.IdAdresse = new SelectList(db.Adresse, "Id", "Rue");
            ViewBag.IdTrancheAge = new SelectList(db.TrancheAge, "Id", "Libelle");
            ViewBag.IdType = new SelectList(db.Type, "Id", "Libelle");
            return View();
        }

        // POST: Evenements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Libelle,Description,Image,DateDebut,DateFin,Duree,DateLimiteInscription,IdType,IdTrancheAge")] Evenement evenement, Adresse adresse, Users currentUser)
        {
            if (ModelState.IsValid)
            {
                               
                //Adresse 
                db.Adresse.Add(adresse); 
                await db.SaveChangesAsync(); 
                db.Evenement.Add(evenement);
                evenement.IdAdresse = adresse.Id;
                await db.SaveChangesAsync(); 
                return RedirectToAction("Index");
            }

            //ViewBag.IdAdresse = new SelectList(db.Adresse, "Id", "Rue", evenement.IdAdresse);
            ViewBag.IdTrancheAge = new SelectList(db.TrancheAge, "Id", "Libelle", evenement.IdTrancheAge);
            ViewBag.IdType = new SelectList(db.Type, "Id", "Libelle", evenement.IdType);

           
            return View(evenement);
        }
        [Authorize(Roles = "Administrateur")]
        // GET: Evenements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenement evenement = await db.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAdresse = new SelectList(db.Adresse, "Id", "Rue", evenement.IdAdresse);
            ViewBag.IdTrancheAge = new SelectList(db.TrancheAge, "Id", "Libelle", evenement.IdTrancheAge);
            ViewBag.IdType = new SelectList(db.Type, "Id", "Libelle", evenement.IdType);

            EvenementEM eventModifie = new EvenementEM();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Evenement, EvenementEM>());
            var mapper = new Mapper(config);
            eventModifie = mapper.Map<EvenementEM>(evenement);

            return View(eventModifie);
        }

        // POST: Evenements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Libelle,Description,Image,DateDebut,DateFin,Duree,DateLimiteInscription,IdType,IdTrancheAge,IdAdresse")] Evenement evenement)
        {
           
            if (ModelState.IsValid)
            {
                //image par défaut pour la modification des événements
                if (evenement.Image == null)
                {
                    string eventImg = ConfigurationManager.AppSettings["eventImg"];
                    evenement.Image = eventImg;
                }
                db.Entry(evenement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdAdresse = new SelectList(db.Adresse, "Id", "Rue", evenement.IdAdresse);
            ViewBag.IdTrancheAge = new SelectList(db.TrancheAge, "Id", "Libelle", evenement.IdTrancheAge);
            ViewBag.IdType = new SelectList(db.Type, "Id", "Libelle", evenement.IdType);
            return View(evenement);
        }

        // GET: Evenements/Delete/5
        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenement evenement = await db.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Evenement evenement = await db.Evenement.FindAsync(id);
            db.Evenement.Remove(evenement);
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
