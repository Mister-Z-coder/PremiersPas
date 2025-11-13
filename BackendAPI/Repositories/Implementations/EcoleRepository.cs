using BackendAPI.Data;
using BackendAPI.Models;
using BackendAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Repositories.Implementations
{
    public class EcoleRepository : BaseRepository<Ecole>,IEcoleRepository
    {
        public EcoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
