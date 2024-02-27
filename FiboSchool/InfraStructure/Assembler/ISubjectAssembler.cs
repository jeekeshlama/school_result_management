using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface ISubjectAssembler
    {
        void copyTo(Subject subject, SubjectDto dto);
        void copyFrom(SubjectDto dto, Subject subject);
        void modifyTo(Subject subject, SubjectDto dto);
    }

    public class SubjectAssembler : ISubjectAssembler
    {
        //copy to entity(table)
        public void copyTo(Subject subject, SubjectDto dto)
        {
            subject.CreatedBy = dto.CreatedBy;
            subject.CreatedDate = DateTime.Now;
            subject.SubjectName = dto.SubjectName;
            subject.Abbreviation = dto.Abbreviation;
            subject.ClassId = dto.ClassId;
        }
        //copy from entity(table)
        public void copyFrom(SubjectDto dto, Subject subject)
        {
            dto.Id = subject.Id;
            dto.CreatedBy = subject.CreatedBy;
            dto.CreatedDate = subject.CreatedDate;
            dto.SubjectName = subject.SubjectName;
            dto.Abbreviation = subject.Abbreviation;
            dto.ClassId = subject.ClassId;
        }

        //modified to entity(table)
        public void modifyTo(Subject subject, SubjectDto dto)
        {
            subject.Id = dto.Id;
            subject.CreatedBy = dto.CreatedBy;
            subject.CreatedDate = dto.CreatedDate;
            subject.Abbreviation = dto.Abbreviation;
            subject.ModifiedBy = dto.ModifiedBy;
            subject.ModifiedDate = DateTime.Now;
            subject.SubjectName = dto.SubjectName;
            subject.ClassId = dto.ClassId;
        }
    }
}
