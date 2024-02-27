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
    
    public interface IStudentService
    {
        Task<StudentDto> Insertasync(StudentDto dto);
        Task<Student> Delete(long Id);
        Task<StudentDto> UpdateAsync(StudentDto dto);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IStudentAssembler _assembler;
        public StudentService(IStudentRepository repository, IStudentAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<StudentDto> Insertasync(StudentDto dto)
        {
            Student student = new Student();
            _assembler.copyTo(student, dto);
            await _repository.AddAsync(student);
            dto.Id = student.Id;
            return dto;
        }

        public async Task<StudentDto> UpdateAsync(StudentDto dto)
        {
            var student = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(student, dto);
            await _repository.UpdateAsync(student);
            return dto;
        }

        public async Task<Student> Delete(long Id)
        {
            var student = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(student).ConfigureAwait(true);
        }
        
    }
}
