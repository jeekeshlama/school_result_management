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
    public interface ISchoolSetupService
    {
        Task<SchoolSetupDto> Insertasync(SchoolSetupDto dto);
        Task<SchoolSetUp> Delete(long Id);
        Task<SchoolSetupDto> UpdateAsync(SchoolSetupDto dto);
    }
    public class SchoolSetupService : ISchoolSetupService
    {
        private readonly ISchoolSetupRepository _repository;
        private readonly ISchoolSetupAssembler _assembler;
        public SchoolSetupService(ISchoolSetupRepository repository, ISchoolSetupAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<SchoolSetupDto> Insertasync(SchoolSetupDto dto)
        {
            SchoolSetUp schoolSetup = new SchoolSetUp();
            _assembler.copyTo(schoolSetup, dto);
            await _repository.AddAsync(schoolSetup);
            dto.Id = schoolSetup.Id;
            return dto;
        }

        public async Task<SchoolSetupDto> UpdateAsync(SchoolSetupDto dto)
        {
            var schoolSetUp = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(schoolSetUp, dto);
            await _repository.UpdateAsync(schoolSetUp);
            return dto;
        }

        public async Task<SchoolSetUp> Delete(long Id)
        {
            var sessionSetup = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(sessionSetup).ConfigureAwait(true);
        }
    }
}
