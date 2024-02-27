using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboSchool;
using Microsoft.EntityFrameworkCore;

namespace FiboSchool.InfraStructure.Repository
{
   public interface IPerformanceRepository : IRepository<Performance>
    {
        Task<List<Performance>> GetAllPerformanceAsync();
    }
    public class PerformanceRepository : Repository<Performance>, IPerformanceRepository
    {
        public PerformanceRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Performance>> GetAllPerformanceAsync()
        {
            return await GetAllAsync().ToListAsync();
        }


    }
}
