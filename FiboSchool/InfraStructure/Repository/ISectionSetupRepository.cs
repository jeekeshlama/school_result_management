using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboSchool;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Repository
{
    public interface ISectionSetupRepository:IRepository<SectionSetup>
    {
        Task<List<SectionSetup>> GetAllSectionSetupAsync();
    }
    public class SectionSetupRepository : Repository<SectionSetup>, ISectionSetupRepository
    {
        public SectionSetupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<SectionSetup>> GetAllSectionSetupAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
