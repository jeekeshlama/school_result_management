using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface IAssignTeacherAssembler
    {
        void copyTo(AssignTeacher assignteacher, AssignTeacherDto dto);
        void copyFrom(AssignTeacherDto dto, AssignTeacher assignteacher);
        void modifyTo(AssignTeacher assignteacher, AssignTeacherDto dto);
    }

    public class AssignTeacherAssembler : IAssignTeacherAssembler
    {
        //copy to entity(table)
        public void copyTo(AssignTeacher assignteacher, AssignTeacherDto dto)
        {
            assignteacher.CreatedBy = dto.CreatedBy;
            assignteacher.CreatedDate = DateTime.Now;
            assignteacher.ClassId = dto.ClassId;
            assignteacher.SubjectId = dto.SubjectId;
            assignteacher.TeacherId = dto.TeacherId;
            assignteacher.SectionId = dto.SectionId;

        }
        //copy from entity(table)
        public void copyFrom(AssignTeacherDto dto, AssignTeacher assignteacher)
        {
            dto.Id = assignteacher.Id;
            dto.CreatedBy = assignteacher.CreatedBy;
            dto.CreatedDate = assignteacher.CreatedDate;
            dto.ClassId = assignteacher.ClassId;
            dto.SectionId = assignteacher.SectionId;
            dto.TeacherId = assignteacher.TeacherId;
            dto.SubjectId = assignteacher.SubjectId;
        }

        //modified to entity(table)
        public void modifyTo(AssignTeacher assignteacher, AssignTeacherDto dto)
        {
            assignteacher.Id = dto.Id;
            assignteacher.CreatedBy = dto.CreatedBy;
            assignteacher.CreatedDate = dto.CreatedDate;
            assignteacher.ModifiedBy = dto.ModifiedBy;
            assignteacher.ModifiedDate = DateTime.Now;
            assignteacher.ClassId = dto.ClassId;
            assignteacher.SubjectId = dto.SubjectId;
            assignteacher.TeacherId = dto.TeacherId;
            assignteacher.SectionId = dto.SectionId;

        }
    }
}
