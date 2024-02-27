using FiboInfraStructure.Entity.FiboSchool;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.Src.Dto
{
    public class ManageMarksDto : BaseDto
    {
        public long? SessionSetupId { get; set; }
        public long? SubjectId { get; set; }
        public long? StudentId { get; set; }
        public long? ClassSetupId { get; set; }
        public long? SectionSetupId { get; set; }
        public long? FiscalYearId { get; set; }
        public long? TermId { get; set; }
        public List<ManageMarksDetail> ManageMarksDetails { get; set; }
        public List<Student> Students { get; set; }
        public List<ManageMarksDetailDto> DetailDto { get; set; }
        public IList<ClassSetup> ClassSetUps { get; set; } = new List<ClassSetup>();
        public SelectList ClassSetUpList => new SelectList(ClassSetUps, nameof(ClassSetup.Id), nameof(ClassSetup.Name));
        public IList<SessionSetup> SessionSetups { get; set; } = new List<SessionSetup>();
        public SelectList SessionSetupList => new SelectList(SessionSetups, nameof(SessionSetup.Id), nameof(SessionSetup.Session));
        public IList<Subject> Subjects { get; set; } = new List<Subject>();
        public SelectList SubjectList => new SelectList(Subjects, nameof(Subject.Id), nameof(Subject.SubjectName));
        public IList<SectionSetup> SectionSetups { get; set; } = new List<SectionSetup>();
        public SelectList SectionSetupList => new SelectList(SectionSetups, nameof(SectionSetup.Id), nameof(SectionSetup.Name));
        public IList<Term> Terms { get; set; } = new List<Term>();
        public SelectList TermList => new SelectList(Terms, nameof(Term.Id), nameof(Term.Name));

    }
}
