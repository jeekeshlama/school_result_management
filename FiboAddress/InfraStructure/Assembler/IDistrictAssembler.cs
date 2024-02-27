using System;
using System.Collections.Generic;
using System.Text;
using FiboAddress.Src.Dto;
using FiboInfraStructure.Entity.FiboAddress;

namespace FiboAddress.InfraStructure.Assembler
{
        public interface IDistrictAssembler
        {
            void copyTo(District district, DistrictDto dto);
            void copyFrom(DistrictDto dto, District district);
            void modifyTo(District district, DistrictDto dto);
        }

    public class DistrictAssembler : IDistrictAssembler
    {
        //copy to entity(table)
        public void copyTo(District district, DistrictDto dto)
        {
            district.CreatedBy = dto.CreatedBy;
            district.CreatedDate = DateTime.Now;
            district.Name = dto.Name;
            district.ProvienceId = dto.ProvienceId;
        }
        //copy from entity(table)
        public void copyFrom(DistrictDto dto, District district) 
        {
            dto.Id = district.Id;
            dto.CreatedBy = district.CreatedBy;
            dto.CreatedDate = district.CreatedDate;
            dto.Name = district.Name;
            dto.ProvienceId = district.ProvienceId;
        }

        //modified to entity(table)
        public void modifyTo(District district, DistrictDto dto)
        {
            district.Id = dto.Id;
            district.CreatedBy = dto.CreatedBy;
            district.CreatedDate = DateTime.Now;
            district.Name = dto.Name;
            district.ProvienceId = dto.ProvienceId;
            district.ModifiedBy = dto.ModifiedBy;
            district.ModifiedDate = DateTime.Now;
        }
    }
}
