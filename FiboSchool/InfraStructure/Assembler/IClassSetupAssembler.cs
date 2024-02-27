using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Assembler
{
     public interface IClassSetupAssembler
    {
        void copyTo(ClassSetup classSetup, ClassSetupDto dto);
        void copyFrom(ClassSetupDto dto, ClassSetup classSetup);
        void modifyTo(ClassSetup classSetup, ClassSetupDto dto);
    }

    public class ClassSetupAssembler : IClassSetupAssembler
    {
        //copy to entity(table)
        public void copyTo(ClassSetup classSetup, ClassSetupDto dto)
        {
            classSetup.CreatedBy = dto.CreatedBy;
            classSetup.CreatedDate = DateTime.Now;
            classSetup.Name = dto.Name;
        }
        //copy from entity(table)
        public void copyFrom(ClassSetupDto dto, ClassSetup classSetup)
        {
            dto.Id = classSetup.Id;
            dto.CreatedBy = classSetup.CreatedBy;
            dto.CreatedDate = classSetup.CreatedDate;
            dto.Name = classSetup.Name;
        }

        //modified to entity(table)
        public void modifyTo(ClassSetup classSetup, ClassSetupDto dto)
        {
            classSetup.Id = dto.Id;
            classSetup.CreatedBy = dto.CreatedBy;
            classSetup.CreatedDate = dto.CreatedDate;
            classSetup.Name = dto.Name;
            classSetup.ModifiedBy = dto.ModifiedBy;
            classSetup.ModifiedDate = DateTime.Now;
        }
    }
}
