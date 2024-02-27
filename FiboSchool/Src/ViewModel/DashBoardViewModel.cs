using FiboInfraStructure.Entity.FiboSchool;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.Src.ViewModel
{
   public class DashBoardViewModel
    {
        public List<ManageMarks> ManageMarksList { get; set; }
        public ManageMarks ManageMarks { get; set; }
        public List<ManageMarksDetail> DetailList { get; set; }
        public List<Subject> SubjectList { get; set; }
        public List<Student> StudentList { get; set; }
        public long? StudentId { get; set; }
        public string studentName { get; set; }
        public long? ClassId { get; set; }
        public long? SectionId { get; set; }
        public long? TermId { get; set; }

        public IList<ClassSetup> ClassSetUps { get; set; } = new List<ClassSetup>();
        public SelectList ClassSetUpList => new SelectList(ClassSetUps, nameof(ClassSetup.Id), nameof(ClassSetup.Name));
       /* public IList<Student> Students { get; set; } = new List<Student>();
        public SelectList StudentList => new SelectList(Students, nameof(Student.Id), nameof(Student.Name));*/
        public IList<SectionSetup> SectionSetups { get; set; } = new List<SectionSetup>();
        public SelectList SectionSetupList => new SelectList(SectionSetups, nameof(SectionSetup.Id), nameof(SectionSetup.Name));
        public IList<Term> Terms { get; set; } = new List<Term>();
        public SelectList TermList => new SelectList(Terms, nameof(Term.Id), nameof(Term.Name));
    }
}
