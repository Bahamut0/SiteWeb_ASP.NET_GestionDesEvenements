﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GestionEvenementEntities : DbContext
    {
        public GestionEvenementEntities()
            : base("name=GestionEvenementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<Evenement> Evenement { get; set; }
        public virtual DbSet<InscriptionUserEvenement> InscriptionUserEvenement { get; set; }
        public virtual DbSet<Paiement> Paiement { get; set; }
        public virtual DbSet<PaiementUserResa> PaiementUserResa { get; set; }
        public virtual DbSet<Planning> Planning { get; set; }
        public virtual DbSet<PlanningUserEvent> PlanningUserEvent { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TrancheAge> TrancheAge { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
