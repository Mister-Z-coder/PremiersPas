using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.DTOs
{
    public class EleveDto:BaseDto
    {
        public string NomEleve { get; set; }
        public string PostNomEleve { get; set; }
        public string SexeEleve { get; set; }
        public string PhotoEleve { get; set; }
        public string LieuNaisEleve { get; set; }
        public string DateNaisEleve { get; set; }

    }
}
