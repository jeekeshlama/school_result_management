using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboOffice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboOffice.InfraStructure.Repository
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<List<Branch>> GetAllBranchAsync();
    }
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Branch>> GetAllBranchAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
