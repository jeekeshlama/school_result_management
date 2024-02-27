using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.InfraStructure.Assembler
{
    
    public interface IManageMarksDetailAssembler
    {
        void copyTo(ManageMarksDetail marks, ManageMarksDetailDto dto);
        void copyFrom(ManageMarksDetailDto dto, ManageMarksDetail marks);
        void modifyTo(ManageMarksDetail marks, ManageMarksDetailDto dto);
    }

    public class ManageMarksDetailAssembler : IManageMarksDetailAssembler
    {
        public void copyTo(ManageMarksDetail marks, ManageMarksDetailDto dto)
        {
            marks.BranchId = dto.BranchId;
            marks.CreatedBy = dto.CreatedBy;
            marks.CreatedDate = DateTime.Now.Date;
            marks.ManageMarksId = dto.ManageMarksId;
            marks.StudentId = dto.StudentId;
            marks.FullMarks = dto.FullMarks;
            marks.PassMarks = dto.PassMarks;
            marks.ObtainedMarks = dto.ObtainedMarks;
            marks.HighestMarks = dto.HighestMarks;           
        }

        public void copyFrom(ManageMarksDetailDto dto, ManageMarksDetail marks)
        {
            dto.BranchId = marks.BranchId;
            dto.Id = marks.Id;
            dto.CreatedBy = marks.CreatedBy;
            dto.CreatedDate = marks.CreatedDate;
            dto.ManageMarksId = marks.ManageMarksId;
            dto.StudentId = marks.StudentId;
            dto.FullMarks = marks.FullMarks;
            dto.PassMarks = marks.PassMarks;
            dto.ObtainedMarks = marks.ObtainedMarks;
            dto.HighestMarks = marks.HighestMarks;
        }

        public void modifyTo(ManageMarksDetail marks, ManageMarksDetailDto dto)
        {
            marks.Id = dto.Id;
            marks.BranchId = dto.BranchId;
            marks.CreatedBy = dto.CreatedBy;
            marks.CreatedDate = dto.CreatedDate;
            marks.ModifiedBy = dto.ModifiedBy;
            marks.ModifiedDate = DateTime.Now.Date;
            marks.ManageMarksId = dto.ManageMarksId;
            marks.StudentId = dto.StudentId;
            marks.FullMarks = dto.FullMarks;
            marks.PassMarks = dto.PassMarks;
            marks.ObtainedMarks = dto.ObtainedMarks;
            marks.HighestMarks = dto.HighestMarks;
        }
    }
}
