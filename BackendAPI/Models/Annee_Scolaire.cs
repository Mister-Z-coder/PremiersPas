using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Models
{
    public class Annee_Scolaire
    {
        [Key]
        public int AnneeScolaire { get; set; }
        public ICollection<Inscription> Inscriptions { get; set; }
    }
}
