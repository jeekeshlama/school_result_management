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
    public interface ITeacherService
    {
        Task<TeacherDto> Insertasync(TeacherDto dto);
        Task<Teacher> Delete(long Id);
        Task<TeacherDto> UpdateAsync(TeacherDto dto);
    }
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        private readonly ITeacherAssembler _assembler;
        public TeacherService(ITeacherRepository repository, ITeacherAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<TeacherDto> Insertasync(TeacherDto dto)
        {
            Teacher teacher = new Teacher();
            _assembler.copyTo(teacher, dto);
            await _repository.AddAsync(teacher);
            dto.Id = teacher.Id;
            return dto;
        }

        public async Task<TeacherDto> UpdateAsync(TeacherDto dto)
        {
            var teacher = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(teacher, dto);
            await _repository.UpdateAsync(teacher);
            return dto;
        }

        public async Task<Teacher> Delete(long Id)
        {
            var teacher = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(teacher).ConfigureAwait(true);
        }

    }
}
