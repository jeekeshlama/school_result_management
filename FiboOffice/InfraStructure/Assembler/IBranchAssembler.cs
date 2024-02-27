using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboOffice.InfraStructure.Assembler
{
    public interface IBranchAssembler
    {
        void copyTo(Branch branch, BranchDto dto);
        void copyFrom(BranchDto dto, Branch branch);
        void modifyTo(Branch branch, BranchDto dto);
    }

    public class BranchAssembler : IBranchAssembler
    {
        //copy to entity(table)
        public void copyTo(Branch branch, BranchDto dto)
        {
            branch.CreatedBy = dto.CreatedBy;
            branch.CreatedDate = DateTime.Now;
            branch.Name = dto.Name;
            branch.PhoneNo = dto.PhoneNo;
            branch.Email = dto.Email;
            branch.WardNo = dto.WardNo;
            branch.OfficeId = dto.OfficeId;
            branch.ProvienceId = dto.ProvienceId;
            branch.DistrictId = dto.DistrictId;
            branch.LocalLevelId = dto.LocalLevelId;
        }
        //copy from entity(table)
        public void copyFrom(BranchDto dto, Branch branch)
        {
            dto.Id = branch.Id;
            dto.CreatedBy = branch.CreatedBy;
            dto.CreatedDate = branch.CreatedDate;
            dto.Name = branch.Name;
            dto.Email = branch.Email;
            dto.WardNo = branch.WardNo;
            dto.PhoneNo = branch.PhoneNo;
            dto.OfficeId = branch.OfficeId;
            dto.ProvienceId = branch.ProvienceId;
            dto.DistrictId = branch.DistrictId;
            dto.LocalLevelId = branch.LocalLevelId;
        }

        //modified to entity(table)
        public void modifyTo(Branch branch, BranchDto dto)
        {
            branch.Id = dto.Id;
            branch.CreatedBy = dto.CreatedBy;
            branch.CreatedDate = dto.CreatedDate;
            branch.ModifiedBy = dto.ModifiedBy;
            branch.ModifiedDate = DateTime.Now;
            branch.Name = dto.Name;
            branch.Email = dto.Email;
            branch.WardNo = dto.WardNo;
            branch.PhoneNo = dto.PhoneNo;
            branch.OfficeId = dto.OfficeId;
            branch.ProvienceId = dto.ProvienceId;
            branch.DistrictId = dto.DistrictId;
            branch.LocalLevelId = dto.LocalLevelId;

        }
    }
}
