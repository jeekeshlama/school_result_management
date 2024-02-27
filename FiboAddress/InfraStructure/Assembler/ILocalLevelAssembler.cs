using System;
using System.Collections.Generic;
using System.Text;
using FiboAddress.Src.Dto;
using FiboInfraStructure.Entity.FiboAddress;

namespace FiboAddress.InfraStructure.Assembler
{
   public interface ILocalLevelAssembler
    {
        void copyTo(LocalLevel localLevel , LocalLevelDto dto);
        void copyFrom(LocalLevelDto dto, LocalLevel LocalLevel);
        void modifyTo(LocalLevel localLevel , LocalLevelDto dto);
    }
    public class LocalLevelAssembler : ILocalLevelAssembler
    {
        //copy to entity(table)
        public void copyTo(LocalLevel localLevel, LocalLevelDto dto)
        {
            localLevel.CreatedBy = dto.CreatedBy;
            localLevel.CreatedDate = DateTime.Now;
            localLevel.Name = dto.Name;
            localLevel.DistrictId = dto.DistrictId;
        }
        //copy from entity(table)
        public void copyFrom(LocalLevelDto dto, LocalLevel localLevel)
        {
            dto.Id = localLevel.Id;
            dto.CreatedBy = localLevel.CreatedBy;
            dto.CreatedDate = localLevel.CreatedDate;
            dto.Name = localLevel.Name;
            dto.DistrictId = localLevel.DistrictId;
        }

        //modified to entity(table)
        public void modifyTo(LocalLevel localLevel, LocalLevelDto dto)
        {
            localLevel.Id = dto.Id;
            localLevel.CreatedBy = dto.CreatedBy;
            localLevel.CreatedDate = DateTime.Now;
            localLevel.Name = dto.Name;
            localLevel.DistrictId = dto.DistrictId;
            localLevel.ModifiedBy = dto.ModifiedBy;
            localLevel.ModifiedDate = DateTime.Now;

        }
    }
}
