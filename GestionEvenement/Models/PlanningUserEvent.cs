//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionEvenement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlanningUserEvent
    {
        public int Id { get; set; }
        public Nullable<int> IdPlanning { get; set; }
        public Nullable<int> IdInscriptionUserEvenement { get; set; }
    
        public virtual InscriptionUserEvenement InscriptionUserEvenement { get; set; }
        public virtual Planning Planning { get; set; }
    }
}
