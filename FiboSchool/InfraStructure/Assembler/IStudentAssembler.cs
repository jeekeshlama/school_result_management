using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Assembler
{
    public interface IStudentAssembler
    {
        void copyTo(Student student, StudentDto dto);
        void copyFrom(StudentDto dto, Student student);
        void modifyTo(Student student, StudentDto dto);
    }

    public class StudentAssembler : IStudentAssembler
    {
        public void copyTo(Student student, StudentDto dto)
        {
            student.ProvienceId = dto.ProvienceId; 
            student.DistrictId= dto.DistrictId;
            student.BranchId = dto.BranchId;
            student.SectionSetupId = dto.SectionSetupId;
            student.Religion = dto.Religion;
            student.Name = dto.Name;
            student.Nationality = dto.Nationality;
            student.Admission = dto.Admission;
            student.AdmissionDate = dto.AdmissionDate;
            student.ClassSetupId = dto.ClassSetupId;
            student.CreatedBy= dto.CreatedBy;
            student.CreatedDate = DateTime.Now.Date;
            student.DateOfBirth = dto.DateOfBirth;          
            student.Email = dto.Email;
            student.FatherName = dto.FatherName;
            student.FatherOccupation= dto.FatherOccupation; 
            student.Gender = dto.Gender;
            student.WardNo = dto.WardNo;
            student.MotherName = dto.MotherName;
            student.MotherOccupation = dto.MotherOccupation;
            student.LocalLevelId = dto.LocalLevelId;
            student.MobileNumber = dto.MobileNumber;
            student.FiscalYearId = dto.FiscalYearId;
            student.Address = dto.Address;
        }

        public void copyFrom(StudentDto dto, Student student)
        {
            dto.BranchId = student.BranchId;
            dto.Id = student.Id;
            dto.Admission = student.Admission;
            dto.AdmissionDate = student.AdmissionDate;
            dto.BranchId=student.BranchId; 
            dto.SectionSetupId = student.SectionSetupId; 
            dto.ClassSetupId = student.ClassSetupId;
            dto.ProvienceId = student.ProvienceId;
            dto.DistrictId = student.DistrictId;
            dto.LocalLevelId = student.LocalLevelId;
            dto.CreatedBy = student.CreatedBy;
            dto.CreatedDate = student.CreatedDate;
            dto.DateOfBirth = student.DateOfBirth;
            dto.FatherName = student.FatherName;
            dto.MobileNumber = student.MobileNumber;
            dto.MotherName = student.MotherName;
            dto.MotherOccupation = student.MotherOccupation;
            dto.FiscalYearId = student.FiscalYearId;
            dto.Nationality = student.Nationality;
            dto.Name = student.Name;
            dto.Religion = student.Religion;
            dto.FatherOccupation = student.FatherOccupation;
            dto.WardNo = student.WardNo;
            dto.Email = student.Email;
            dto.Address = student.Address;
        }

        public void modifyTo(Student student, StudentDto dto)
        {
            student.FiscalYearId = dto.FiscalYearId;
            student.Id=dto.Id;
            student.ProvienceId = dto.ProvienceId;
            student.DistrictId = dto.DistrictId;
            student.BranchId = dto.BranchId;
            student.SectionSetupId = dto.SectionSetupId;
            student.Religion = dto.Religion;
            student.Name = dto.Name;
            student.Nationality = dto.Nationality;
            student.Admission = dto.Admission;
            student.AdmissionDate = dto.AdmissionDate;
            student.ClassSetupId = dto.ClassSetupId;
            student.CreatedBy = dto.CreatedBy;
            student.CreatedDate = dto.CreatedDate;
            student.ModifiedBy = dto.ModifiedBy;
            student.ModifiedDate = DateTime.Now.Date;
            student.DateOfBirth = dto.DateOfBirth;
            student.Email = dto.Email;
            student.FatherName = dto.FatherName;
            student.FatherOccupation = dto.FatherOccupation;
            student.Gender = dto.Gender;
            student.WardNo = dto.WardNo;
            student.MotherName = dto.MotherName;
            student.MotherOccupation = dto.MotherOccupation;
            student.LocalLevelId = dto.LocalLevelId;
            student.MobileNumber = dto.MobileNumber;
            student.Address = dto.Address;
        }
    }
}