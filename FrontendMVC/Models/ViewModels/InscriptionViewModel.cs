using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC.Models.ViewModels
{
    public class InscriptionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Élève")]
        public int EleveId { get; set; }

        [Required]
        [Display(Name = "École")]
        public int EcoleId { get; set; }

        [Required]
        [Display(Name = "Année scolaire")]
        public int AnneeScolaireId { get; set; }

        [Display(Name = "Date d'inscription")]
        [DataType(DataType.Date)]
        public DateTime DateInscription { get; set; }

        // Ces propriétés serviront pour remplir les menus déroulants dans ta vue Razor :
        public SelectList? Eleves { get; set; }
        public SelectList? Ecoles { get; set; }
        public SelectList? AnneesScolaires { get; set; }
    }
}
