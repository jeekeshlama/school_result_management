using FiboInfraStructure.Entity.FiboSchool;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.Src.ViewModel
{
    public class ResultViewModel
    {
        public List<ManageMarks> ManageMarksList { get; set; }
        public ManageMarks ManageMarks { get; set; }
        public List<ManageMarksDetail> DetailList { get; set; }
        public List<Subject> SubjectList { get; set; }
        public List<Student> StudentList { get; set; }
        public Performance Performance { get; set; }
    }
}
