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
    public interface IClassSetupRepository : IRepository<ClassSetup>
    {
        Task<List<ClassSetup>> GetAllClassSetupAsync();
    }
    public class ClassSetupRepository : Repository<ClassSetup>, IClassSetupRepository
    {
        public ClassSetupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ClassSetup>> GetAllClassSetupAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
