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
   public interface IDistrictService
    {
        Task<DistrictDto> Insertasync(DistrictDto dto);
        Task<District> Delete(long Id);
        Task<DistrictDto> UpdateAsync(DistrictDto dto);
    }
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IDistrictAssembler _assembler;
        public DistrictService(IDistrictRepository districtRepository , IDistrictAssembler assembler)
        {
            _districtRepository = districtRepository;
            _assembler = assembler;
        }
        public async Task<DistrictDto> Insertasync(DistrictDto dto)
        {
            District district = new District();
            _assembler.copyTo(district, dto);
            await _districtRepository.AddAsync(district);
            dto.Id = district.Id;
            return dto;
        }

        public async Task<DistrictDto> UpdateAsync(DistrictDto dto)
        {
            District district = new District();
            _assembler.modifyTo(district, dto);
            await _districtRepository.UpdateAsync(district);
            return dto;
        }

        public async Task<District> Delete(long Id)
        {
            var district = await _districtRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _districtRepository.DeleteAsync(district).ConfigureAwait(true);
        }
    }
}
