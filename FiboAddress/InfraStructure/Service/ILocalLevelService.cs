using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiboAddress.InfraStructure.Assembler;
using FiboAddress.InfraStructure.Repository;
using FiboAddress.Src.Dto;
using FiboInfraStructure.Entity.FiboAddress;

namespace FiboAddress.InfraStructure.Service
{
   public interface ILocalLevelService
    {
        Task<LocalLevelDto> Insertasync(LocalLevelDto dto);
        Task<LocalLevel> Delete(long Id);
        Task<LocalLevelDto> UpdateAsync(LocalLevelDto dto);
    }
    public class LocalLevelService : ILocalLevelService
    {
        private readonly ILocalLevelRepository _localLevelRepository;
        private readonly ILocalLevelAssembler _assembler;
        public LocalLevelService ( ILocalLevelRepository localLevelRepository , ILocalLevelAssembler  assembler)
        {
            _localLevelRepository  = localLevelRepository;
            _assembler = assembler;
        }
        public async Task<LocalLevelDto> Insertasync(LocalLevelDto dto)
        {
            LocalLevel localLevel  = new LocalLevel();
            _assembler.copyTo(localLevel, dto);
            await _localLevelRepository.AddAsync(localLevel);
            dto.Id = localLevel.Id;
            return dto;
        }

        public async Task<LocalLevelDto> UpdateAsync(LocalLevelDto dto)
        {
            LocalLevel localLevel  = new LocalLevel();
            _assembler.modifyTo(localLevel, dto);
            await _localLevelRepository.UpdateAsync(localLevel);
            return dto;
        }

        public async Task<LocalLevel> Delete(long Id)
        {
            var localLevel = await _localLevelRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _localLevelRepository.DeleteAsync(localLevel).ConfigureAwait(true);
        }
    }
}

