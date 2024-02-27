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
    public interface ISchoolSetupRepository : IRepository<SchoolSetUp>
    {
        Task<List<SchoolSetUp>> GetAllSchoolSetupAsync();
    }
    public class SchoolSetupRepository : Repository<SchoolSetUp>, ISchoolSetupRepository
    {
        public SchoolSetupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<SchoolSetUp>> GetAllSchoolSetupAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
