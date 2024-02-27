using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboSchool
{
    public class Teacher : BaseSetup
    {
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        [ForeignKey("SubjectId")]
        public long? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
