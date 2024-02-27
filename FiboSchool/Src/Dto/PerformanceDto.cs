using System;
using System.Collections.Generic;
using System.Text;
using FiboInfraStructure.Entity.FiboSchool;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiboSchool.Src.Dto
{
    public class PerformanceDto : BaseDto
    {
        public string Division { get; set; }
        public string TotalGrade { get; set; }
        public string GPA { get; set; }
        public string Position { get; set; }
        public string Percentage { get; set; }
        public string Discipline { get; set; }
        public long? StudentId { get; set; }
        public virtual Student Students { get; set; }
        public long? SessionSetupId { get; set; }
        public virtual SessionSetup SessionSetups { get; set; }
        public long? TermId { get; set; }
        public virtual Term terms { get; set; }
        public long? ClassId { get; set; }
        public virtual ClassSetup ClassSetups { get; set; }
        public long? SectionSetupId { get; set; }
        public virtual SectionSetup SectionSetups { get; set; }
        public List<ManageMarks> ManageMarksList { get; set; }
        public ManageMarks ManageMarks { get; set; }
        public List<ManageMarksDetail> DetailList { get; set; }
        public List<Subject> SubjectList { get; set; }
        public List<Student> StudentList { get; set; }
        public List<Student> AllClassStudentList { get; set; }

        public List<ManageMarksDetail> AllDetailList { get; set; }

        //public IList<ClassSetup> ClassSetUps { get; set; } = new List<ClassSetup>();
        //public SelectList ClassSetUpList => new SelectList(ClassSetUps, nameof(ClassSetup.Id), nameof(ClassSetup.Name));
        //public IList<Student> Studentlist { get; set; } = new List<Student>();
        //public SelectList StudentList => new SelectList(Studentlist, nameof(Student.Id), nameof(Student.Name));
        //public IList<SessionSetup> SessionSetUpList { get; set; } = new List<SessionSetup>();
        //public SelectList SessionSetupList => new SelectList(SessionSetUpList, nameof(SessionSetup.Id), nameof(SessionSetup.Session));
        //public IList<Term> Terms { get; set; } = new List<Term>();
        //public SelectList TermList => new SelectList(Terms, nameof(Term.Id), nameof(Term.Name));
        //public IList<SectionSetup> SectionSetUpList { get; set; } = new List<SectionSetup>();
        //public SelectList SectionSetupList => new SelectList(SectionSetUpList, nameof(SectionSetup.Id), nameof(SectionSetup.Name));
    }
}
