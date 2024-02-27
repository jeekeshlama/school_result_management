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
   
    public interface IFiscalYearRepository : IRepository<FiscalYear>
    {
        Task<List<FiscalYear>> GetAllFiscalYearAsync();
    }
    public class FiscalYearRepository : Repository<FiscalYear>, IFiscalYearRepository
    {
        public FiscalYearRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<List<FiscalYear>> GetAllFiscalYearAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
