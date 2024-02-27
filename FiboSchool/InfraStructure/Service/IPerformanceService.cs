using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.Src.Dto;

namespace FiboSchool.InfraStructure.Service
{
   public interface IPerformanceService
    {
        Task<PerformanceDto> Insertasync(PerformanceDto dto);
        Task<Performance> Delete(long Id);
        Task<PerformanceDto> UpdateAsync(PerformanceDto dto);
    }
    public class PerformanceService : IPerformanceService
    {
        private readonly IPerformanceRepository _repository;
        private readonly IPerformanceAssembler _assembler;
        public PerformanceService(IPerformanceRepository repository, IPerformanceAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<PerformanceDto> Insertasync(PerformanceDto dto)
        {
            Performance performance = new Performance();
            _assembler.copyTo(performance, dto);
            await _repository.AddAsync(performance);
            dto.Id = performance.Id;
            return dto;
        }

        public async Task<PerformanceDto> UpdateAsync(PerformanceDto dto)
        {
            var performance = await _repository.GetByIdAsync(dto.Id) ?? throw new Exception();
            _assembler.modifyTo(performance, dto);
            await _repository.UpdateAsync(performance);
            return dto;
        }

        public async Task<Performance> Delete(long Id)
        {
            var performance = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(performance).ConfigureAwait(true);
        }
    }
}
