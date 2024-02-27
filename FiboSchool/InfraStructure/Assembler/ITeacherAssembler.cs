using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface ITeacherAssembler
    {
        void copyTo(Teacher teacher, TeacherDto dto);
        void copyFrom(TeacherDto dto, Teacher teacher);
        void modifyTo(Teacher teacher, TeacherDto dto);
    }

    public class TeacherAssembler : ITeacherAssembler
    {
        //copy to entity(table)
        public void copyTo(Teacher teacher, TeacherDto dto)
        {
            teacher.CreatedBy = dto.CreatedBy;
            teacher.CreatedDate = DateTime.Now;
            teacher.Name = dto.Name;
            teacher.MobileNumber = dto.MobileNumber;
            teacher.SubjectId = dto.SubjectId;
        }
        //copy from entity(table)
        public void copyFrom(TeacherDto dto, Teacher teacher)
        {
            dto.Id = teacher.Id;
            dto.CreatedBy = teacher.CreatedBy;
            dto.CreatedDate = teacher.CreatedDate;
            dto.Name = teacher.Name;
            dto.MobileNumber = teacher.MobileNumber;
            dto.SubjectId = teacher.SubjectId;
        }

        //modified to entity(table)
        public void modifyTo(Teacher teacher, TeacherDto dto)
        {
            teacher.Id = dto.Id;
            teacher.CreatedBy = dto.CreatedBy;
            teacher.CreatedDate = dto.CreatedDate;
            teacher.ModifiedBy = dto.ModifiedBy;
            teacher.ModifiedDate = DateTime.Now;
            teacher.Name = dto.Name;
            teacher.MobileNumber = dto.MobileNumber;
            teacher.SubjectId = dto.SubjectId;
        }
    }
}
