using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboAddress;
using Microsoft.EntityFrameworkCore;

namespace FiboAddress.InfraStructure.Repository
{
    public interface IProvienceRepository : IRepository<Provience>
    {
        Task<List<Provience>> GetAllProvienceAsync();
    }
    public class ProvienceRepository : Repository<Provience>, IProvienceRepository
    {
        public ProvienceRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Provience>> GetAllProvienceAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
