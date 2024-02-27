using FiboInfraStructure;
using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;
namespace FiboOffice.InfraStructure.Assembler
{
    public interface IFiscalYearAssembler
    {
        void copyTo(FiscalYear fy, FiscalYearDto dto);
        void copyFrom(FiscalYearDto dto, FiscalYear fy);
        void modifyTo(FiscalYear fy, FiscalYearDto dto);
    }
    public class FiscalYearAssembler : IFiscalYearAssembler
    {
        public void copyFrom(FiscalYearDto dto, FiscalYear fy)
        {
            dto.Id = fy.Id;
            dto.CreatedBy = fy.CreatedBy;
            dto.CreatedDate = fy.CreatedDate;
            dto.FiscalYearName = fy.FiscalYearName;
            dto.FiscalYearCode = fy.FiscalYearCode;
            dto.StartDate = fy.StartDate.ToNepDate();
            dto.EndDate = fy.EndDate.ToNepDate();
            dto.Status = fy.Status;
        }

        public void copyTo(FiscalYear fy, FiscalYearDto dto)
        {
            fy.CreatedBy = dto.CreatedBy;
            fy.CreatedDate = DateTime.Now;
            fy.FiscalYearName = dto.FiscalYearName;
            fy.FiscalYearCode = dto.FiscalYearCode;
            fy.EndDate = dto.EndDate.ToEnglishDate();
            fy.StartDate = dto.StartDate.ToEnglishDate();
            fy.Activate();
        }

        public void modifyTo(FiscalYear fy, FiscalYearDto dto)
        {
            fy.Id = dto.Id;
            fy.CreatedBy = dto.CreatedBy;
            fy.CreatedDate = DateTime.Now;
            fy.ModifiedBy = dto.ModifiedBy;
            fy.ModifiedDate = DateTime.Now;
            fy.FiscalYearName = dto.FiscalYearName;
            fy.FiscalYearCode = dto.FiscalYearCode;
            fy.EndDate = dto.EndDate.ToEnglishDate();
            fy.StartDate = dto.StartDate.ToEnglishDate();
            fy.Status = dto.Status;
        }
    }
}
