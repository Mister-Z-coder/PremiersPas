using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Models
{
    public class Inscription : BaseEntity
    {
        public int EleveId { get; set; }
        public Eleve Eleve { get; set; }
        public int EcoleId { get; set; }
        public Ecole Ecole { get; set; }
        public int AnneeScolaireId { get; set; }
        public Annee_Scolaire AnneeScolaire { get; set; }
        public DateTime DateInscription { get; set; }

    }
}
