using GestionEvenement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class PaiementEM
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Champ requis")]
        public Nullable<int> Montant { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public string Libelle { get; set; }

        public Nullable<System.DateTime> DatePaiement { get; set; }

        public Nullable<bool> PaiementAJour { get; set; }

        public virtual ICollection<PaiementUserResa> PaiementUserResa { get; set; }
    }
}