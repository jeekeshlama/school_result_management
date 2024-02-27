using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface ISchoolSetupAssembler
    {
        void copyTo(SchoolSetUp schoolSetUp, SchoolSetupDto dto);
        void copyFrom(SchoolSetupDto dto, SchoolSetUp schoolSetUp);
        void modifyTo(SchoolSetUp schoolSetUp, SchoolSetupDto dto);
    }

    public class SchoolSetupAssembler : ISchoolSetupAssembler
    {
        //copy to entity(table)
        public void copyTo(SchoolSetUp schoolSetUp, SchoolSetupDto dto)
        {
            schoolSetUp.CreatedBy = dto.CreatedBy;
            schoolSetUp.CreatedDate = DateTime.Now;
            schoolSetUp.SchoolName = dto.SchoolName;
            schoolSetUp.SchoolSlogan = dto.SchoolSlogan;
            schoolSetUp.Signature = dto.Signature;
            schoolSetUp.Address = dto.Address;


        }
        //copy from entity(table)
        public void copyFrom(SchoolSetupDto dto, SchoolSetUp schoolSetUp)
        {
            dto.Id = schoolSetUp.Id;
            dto.CreatedBy = schoolSetUp.CreatedBy;
            dto.CreatedDate = schoolSetUp.CreatedDate;
            dto.SchoolName = schoolSetUp.SchoolName;
            dto.SchoolSlogan = schoolSetUp.SchoolSlogan;
            dto.Address = schoolSetUp.Address;
            dto.Signature = schoolSetUp.Signature;
        }

        //modified to entity(table)
        public void modifyTo(SchoolSetUp schoolSetUp, SchoolSetupDto dto)
        {
            schoolSetUp.Id = dto.Id;
            schoolSetUp.CreatedBy = dto.CreatedBy;
            schoolSetUp.CreatedDate = dto.CreatedDate;
            schoolSetUp.SchoolName = dto.SchoolName;
            schoolSetUp.ModifiedBy = dto.ModifiedBy;
            schoolSetUp.ModifiedDate = DateTime.Now;
            schoolSetUp.SchoolSlogan = dto.SchoolSlogan;
            schoolSetUp.Signature = dto.Signature;
            schoolSetUp.Address = dto.Address;
        }
    }
}
