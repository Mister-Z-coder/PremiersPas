using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.DTOs
{
    public class EcoleDto: BaseDto
    {
        public string Matricule_Secope { get; set; }
        public string TitreEcole { get; set; }
        public string AdresseEcole { get; set; }
        public string PhotoEcole { get; set; }
        public string HistoriqueEcole { get; set; }
        public string Arrete_Agreement { get; set; }
        public double LatitudeEcole { get; set; }
        public double LongitudeEcole { get; set; }
    }
}
