using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.InfraStructure.Assembler;
using FiboOffice.InfraStructure.Repository;
using FiboOffice.Src.Dto;

namespace FiboOffice.InfraStructure.Service
{
   public interface IOfficeService
    {
        Task<OfficeDto> InsertAsync(OfficeDto dto);
        Task<Office> Delete(long Id);
        Task<OfficeDto> UpdateAsync(OfficeDto officeDto);
    }
   public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IOfficeAssembler _assembler;
        public OfficeService(IOfficeRepository officeRepository, IOfficeAssembler  assembler)
        {
            _officeRepository = officeRepository;
            _assembler = assembler;
        }
        public async Task<OfficeDto> InsertAsync(OfficeDto dto)
        {
            Office office = new Office();
            _assembler.copyTo(office, dto);
            await _officeRepository.AddAsync(office);
            dto.Id = office.Id;
            return dto;
        }

        public async Task<OfficeDto> UpdateAsync(OfficeDto dto)
        {
            Office office = new Office();
            _assembler.modifyTo(office, dto);
            await _officeRepository.UpdateAsync(office);
            return dto;
        }

        public async Task<Office> Delete(long Id)
        {
            var office = await _officeRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _officeRepository.DeleteAsync(office).ConfigureAwait(true);
        }

    }
}
