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
    public interface IFiscalYearService
    {
        Task<FiscalYearDto> Insertasync(FiscalYearDto dto);
        Task<FiscalYear> Delete(long Id);
        Task<FiscalYear> ToggleStatus(FiscalYear fy);
        Task<FiscalYearDto> UpdateAsync(FiscalYearDto dto);
    }
    public class FiscalYearService : IFiscalYearService
    {
        private readonly IFiscalYearRepository _repo;
        private readonly IFiscalYearAssembler _assembler;
        public FiscalYearService(IFiscalYearRepository repo, IFiscalYearAssembler assembler)
        {
            _repo = repo;
            _assembler = assembler;
        }
        public async Task<FiscalYear> Delete(long Id)
        {
            var fy = await _repo.GetByIdAsync(Id) ?? throw new Exception();
            return await _repo.DeleteAsync(fy).ConfigureAwait(true);
        }

        public async Task<FiscalYearDto> Insertasync(FiscalYearDto dto)
        {
            FiscalYear fy = new FiscalYear();
            _assembler.copyTo(fy, dto);
            await _repo.AddAsync(fy);
            dto.Id = fy.Id;
            return dto;
        }

        public async Task<FiscalYear> ToggleStatus(FiscalYear fy)
        {
            if (fy != null)
            {
                fy.ChangeStatus();
            }
            return await _repo.UpdateAsync(fy).ConfigureAwait(true);
        }

        public async Task<FiscalYearDto> UpdateAsync(FiscalYearDto dto)
        {
            FiscalYear fy = new FiscalYear();
            _assembler.modifyTo(fy,dto);
            await _repo.UpdateAsync(fy);
            return dto;
        }
    }
}
