using FiboInfraStructure.Entity.FiboSchool;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.Src.Dto
{
    public class SubjectDto : BaseDto
    {
        public string SubjectName { get; set; }
        public string Abbreviation { get; set; }
        public long? ClassId { get; set; }
        public IList<ClassSetup> ClassSetups { get; set; } = new List<ClassSetup>();
        public SelectList ClassSetupList => new SelectList(ClassSetups, nameof(ClassSetup.Id), nameof(ClassSetup.Name));
    }
}
