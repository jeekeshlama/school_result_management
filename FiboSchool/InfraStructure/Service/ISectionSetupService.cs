using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Service
{
    public interface ISectionSetupService
    {
        Task<SectionSetupDto> Insertasync(SectionSetupDto dto);
        Task<SectionSetup> Delete(long Id);
        Task<SectionSetupDto> UpdateAsync(SectionSetupDto dto);
    }
    public class SectionSetupService : ISectionSetupService
    {
        private readonly ISectionSetupRepository _repository;
        private readonly ISectionSetupAssembler _assembler;
        public SectionSetupService(ISectionSetupRepository repository, ISectionSetupAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<SectionSetupDto> Insertasync(SectionSetupDto dto)
        {
            SectionSetup sectionSetup = new SectionSetup();
            _assembler.copyTo(sectionSetup, dto);
            await _repository.AddAsync(sectionSetup);
            dto.Id = sectionSetup.Id;
            return dto;
        }

        public async Task<SectionSetupDto> UpdateAsync(SectionSetupDto dto)
        {
            var sectionSetup = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(sectionSetup, dto);
            await _repository.UpdateAsync(sectionSetup);
            return dto;
        }

        public async Task<SectionSetup> Delete(long Id)
        {
            var sectionSetup = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(sectionSetup).ConfigureAwait(true);
        }
    }
}
