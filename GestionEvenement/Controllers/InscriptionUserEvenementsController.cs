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
using System.Web.Security;
using Microsoft.Ajax.Utilities;

namespace GestionEvenement.Controllers
{
    [Authorize]
    public class InscriptionUserEvenementsController : Controller
    {
        private GestionEvenementEntities db = new GestionEvenementEntities();

        // GET: InscriptionUserEvenements
        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult> Index(Users currentUser)
        {
            string email = User.Identity.Name;
            currentUser = db.Users.Where(x => x.Mail == email).SingleOrDefault();
            ViewBag.IdCurrentUser = currentUser.Id;
            ViewBag.EmailCurrentUser = currentUser.Mail;
            ViewBag.CurrentUser = currentUser;
            var inscriptionUserEvenement = db.InscriptionUserEvenement.Include(i => i.Evenement).Include(i => i.Users);

            return View(await inscriptionUserEvenement.ToListAsync());
        }
        public async Task<ActionResult> GetCurrentUserResa(Users currentUser)
        {
            string email = User.Identity.Name;
            currentUser = db.Users.Where(x => x.Mail == email).SingleOrDefault();
            ViewBag.IdCurrentUser = currentUser.Id;
            List<InscriptionUserEvenement> inscriptions = new List<InscriptionUserEvenement>();
            inscriptions = await db.InscriptionUserEvenement.Where(x => x.IdUser == currentUser.Id).ToListAsync();

            return View(inscriptions);
        }

        // GET: InscriptionUserEvenements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscriptionUserEvenement inscriptionUserEvenement = await db.InscriptionUserEvenement.FindAsync(id);
            if (inscriptionUserEvenement == null)
            {
                return HttpNotFound(); 
            }
            return View(inscriptionUserEvenement);
        }
      
        // GET: InscriptionUserEvenements/Create
        public ActionResult Create()
        {
            ViewBag.IdEvenement = new SelectList(db.Evenement, "Id", "Libelle");
            ViewBag.IdUser = new SelectList(db.Users, "Id", "Nom");
            return View();
        }

        // POST: InscriptionUserEvenements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id, IdUser,IdEvenement, Remarque")] InscriptionUserEvenement inscriptionUserEvenement, Users currentUser)
        {
            //retiré des paramètres : DateResa
            if (ModelState.IsValid)
            {
                //récupérer l'id de l'utilisateur courrant grâce à son email identique à l'utilisateur de la base Asp.Net
                string email = User.Identity.Name;
                currentUser = db.Users.Where(x => x.Mail == email).SingleOrDefault();
               inscriptionUserEvenement.IdUser = currentUser.Id;
                ViewBag.IdCurrentUser = currentUser.Id;
                // date d'inscription par défaut
                inscriptionUserEvenement.DateResa = DateTime.Today;
                db.InscriptionUserEvenement.Add(inscriptionUserEvenement);
                await db.SaveChangesAsync();
                return RedirectToAction("GetCurrentUserResa");
            }

            ViewBag.IdEvenement = new SelectList(db.Evenement, "Id", "Libelle", inscriptionUserEvenement.IdEvenement);
            ViewBag.IdUser = new SelectList(db.Users, "Id", "Nom", inscriptionUserEvenement.IdUser);

            return View(inscriptionUserEvenement);
        }

        // GET: InscriptionUserEvenements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscriptionUserEvenement inscriptionUserEvenement = await db.InscriptionUserEvenement.FindAsync(id);
            if (inscriptionUserEvenement == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEvenement = new SelectList(db.Evenement, "Id", "Libelle", inscriptionUserEvenement.IdEvenement);
            ViewBag.IdUser = new SelectList(db.Users, "Id", "Nom", inscriptionUserEvenement.IdUser);
            return View(inscriptionUserEvenement);
        }

        // POST: InscriptionUserEvenements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DateResa,Remarque,IdUser,IdEvenement")] InscriptionUserEvenement inscriptionUserEvenement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscriptionUserEvenement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("GetCurrentUserResa");
            }
            ViewBag.IdEvenement = new SelectList(db.Evenement, "Id", "Libelle", inscriptionUserEvenement.IdEvenement);
            ViewBag.IdUser = new SelectList(db.Users, "Id", "Nom", inscriptionUserEvenement.IdUser);
            return View(inscriptionUserEvenement);
        }

        // GET: InscriptionUserEvenements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscriptionUserEvenement inscriptionUserEvenement = await db.InscriptionUserEvenement.FindAsync(id);
            if (inscriptionUserEvenement == null)
            {
                return HttpNotFound();
            }
            return View(inscriptionUserEvenement);
        }

        // POST: InscriptionUserEvenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InscriptionUserEvenement inscriptionUserEvenement = await db.InscriptionUserEvenement.FindAsync(id);
            db.InscriptionUserEvenement.Remove(inscriptionUserEvenement);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
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
