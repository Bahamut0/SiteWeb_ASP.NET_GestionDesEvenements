using GestionEvenement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class AdresseEM
    {

        public int Id { get; set; }

        public Nullable<int> Numero { get; set; }

        public string Rue { get; set; }

        [Required(ErrorMessage ="Champ requis")]
        public Nullable<int> CodePostal { get; set; }

        public string Ville { get; set; }

        public virtual ICollection<Evenement> Evenement { get; set; }
       
        public virtual ICollection<Users> Users { get; set; }
    }
}