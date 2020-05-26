using GestionEvenement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEvenement.Models.Model
{
    public class RoleEM
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Champ requis")]
        public string Type { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}