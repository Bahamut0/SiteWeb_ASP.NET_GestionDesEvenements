using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class InscriptionUserEvenementEM
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateResa { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Remarque { get; set; }

        public Nullable<int> IdUser { get; set; }
        public Nullable<int> IdEvenement { get; set; }

        public virtual Evenement Evenement { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaiementUserResa> PaiementUserResa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanningUserEvent> PlanningUserEvent { get; set; }
    }
}