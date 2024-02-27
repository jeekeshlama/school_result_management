using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.InfraStructure.Assembler;
using FiboOffice.InfraStructure.Repository;
using FiboOffice.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboOffice.InfraStructure.Service
{
    public interface IBranchService
    {
        Task<BranchDto> InsertAsync(BranchDto dto);
        Task<Branch> Delete(long Id);
        Task<BranchDto> UpdateAsync(BranchDto dto);
    }
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _repo;
        private readonly IBranchAssembler _assembler;
        public BranchService(IBranchRepository repo, IBranchAssembler assembler)
        {
            _repo = repo;
            _assembler = assembler;
        }
        public async Task<Branch> Delete(long Id)
        {
            var branch = await _repo.GetByIdAsync(Id) ?? throw new Exception();
            return await _repo.DeleteAsync(branch).ConfigureAwait(true);
        }

        public async Task<BranchDto> InsertAsync(BranchDto dto)
        {
            Branch branch = new Branch();
            _assembler.copyTo(branch, dto);
            await _repo.AddAsync(branch);
            dto.Id = branch.Id;
            return dto;
        }

        public async Task<BranchDto> UpdateAsync(BranchDto dto)
        {
            Branch branch = new Branch();
            _assembler.modifyTo(branch, dto);
            await _repo.UpdateAsync(branch);
            return dto;
        }
    }
}
