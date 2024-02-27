using System;
using System.Collections.Generic;
using System.Text;
using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface ITermAssembler
    {
        void copyTo(Term assign, TermDto dto);
        void copyFrom(TermDto dto, Term assign);
        void modifyTo(Term assign, TermDto dto);
    }
    public class TermAssembler : ITermAssembler
    {
        //copy to entity(table)
        public void copyTo(Term term, TermDto dto)
        {
            term.CreatedBy = dto.CreatedBy;
            term.CreatedDate = DateTime.Now;
            term.Name = dto.Name;
        }
        //copy from entity(table)
        public void copyFrom(TermDto dto, Term term)
        {
            dto.Id = term.Id;
            dto.CreatedBy = term.CreatedBy;
            dto.CreatedDate = term.CreatedDate;
            dto.Name = term.Name;
        }

        //modified to entity(table)
        public void modifyTo(Term term, TermDto dto)
        {
            term.Id = dto.Id;
            term.CreatedBy = dto.CreatedBy;
            term.CreatedDate = dto.CreatedDate;
            term.Name = dto.Name;
            term.ModifiedBy = dto.ModifiedBy;
            term.ModifiedDate = DateTime.Now;
        }
    }
}
