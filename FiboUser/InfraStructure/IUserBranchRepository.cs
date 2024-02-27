using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboUser.InfraStructure
{
    public interface IUserBranchRepository : IRepository<UserBranch>
    {
        Task<List<UserBranch>> GetAllUserBranchAsync();
    }

    public class UserBranchRepository : Repository<UserBranch>, IUserBranchRepository
    {
        public UserBranchRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<UserBranch>> GetAllUserBranchAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}

