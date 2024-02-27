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
    public interface IProvienceService
    {
        Task<ProvienceDto> Insertasync(ProvienceDto dto);
        Task<Provience> Delete(long Id);
        Task<ProvienceDto> UpdateAsync(ProvienceDto dto);
    }
    public class ProvienceService : IProvienceService
    {
        private readonly IProvienceRepository _provienceRepository;
        private readonly IProvienceAssembler _assembler;
        public ProvienceService(IProvienceRepository provienceRepository, IProvienceAssembler assembler)
        {
            _provienceRepository = provienceRepository;
            _assembler = assembler;
        }
        public async Task<ProvienceDto> Insertasync(ProvienceDto dto)
        {
            Provience provience = new Provience();
            _assembler.copyTo(provience, dto);
            await _provienceRepository.AddAsync(provience);
            dto.Id = provience.Id;
            return dto;
        }

        public async Task<ProvienceDto> UpdateAsync(ProvienceDto dto)
        {
            var provience = await _provienceRepository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(provience, dto);
            await _provienceRepository.UpdateAsync(provience);
            return dto;
        }

        public async Task<Provience> Delete(long Id)
        {
            var province = await _provienceRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _provienceRepository.DeleteAsync(province).ConfigureAwait(true);
        }
    }
}
