using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboOffice;
using Microsoft.EntityFrameworkCore;

namespace FiboOffice.InfraStructure.Repository
{
   public interface IOfficeRepository : IRepository<Office>
    {
        Task<List<Office>> GetAllOfficeAsync();
    }
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Office>> GetAllOfficeAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
