using BackendAPI.Data;
using BackendAPI.Models;
using BackendAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Repositories.Implementations
{
    public class AnneeScolaireRepository : BaseRepository<Annee_Scolaire>,IAnneeScolaireRepository
    {
        public AnneeScolaireRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
