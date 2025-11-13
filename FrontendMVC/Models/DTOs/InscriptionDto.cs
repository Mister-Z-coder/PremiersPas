using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC.Models.DTOs
{
    public class InscriptionDto: BaseDto
    {
        public int EleveId { get; set; }
        public int EcoleId { get; set; }
        public int AnneeScolaireId { get; set; }
        public DateTime DateInscription { get; set; }

    }
}
