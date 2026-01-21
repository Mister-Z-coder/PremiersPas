using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC.Models.ViewModels
{
    public class EleveViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Champ nom oblligatoire.")]
        [Display(Name = "Nom")]
        public string NomEleve { get; set; }

        [Required(ErrorMessage ="Champ PostNom obligatoire.")]
        [Display(Name = "Post-nom")]
        public string PostNomEleve { get; set; }

        [Required(ErrorMessage ="Champ Sexe oblogatoire.")]
        [Display(Name = "Sexe")]
        public string SexeEleve { get; set; }

        [Display(Name = "Photo")]
        public IFormFile? PhotoFile { get; set; } // upload dans le formulaire

        public string? PhotoEleveUrl { get; set; } // chemin de l'image déjà stockée

        [Required(ErrorMessage ="Champ Lieu de naissance oblogatoire.")]
        [Display(Name = "Lieu de naissance")]
        public string LieuNaisEleve { get; set; }

        [Required(ErrorMessage ="Champ Date de naissance oblogatoire.")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public string DateNaisEleve { get; set; }
    }
}
