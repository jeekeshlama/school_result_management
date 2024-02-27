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
    public interface IClassSetupService
    {
        Task<ClassSetupDto> Insertasync(ClassSetupDto dto);
        Task<ClassSetup> Delete(long Id);
        Task<ClassSetupDto> UpdateAsync(ClassSetupDto dto);
    }
    public class ClassSetupService : IClassSetupService
    {
        private readonly IClassSetupRepository _repository;
        private readonly IClassSetupAssembler _assembler;
        public ClassSetupService(IClassSetupRepository repository, IClassSetupAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<ClassSetupDto> Insertasync(ClassSetupDto dto)
        {
            ClassSetup classSetup = new ClassSetup();
            _assembler.copyTo(classSetup, dto);
            await _repository.AddAsync(classSetup);
            dto.Id = classSetup.Id;
            return dto;
        }

        public async Task<ClassSetupDto> UpdateAsync(ClassSetupDto dto)
        {
            var classSetup = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(classSetup, dto);
            await _repository.UpdateAsync(classSetup);
            return dto;
        }

        public async Task<ClassSetup> Delete(long Id)
        {
            var classSetup = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(classSetup).ConfigureAwait(true);
        }
    }
}
