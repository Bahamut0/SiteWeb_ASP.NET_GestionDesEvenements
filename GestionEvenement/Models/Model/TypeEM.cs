using GestionEvenement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class TypeEM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public string Libelle { get; set; }
        public virtual ICollection<Evenement> Evenement { get; set; }

    }
}