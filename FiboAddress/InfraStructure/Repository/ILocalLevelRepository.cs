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
   public interface ILocalLevelRepository : IRepository<LocalLevel>
    {
        Task<List<LocalLevel>> GetAllLocalLevelAsync();
    }
    public class LocalLevelRepository : Repository<LocalLevel>, ILocalLevelRepository
    {
        public LocalLevelRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<LocalLevel>> GetAllLocalLevelAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
