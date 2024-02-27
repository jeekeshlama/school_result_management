using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboSchool
{
    public class Performance : BaseSetup
    {
        public string Division { get; set; }
        public string TotalGrade { get; set; }
        public string GPA { get; set; }
        public string Position { get; set; }
        public string Percentage { get; set; }
        public string Discipline { get; set; }
        [ForeignKey("StudentId")]
        public long? StudentId { get; set; }
        [NotMapped()]
        public virtual Student Students { get; set; }
        [ForeignKey("SessionSetupId")]
        public long? SessionSetupId { get; set; }
        [NotMapped()]
        public virtual SessionSetup SessionSetups { get; set; }
        [ForeignKey("TermId")]
        public long? TermId { get; set; }
        [NotMapped()]
        public virtual Term terms { get; set; }
        [ForeignKey("ClassId")]
        public long? ClassId { get; set; }
        [NotMapped()]
        public virtual ClassSetup ClassSetups { get; set; }
        [ForeignKey("SectionSetupId")]
        public long? SectionSetupId { get; set; }
        [NotMapped()]
        public virtual SectionSetup SectionSetups { get; set; }

    }
}
