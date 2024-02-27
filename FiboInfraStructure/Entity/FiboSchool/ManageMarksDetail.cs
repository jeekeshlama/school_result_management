using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Entity.FiboSchool
{
    public class ManageMarksDetail : BaseSetup
    {
        public long? ManageMarksId { get; set; }
        public long? StudentId { get; set; }
        public string FullMarks { get; set; }
        public string PassMarks { get; set; }
        public string ObtainedMarks { get; set; }
        public string HighestMarks { get; set; }
    }
}
