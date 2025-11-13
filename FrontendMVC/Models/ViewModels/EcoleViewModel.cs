using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC.Models.ViewModels
{
    public class EcoleViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Matricule SECOPE")]
        public string Matricule_Secope { get; set; }

        [Required]
        [Display(Name = "Titre de l'école")]
        public string TitreEcole { get; set; }

        [Required]
        [Display(Name = "Adresse de l'école")]
        public string AdresseEcole { get; set; }

        [Display(Name = "Photo")]
        public IFormFile? PhotoFile { get; set; } // utilisé pour upload depuis un formulaire

        public string? PhotoEcoleUrl { get; set; }

        [Required]
        [Display(Name = "Historique")]
        public string HistoriqueEcole { get; set; }

        [Required]
        [Display(Name = "Arrêté agreement")]
        public string Arrete_Agreement { get; set; }
        

        [Range(-90, 90)]
        [Display(Name = "Longitude")]
        public double LatitudeEcole { get; set; }

        [Range(-180, 180)]
        [Display(Name = "Latitude")]
        public double LongitudeEcole { get; set; }
    }
}
