using GestionEvenement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class TrancheAgeEM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public string Libelle { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public Nullable<int> AgeMin { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public Nullable<int> AgeMax { get; set; }
                
        public virtual ICollection<Evenement> Evenement { get; set; }
        
        public virtual ICollection<Users> Users { get; set; }
    }
}