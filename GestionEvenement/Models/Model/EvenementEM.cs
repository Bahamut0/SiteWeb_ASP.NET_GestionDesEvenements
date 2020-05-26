using GestionEvenement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class EvenementEM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public string Libelle { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public string Description { get; set; }

        [Display(Name = "Votre photo !")]
        [Required(ErrorMessage = "Champ requis")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public Nullable<System.DateTime> DateDebut { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public Nullable<System.DateTime> DateFin { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public Nullable<int> Duree { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        public Nullable<System.DateTime> DateLimiteInscription { get; set; }
       
        //si vous vous rendez sur la vue create de evenement, vous verez que les erreurs s'effacent
        //idem pour userEM
        //il faut ajouter tout ce qui est dans le model Evenement dans EvenementEM
        //il faut ajouter tout ce qui est dans le model User dans UserEM
        //vous avez tjs les erreurs sur la vue create ? 

        public Nullable<int> IdType { get; set; }
        public Nullable<int> IdTrancheAge { get; set; }
        public Nullable<int> IdAdresse { get; set; }

        public virtual Adresse Adresse { get; set; }
        public virtual TrancheAge TrancheAge { get; set; }
        public virtual Type Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InscriptionUserEvenement> InscriptionUserEvenement { get; set; }

    }
}