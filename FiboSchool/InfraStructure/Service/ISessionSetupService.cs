using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Service
{
    public interface ISessionSetupService
    {
        Task<SessionSetupDto> Insertasync(SessionSetupDto dto);
        Task<SessionSetup> Delete(long Id);
        Task<SessionSetup> ToggleStatus(SessionSetup sessionSetup);
        Task<SessionSetupDto> UpdateAsync(SessionSetupDto dto);
    }
    public class SessionSetupService : ISessionSetupService
    {
        private readonly ISessionSetupRepository _repository;
        private readonly ISessionSetupAssembler _assembler;
        public SessionSetupService(ISessionSetupRepository repository, ISessionSetupAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<SessionSetupDto> Insertasync(SessionSetupDto dto)
        {
            SessionSetup sessionSetup = new SessionSetup();
            _assembler.copyTo(sessionSetup, dto);
            await _repository.AddAsync(sessionSetup);
            dto.Id = sessionSetup.Id;
            return dto;
        }

        public async Task<SessionSetupDto> UpdateAsync(SessionSetupDto dto)
        {
            var sessionSetup = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(sessionSetup, dto);
            await _repository.UpdateAsync(sessionSetup);
            return dto;
        }

        public async Task<SessionSetup> Delete(long Id)
        {
            var sessionSetup = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(sessionSetup).ConfigureAwait(true);
        }
        public async Task<SessionSetup> ToggleStatus(SessionSetup sessionSetup)
        {
            if (sessionSetup != null)
            {
                sessionSetup.ChangeStatus();
            }
            return await _repository.UpdateAsync(sessionSetup).ConfigureAwait(true);
        }
    }
}
