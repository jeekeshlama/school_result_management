using System;
using System.Collections.Generic;
using System.Text;
using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.Src.Dto;

namespace FiboOffice.InfraStructure.Assembler
{
   public interface IOfficeAssembler
    {
        void copyTo(Office office, OfficeDto dto);
        void copyFrom(OfficeDto dto, Office office);
        void modifyTo(Office office, OfficeDto dto);
    }

    public class OfficeAssembler : IOfficeAssembler
    {
        //copy to entity(table)
        public void copyTo(Office office , OfficeDto dto)
        {
            office.CreatedBy = dto.CreatedBy;
            office.CreatedDate = DateTime.Now;
            office.Name = dto.Name;
            office.PhoneNo = dto.PhoneNo;
            office.ProvienceId = dto.ProvienceId;
            office.DistrictId = dto.DistrictId;
            office.LocalLevelId = dto.LocalLevelId;
            office.Email = dto.Email;
            office.FAX = dto.FAX;
            office.PANNo = dto.PANNo;
            office.OfficeLogo = dto.OfficeLogo;
        }
        //copy from entity(table)
        public void copyFrom(OfficeDto dto, Office office)
        {
            dto.Id = office.Id;
            dto.CreatedBy = office.CreatedBy;
            dto.CreatedDate = office.CreatedDate;
            dto.Name = office.Name;
            dto.PhoneNo = office.PhoneNo;
            dto.Email = office.Email;
            dto.FAX = office.FAX;
            dto.PANNo = office.PANNo;
            dto.ProvienceId = office.ProvienceId;
            dto.DistrictId = office.DistrictId;
            dto.LocalLevelId = office.LocalLevelId;
            dto.OfficeLogo = office.OfficeLogo;
        }

        //modified to entity(table)
        public void modifyTo(Office office, OfficeDto dto)
        {
            office.Id = dto.Id;
            office.CreatedBy = dto.CreatedBy;
            office.CreatedDate = DateTime.Now;
            office.ModifiedBy = dto.ModifiedBy;
            office.ModifiedDate = DateTime.Now;
            office.Name = dto.Name;
            office.PhoneNo = dto.PhoneNo;
            office.Email = dto.Email;
            office.FAX = dto.FAX;
            office.PANNo = dto.PANNo;
            office.ProvienceId = dto.ProvienceId;
            office.DistrictId = dto.DistrictId;
            office.LocalLevelId = dto.LocalLevelId;
            office.OfficeLogo = dto.OfficeLogo;

        }
    }
}
