using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Models
{
    public class Eleve:BaseEntity
    {
        public string NomEleve { get; set; }
        public string PostNomEleve { get; set; }
        public string SexeEleve { get; set; }
        public string PhotoEleve { get; set; }
        public string LieuNaisEleve { get; set; }
        public string DateNaisEleve { get; set; }
        public ICollection<Inscription> Inscriptions { get; set; }

    }
}
