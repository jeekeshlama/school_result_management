using FiboInfraStructure.Entity.FiboSchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.Src.ViewModel
{
    public class SubjectViewModel
    {
        public List<Subject> Subjects { get; set; }
        public List<ClassSetup> classes { get; set; }
        public long? ClassSetupId { get; set; }
    }
}
