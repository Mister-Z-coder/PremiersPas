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

        [Required]
        [Display(Name = "Nom")]
        public string NomEleve { get; set; }

        [Required]
        [Display(Name = "Post-nom")]
        public string PostNomEleve { get; set; }

        [Required]
        [Display(Name = "Sexe")]
        public string SexeEleve { get; set; }

        [Display(Name = "Photo de l'élève")]
        public IFormFile? PhotoFile { get; set; } // upload dans le formulaire

        public string? PhotoEleveUrl { get; set; } // chemin de l'image déjà stockée

        [Display(Name = "Lieu de naissance")]
        public string LieuNaisEleve { get; set; }

        [Required]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public string DateNaisEleve { get; set; }
    }
}
