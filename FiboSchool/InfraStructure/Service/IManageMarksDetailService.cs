using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Service
{
    
    public interface IManageMarksDetailService
    {
        Task<ManageMarksDetailDto> Insertasync(ManageMarksDetailDto dto);
        Task<ManageMarksDetail> Delete(long Id);
        Task<ManageMarksDetailDto> UpdateAsync(ManageMarksDetailDto dto);
    }
    public class ManageMarksDetailService : IManageMarksDetailService
    {
        private readonly IManageMarksDetailRepository _repository;
        private readonly IManageMarksDetailAssembler _assembler;
        public ManageMarksDetailService(IManageMarksDetailRepository repository, IManageMarksDetailAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<ManageMarksDetailDto> Insertasync(ManageMarksDetailDto dto)
        {
            ManageMarksDetail marks = new ManageMarksDetail();
            _assembler.copyTo(marks, dto);
            await _repository.AddAsync(marks);
            dto.Id = marks.Id;
            return dto;
        }

        public async Task<ManageMarksDetailDto> UpdateAsync(ManageMarksDetailDto dto)
        {
            var marks = await _repository.GetByIdAsync(dto.Id);
            _assembler.modifyTo(marks, dto);
            await _repository.UpdateAsync(marks);
            return dto;
        }

        public async Task<ManageMarksDetail> Delete(long Id)
        {
            var marks = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(marks).ConfigureAwait(true);
        }
    }
}
