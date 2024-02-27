using System;
using System.Collections.Generic;
using System.Text;
using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;

namespace FiboSchool.InfraStructure.Assembler
{
   public interface IPerformanceAssembler
    {
        void copyTo(Performance performance, PerformanceDto dto);
        void copyFrom(PerformanceDto dto, Performance performance);
        void modifyTo(Performance performance, PerformanceDto dto);
    }
    public class PerformanceAssembler : IPerformanceAssembler
    {
        //copy to entity(table)
        public void copyTo(Performance performance, PerformanceDto dto)
        {
            performance.CreatedBy = dto.CreatedBy;
            performance.CreatedDate = DateTime.Now;
            performance.Division = dto.Division;
            performance.TotalGrade = dto.TotalGrade;
            performance.GPA = dto.GPA;
            performance.Percentage = dto.Percentage;
            performance.Discipline = dto.Discipline;
            performance.Position = dto.Position;
            performance.StudentId = dto.StudentId;
            performance.SessionSetupId = dto.SessionSetupId;
            performance.TermId = dto.TermId;
            performance.ClassId = dto.ClassId;
            performance.SectionSetupId = dto.SectionSetupId;
            performance.BranchId = dto.BranchId;
        }
        //copy from entity(table)
        public void copyFrom(PerformanceDto dto, Performance performance)
        {
            dto.Id = performance.Id;
            dto.CreatedBy = performance.CreatedBy;
            dto.CreatedDate = performance.CreatedDate;
            dto.Division = performance.Division;
            dto.TotalGrade = performance.TotalGrade;
            dto.GPA = performance.GPA;
            dto.Percentage = performance.Percentage;
            dto.Discipline = performance.Discipline;
            dto.Position = performance.Position;
            dto.StudentId = performance.StudentId;
            dto.SessionSetupId = performance.SessionSetupId;
            dto.TermId = performance.TermId;
            dto.ClassId = performance.ClassId;
            dto.SectionSetupId = performance.SectionSetupId;
            dto.BranchId = performance.BranchId;
        }

        //modified to entity(table)
        public void modifyTo(Performance performance, PerformanceDto dto)
        {
            performance.Id = dto.Id;
            performance.CreatedBy = dto.CreatedBy;
            performance.CreatedDate = dto.CreatedDate;
            performance.ModifiedBy = dto.ModifiedBy;
            performance.ModifiedDate = DateTime.Now;
            performance.Division = dto.Division;
            performance.TotalGrade = dto.TotalGrade;
            performance.GPA = dto.GPA;
            performance.Percentage = dto.Percentage;
            performance.Discipline = dto.Discipline;
            performance.Position = dto.Position;
            performance.StudentId = dto.StudentId;
            performance.SessionSetupId = dto.SessionSetupId;
            performance.TermId = dto.TermId;
            performance.ClassId = dto.ClassId;
            performance.SectionSetupId = dto.SectionSetupId;
            performance.BranchId = dto.BranchId;
        }
    }
}
