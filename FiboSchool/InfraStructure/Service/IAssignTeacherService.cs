using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Service
{
    public interface IAssignTeacherService
    {
        Task<AssignTeacherDto> Insertasync(AssignTeacherDto dto);
        Task<AssignTeacher> Delete(long Id);
        Task<AssignTeacherDto> UpdateAsync(AssignTeacherDto dto);
    }
    public class AssignTeacherService : IAssignTeacherService
    {
        private readonly IAssignTeacherRepository _repository;
        private readonly IAssignTeacherAssembler _assembler;
        public AssignTeacherService(IAssignTeacherRepository repository, IAssignTeacherAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<AssignTeacherDto> Insertasync(AssignTeacherDto dto)
        {
            AssignTeacher assignteacher = new AssignTeacher();
            _assembler.copyTo(assignteacher, dto);
            await _repository.AddAsync(assignteacher);
            dto.Id = assignteacher.Id;
            return dto;
        }

        public async Task<AssignTeacherDto> UpdateAsync(AssignTeacherDto dto)
        {
            var assignteacher = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(assignteacher, dto);
            await _repository.UpdateAsync(assignteacher);
            return dto;
        }

        public async Task<AssignTeacher> Delete(long Id)
        {
            var assignteacher = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(assignteacher).ConfigureAwait(true);
        }

    }
}

