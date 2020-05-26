using GestionEvenement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class PlanningEM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public Nullable<int> Horaire { get; set; }

        public Nullable<bool> EstDispo { get; set; }

        
        public virtual ICollection<PlanningUserEvent> PlanningUserEvent { get; set; }
    }
}