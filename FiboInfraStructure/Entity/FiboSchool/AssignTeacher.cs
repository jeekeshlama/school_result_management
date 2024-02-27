using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboSchool
{
    public class AssignTeacher : BaseSetup
    {
        [ForeignKey("TeacherId")]
        public long? TeacherId { get; set; }
        [NotMapped()]
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("ClassId")]
        public long? ClassId { get; set; }
        [NotMapped()]
        public virtual ClassSetup ClassSetup { get; set; }
        [ForeignKey("SubjectId")]
        public long? SubjectId { get; set; }
        [NotMapped()]
        public virtual Subject Subject { get; set; }
        [ForeignKey("SectionId")]
        public long? SectionId { get; set; }
        [NotMapped()]
        public virtual SectionSetup SectionSetup { get; set; }
    }
}
    