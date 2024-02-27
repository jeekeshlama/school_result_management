using FiboInfraStructure.Entity.FiboUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboUser.InfraStructure
{
    public interface IUserBranchService
    {
        Task<UserBranch> InsertAsync(UserBranch userBranch);
        Task<UserBranch> UpdateAsync(UserBranch userBranch);
    }
    public class UserBranchService : IUserBranchService
    {
        private readonly IUserBranchRepository _userBranchRepository;
        public UserBranchService(IUserBranchRepository userBranchRepository)
        {
            _userBranchRepository = userBranchRepository;
        }
        public async Task<UserBranch> InsertAsync(UserBranch userBranch)
        {
            return await _userBranchRepository.AddAsync(userBranch).ConfigureAwait(true);
        }

        public async Task<UserBranch> UpdateAsync(UserBranch userBranch)
        {
            return await _userBranchRepository.UpdateAsync(userBranch).ConfigureAwait(true);
        }
    }
}

