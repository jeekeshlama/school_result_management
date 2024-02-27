using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboInfraStructure.Entity.FiboSchool
{
    public  class Subject: BaseSetup
    {
        public string SubjectName { get; set; }
        public string Abbreviation { get; set; }
        [ForeignKey("ClassId")]
        public long? ClassId { get; set; }
        [NotMapped()]
        public virtual ClassSetup ClassSetup { get; set; }
    }
}
