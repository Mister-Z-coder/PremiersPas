using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC.Models.ViewModels
{
    public class AnneeScolaireViewModel
    {
        [Required]
        [Display(Name = "Année scolaire")]
        public int AnneeScolaire { get; set; }
    }
}
