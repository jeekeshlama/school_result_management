using System;
using System.Collections.Generic;
using System.Text;
using FiboAddress.Src.Dto;
using FiboInfraStructure.Entity.FiboAddress;

namespace FiboAddress.InfraStructure.Assembler
{
    public interface IProvienceAssembler
    {
        void copyTo(Provience provience, ProvienceDto dto);
        void copyFrom(ProvienceDto dto, Provience provience);
        void modifyTo(Provience provience, ProvienceDto dto);
    }

    public class ProvienceAssembler : IProvienceAssembler
    {
        //copy to entity(table)
        public void copyTo(Provience provience, ProvienceDto dto)
        {
            provience.CreatedBy = dto.CreatedBy;
            provience.CreatedDate = DateTime.Now;
            provience.Name = dto.Name;
        }
        //copy from entity(table)
        public void copyFrom(ProvienceDto dto, Provience provience)
        {
            dto.Id = provience.Id;
            dto.CreatedBy = provience.CreatedBy;
            dto.CreatedDate = provience.CreatedDate;
            dto.Name = provience.Name;
        }

        //modified to entity(table)
        public void modifyTo(Provience provience, ProvienceDto dto)
        {
            provience.Id = dto.Id;
            provience.CreatedBy = dto.CreatedBy;
            provience.CreatedDate = DateTime.Now;
            provience.Name = dto.Name;
            provience.ModifiedBy = dto.ModifiedBy;
            provience.ModifiedDate = DateTime.Now;
        }
    }
}
