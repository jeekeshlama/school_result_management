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
   public interface IDistrictRepository : IRepository<District>
    {
        Task<List<District>> GetAllDistrictAsync();
    }
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<District>> GetAllDistrictAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
