using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface ISectionSetupAssembler
    {
        void copyTo(SectionSetup sectionSetup, SectionSetupDto dto);
        void copyFrom(SectionSetupDto dto, SectionSetup sectionSetup);
        void modifyTo(SectionSetup sectionSetup, SectionSetupDto dto);
    }

    public class SectionSetupAssembler : ISectionSetupAssembler
    {
        //copy to entity(table)
        public void copyTo(SectionSetup sectionSetup, SectionSetupDto dto)
        {
            sectionSetup.CreatedBy = dto.CreatedBy;
            sectionSetup.CreatedDate = DateTime.Now;
            sectionSetup.Name = dto.Name;
        }
        //copy from entity(table)
        public void copyFrom(SectionSetupDto dto, SectionSetup sectionSetup)
        {
            dto.Id = sectionSetup.Id;
            dto.CreatedBy = sectionSetup.CreatedBy;
            dto.CreatedDate = sectionSetup.CreatedDate;
            dto.Name = sectionSetup.Name;
        }

        //modified to entity(table)
        public void modifyTo(SectionSetup sectionSetup, SectionSetupDto dto)
        {
            sectionSetup.Id = dto.Id;
            sectionSetup.CreatedBy = dto.CreatedBy;
            sectionSetup.CreatedDate = dto.CreatedDate;
            sectionSetup.Name = dto.Name;
            sectionSetup.ModifiedBy = dto.ModifiedBy;
            sectionSetup.ModifiedDate = DateTime.Now;
        }
    }
}
