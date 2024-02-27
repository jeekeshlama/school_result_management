using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.Src.Dto;

namespace FiboSchool.InfraStructure.Service
{
   public interface ITermService
    {
        Task<TermDto> Insertasync(TermDto dto);
        Task<Term> Delete(long Id);
        Task<TermDto> UpdateAsync(TermDto dto);
    }
    public class TermService : ITermService
    {
        private readonly ITermRepository _repository;
        private readonly ITermAssembler _assembler;
        public TermService(ITermRepository repository, ITermAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<TermDto> Insertasync(TermDto dto)
        {
            Term term= new Term();
            _assembler.copyTo(term, dto);
            await _repository.AddAsync(term);
            dto.Id = term.Id;
            return dto;
        }

        public async Task<TermDto> UpdateAsync(TermDto dto)
        {
            var term = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(term, dto);
            await _repository.UpdateAsync(term);
            return dto;
        }

        public async Task<Term> Delete(long Id)
        {
            var term = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(term).ConfigureAwait(true);
        }
    }
}
