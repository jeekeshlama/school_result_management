using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Entity.FiboSchool;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.Src.Dto
{
    public class StudentDto:BaseDto
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string WardNo { get; set; }
        public long? Gender { get; set; }
        public string Religion { get; set; }
        public string Address { get; set; }
        public string Admission { get; set; }
        public long? SectionSetupId { get; set; }
        public long? ClassSetupId { get; set; }
        public string AdmissionDate { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MotherOccupation { get; set; }
        public string MobileNumber { get; set; }

        public string FatherOccupation { get; set; }
        public long? FiscalYearId { get; set; }
        public long? ProvienceId { get; set; }
        public virtual Provience Provience { get; set; }
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }
        public long? LocalLevelId { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }
        [NotMapped()]
        public IList<Provience> Proviencess { get; set; } = new List<Provience>();
        public SelectList ProvienceList => new SelectList(Proviencess, nameof(Provience.Id), nameof(Provience.Name));
        public IList<ClassSetup> ClassSetUps { get; set; } = new List<ClassSetup>();
        public SelectList ClassSetUpList => new SelectList(ClassSetUps, nameof(ClassSetup.Id), nameof(ClassSetup.Name));
        public IList<District> Districts { get; set; } = new List<District>();
        public SelectList DistrictList => new SelectList(Districts, nameof(District.Id), nameof(District.Name));
        public IList<Student> Students { get; set; } = new List<Student>();
        public SelectList StudentList => new SelectList(Students, nameof(Student.Id), nameof(Student.Name));

        public IList<LocalLevel> LocalLevels { get; set; } = new List<LocalLevel>();
        public SelectList LocalLevelList => new SelectList(LocalLevels, nameof(LocalLevel.Id), nameof(LocalLevel.Name));
        public IList<SectionSetup> SectionSetups { get; set; } = new List<SectionSetup>();
        public SelectList SectionSetupList => new SelectList(SectionSetups, nameof(SectionSetup.Id), nameof(SectionSetup.Name));
    }
}
