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
using System.IO;

namespace GestionEvenement.Controllers
{
    public class UsersController : Controller
    {
        private GestionEvenementEntities db = new GestionEvenementEntities();

        // GET: Users
        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.Adresse).Include(u => u.Role).Include(u => u.TrancheAge);
            return View(await users.ToListAsync());
        }
        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        // GET: GetCurrentUser
        public async Task<ActionResult> GetCurrentUser(Users currentUser)
        {
            string email = User.Identity.Name;
            currentUser = db.Users.Where(x => x.Mail == email).SingleOrDefault();           
            ViewBag.IdCurrentUser = currentUser.Id;
            return View(await db.Users.FindAsync(currentUser.Id));
        }


        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.IdAdresse = new SelectList(db.Adresse, "Id", "Rue");           
            ViewBag.IdRole = new SelectList(db.Role, "Id", "Type");
            ViewBag.IdTrancheAge = new SelectList(db.TrancheAge, "Id", "Libelle");        
            return View();
        }

        // POST: Users/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nom,Prenom,DateNaissance,Genre,Mail,Telephone,Photo,DateAdhesion,IdTrancheAge,IdRole,IdAdresse")] Users users, Adresse adresse)
            
        {
            //retiré des paramètres
            /*,DateAdhesion,IdTrancheAge,IdRole,IdAdresse*/
            if (ModelState.IsValid)
            {
                //date adhesion automatique
                users.DateAdhesion =  DateTime.Today;                             
                List<Role> liste_role = db.Role.ToList();               
                // on récupère le role qui correspond à Adhérent dans la liste des roles (c'est l'id 3, le 2 est le modérateur et le 1 est l'Administrateur )
                users.Role = liste_role.Where(r => r.Id == 3).SingleOrDefault();              
                //Adresse 
                db.Adresse.Add(adresse);
                await db.SaveChangesAsync();
                db.Users.Add(users);
                users.IdAdresse = adresse.Id; 
                db.Users.Add(users);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }          
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
                     
            ViewBag.IdAdresse = new SelectList(db.Adresse, "Id", "Rue", users.IdAdresse);
            ViewBag.IdRole = new SelectList(db.Role, "Id", "Type", users.IdRole);
            ViewBag.IdTrancheAge = new SelectList(db.TrancheAge, "Id", "Libelle", users.IdTrancheAge);
            //Session["Mail"] = users.Mail;
            UsersEM userModifie = new UsersEM();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Users, UsersEM>());
            var mapper = new Mapper(config);
            userModifie = mapper.Map<UsersEM>(users);
            return View(userModifie);
        }
        
        // POST: Users/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nom,Prenom,DateNaissance,Genre,Mail,Telephone,Photo ,DateAdhesion,IdTrancheAge,IdRole,IdAdresse")] Users users)
        {

            //Paramètre retiré : ,DateAdhesion,IdTrancheAge,IdRole,IdAdresse
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("GetCurrentUser");
            }
            ViewBag.IdAdresse = new SelectList(db.Adresse, "Id", "Rue", users.IdAdresse);
            ViewBag.IdRole = new SelectList(db.Role, "Id", "Type", users.IdRole);
            ViewBag.IdTrancheAge = new SelectList(db.TrancheAge, "Id", "Libelle", users.IdTrancheAge);
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Users users = await db.Users.FindAsync(id);
            db.Users.Remove(users);
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
