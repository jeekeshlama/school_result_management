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
    public interface ISubjectService
    {
        Task<SubjectDto> Insertasync(SubjectDto dto);
        Task<Subject> Delete(long Id);
        Task<SubjectDto> UpdateAsync(SubjectDto dto);
    }
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly ISubjectAssembler _assembler;
        public SubjectService(ISubjectRepository repository, ISubjectAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<SubjectDto> Insertasync(SubjectDto dto)
        {
            Subject subject = new Subject();
            _assembler.copyTo(subject, dto);
            await _repository.AddAsync(subject);
            dto.Id = subject.Id;
            return dto;
        }

        public async Task<SubjectDto> UpdateAsync(SubjectDto dto)
        {
            var subject = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(subject, dto);
            await _repository.UpdateAsync(subject);
            return dto;
        }

        public async Task<Subject> Delete(long Id)
        {
            var subject = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(subject).ConfigureAwait(true);
        }
    }
}
