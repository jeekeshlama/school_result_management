using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface IManageMarksAssembler
    {
        void copyTo(ManageMarks marks, ManageMarksDto dto);
        void copyFrom(ManageMarksDto dto, ManageMarks marks);
        void modifyTo(ManageMarks marks, ManageMarksDto dto);
    }

    public class ManageMarksAssembler : IManageMarksAssembler
    {
        public void copyTo(ManageMarks marks, ManageMarksDto dto)
        {

            marks.BranchId = dto.BranchId;
            marks.CreatedBy = dto.CreatedBy;
            marks.CreatedDate = DateTime.Now.Date;
            marks.FiscalYearId = dto.FiscalYearId;
            marks.SessionSetupId = dto.SessionSetupId;
            marks.SubjectId = dto.SubjectId;
            marks.ClassSetupId = dto.ClassSetupId;
            marks.SectionSetupId = dto.SectionSetupId;
            marks.TermId = dto.TermId;
        }

        public void copyFrom(ManageMarksDto dto, ManageMarks marks)
        {
            dto.BranchId = marks.BranchId;
            dto.Id = marks.Id;
            dto.CreatedBy = marks.CreatedBy;
            dto.CreatedDate = marks.CreatedDate;
            dto.FiscalYearId = marks.FiscalYearId;
            dto.SessionSetupId = marks.SessionSetupId;
            dto.SubjectId = marks.SubjectId;
            dto.ClassSetupId = marks.ClassSetupId;
            dto.SectionSetupId = marks.SectionSetupId;
            dto.TermId = marks.TermId;
        }

        public void modifyTo(ManageMarks marks, ManageMarksDto dto)
        {
            marks.FiscalYearId = dto.FiscalYearId;
            marks.Id = dto.Id;
            marks.BranchId = dto.BranchId;
            marks.CreatedBy = dto.CreatedBy;
            marks.CreatedDate = dto.CreatedDate;
            marks.ModifiedBy = dto.ModifiedBy;
            marks.ModifiedDate = DateTime.Now.Date;
            marks.SessionSetupId = dto.SessionSetupId;
            marks.SubjectId = dto.SubjectId;
            marks.ClassSetupId = dto.ClassSetupId;
            marks.SectionSetupId = dto.SectionSetupId;
            marks.TermId = dto.TermId;
        }
    }
}
