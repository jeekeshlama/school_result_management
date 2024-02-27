using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboSchool
{
    public class ManageMarks : BaseSetup
    {
        [ForeignKey("SessionSetupId")]
        public long? SessionSetupId { get; set; }

        [ForeignKey("SubjectId")]
        public long? SubjectId { get; set; }

        [ForeignKey("ClassSetupId")]
        public long? ClassSetupId { get; set; }
        public long? SectionSetupId { get; set; }
        public long? FiscalYearId { get; set; }
        public long? TermId { get; set; }
        public virtual SessionSetup SessionSetup { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ClassSetup ClassSetup { get; set; }
        public virtual SectionSetup SectionSetup { get; set; }

    }
}
