using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.Src.Dto
{
    public class ManageMarksDetailDto : BaseDto
    {
        public long? ManageMarksId { get; set; }
        public long? StudentId { get; set; }
        public string FullMarks { get; set; }
        public string PassMarks { get; set; }
        public string ObtainedMarks { get; set; }
        public string HighestMarks { get; set; }

    }
}
