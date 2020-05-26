using GestionEvenement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class UsersEM
    {

        public int Id { get; set; }

  
        public string Nom { get; set; }


        public string Prenom { get; set; }


        public Nullable<System.DateTime> DateNaissance { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public string Mail { get; set; }

        public Nullable<bool> Genre { get; set; }

        public Nullable<int> Telephone { get; set; }

        //[Display(Name = "Votre photo !")]
        public string Photo { get; set; }

        public Nullable<System.DateTime> DateAdhesion { get; set; }

        public Nullable<int> IdTrancheAge { get; set; }
        public Nullable<int> IdRole { get; set; }
        public Nullable<int> IdAdresse { get; set; }

        public virtual Adresse Adresse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InscriptionUserEvenement> InscriptionUserEvenement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaiementUserResa> PaiementUserResa { get; set; }
        public virtual Role Role { get; set; }
        public virtual TrancheAge TrancheAge { get; set; }


    }
}