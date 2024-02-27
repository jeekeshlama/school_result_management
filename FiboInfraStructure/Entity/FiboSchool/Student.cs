using FiboInfraStructure.Entity.FiboAddress;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboInfraStructure.Entity.FiboSchool
{
    public class Student: BaseSetup
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public  string Nationality { get; set; }
        public string Email { get; set; }
        public string WardNo { get; set; }
        public long? Gender { get; set; }
        public string Religion { get; set; }
        public string Admission { get; set; }
        public long? FiscalYearId { get; set; }
        public string AdmissionDate { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MotherOccupation { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string FatherOccupation { get; set; }
        [ForeignKey("ProvienceId")]
        public long? ProvienceId { get; set; }
        public virtual Provience Provience { get; set; }

        [ForeignKey("DistrictId")]
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }

        [ForeignKey("LocalLevelId")]
        public long? LocalLevelId { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }
        [ForeignKey("ClassSetupId")]

        public long? ClassSetupId { get; set; }
        public virtual ClassSetup ClassSetup { get; set; }
        [ForeignKey("SectionSetupId")]

        public long? SectionSetupId { get; set; }
        public virtual SectionSetup SectionSetup { get; set; }

    }
}
