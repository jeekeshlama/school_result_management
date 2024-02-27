using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface ISessionSetupAssembler
    {
        void copyTo(SessionSetup sessionSetup, SessionSetupDto dto);
        void copyFrom(SessionSetupDto dto, SessionSetup sessionSetup);
        void modifyTo(SessionSetup sessionSetup, SessionSetupDto dto);
    }

    public class SessionSetupAssembler : ISessionSetupAssembler
    {
        //copy to entity(table)
        public void copyTo(SessionSetup sessionSetup, SessionSetupDto dto)
        {
            sessionSetup.CreatedBy = dto.CreatedBy;
            sessionSetup.CreatedDate = DateTime.Now;
            sessionSetup.Session = dto.Session;
            sessionSetup.Status = dto.Status;
        }
        //copy from entity(table)
        public void copyFrom(SessionSetupDto dto, SessionSetup sessionSetup)
        {
            dto.Session = sessionSetup.Session;
            dto.CreatedBy = sessionSetup.CreatedBy;
            dto.CreatedDate = sessionSetup.CreatedDate;
            dto.Status = sessionSetup.Status;
        }

        //modified to entity(table)
        public void modifyTo(SessionSetup sessionSetup, SessionSetupDto dto)
        {
            sessionSetup.Id = dto.Id;
            sessionSetup.CreatedBy = dto.CreatedBy;
            sessionSetup.CreatedDate = dto.CreatedDate;
            sessionSetup.ModifiedBy = dto.ModifiedBy;
            sessionSetup.ModifiedDate = DateTime.Now;
            sessionSetup.Status = dto.Status;
            sessionSetup.Session = dto.Session;
        }
    }
}
