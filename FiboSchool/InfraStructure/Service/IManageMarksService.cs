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
    public interface IManageMarksService
    {
        Task<ManageMarksDto> Insertasync(ManageMarksDto dto);
        Task<ManageMarks> Delete(long Id);
        Task<ManageMarksDto> UpdateAsync(ManageMarksDto dto);
    }
    public class ManageMarksService : IManageMarksService
    {
        private readonly IManageMarksRepository _repository;
        private readonly IManageMarksAssembler _assembler;
        private readonly IManageMarksDetailAssembler _detailAssembler;
        private readonly IManageMarksDetailRepository _detailRepo;
        public ManageMarksService(
            IManageMarksRepository repository
            , IManageMarksAssembler assembler
            , IManageMarksDetailAssembler detailAssembler
            , IManageMarksDetailRepository detailRepo
            )
        {
            _repository = repository;
            _assembler = assembler;
            _detailAssembler = detailAssembler;
            _detailRepo = detailRepo;
        }
        public async Task<ManageMarksDto> Insertasync(ManageMarksDto dto)
        {
            ManageMarks marks = new ManageMarks();
            _assembler.copyTo(marks, dto);
            await _repository.AddAsync(marks);
            dto.Id = marks.Id;
            foreach(var item in dto.DetailDto)
            {
                item.ManageMarksId = dto.Id;
                ManageMarksDetail _detail = new ManageMarksDetail();
                _detailAssembler.copyTo(_detail, item);
                await _detailRepo.AddAsync(_detail);
            }
            return dto;
        }

        public async Task<ManageMarksDto> UpdateAsync(ManageMarksDto dto)
        {
            ManageMarks marks = new ManageMarks();
            _assembler.modifyTo(marks, dto);
            await _repository.UpdateAsync(marks);
            dto.Id = marks.Id;
            foreach (var item in dto.ManageMarksDetails)
            {
                await _detailRepo.UpdateAsync(item);
            }
            return dto;
        }

        public async Task<ManageMarks> Delete(long Id)
        {
            var marks = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(marks).ConfigureAwait(true);
        }
    }
}
