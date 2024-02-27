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
    public interface ISessionSetupRepository : IRepository<SessionSetup>
    {
        Task<List<SessionSetup>> GetAllSessionSetupAsync();
    }
    public class SessionSetupRepository : Repository<SessionSetup>, ISessionSetupRepository
{
        public SessionSetupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<SessionSetup>> GetAllSessionSetupAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
