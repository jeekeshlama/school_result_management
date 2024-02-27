using FiboInfraStructure.Entity.FiboSchool;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboSchool.Src.Dto
{
    public class AssignTeacherDto: BaseDto
    {
        public long? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public IList<Teacher> Teachers { get; set; } = new List<Teacher>();
        public SelectList TeacherList => new SelectList(Teachers, nameof(Teacher.Id), nameof(Teacher.Name));
        public long? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public IList<Subject> Subjects { get; set; } = new List<Subject>();
        public SelectList SubjectList => new SelectList(Subjects, nameof(Subject.Id), nameof(Subject.SubjectName));
        public long? ClassId { get; set; }
        public virtual ClassSetup ClassSetup { get; set; }
        public IList<ClassSetup> ClassSetups { get; set; } = new List<ClassSetup>();
        public SelectList ClassSetupList => new SelectList(ClassSetups, nameof(ClassSetup.Id), nameof(ClassSetup.Name));
        public long? SectionId { get; set; }
        public virtual SectionSetup SectionSetup { get; set; }
        public IList<SectionSetup> SectionSetups { get; set; } = new List<SectionSetup>();
        public SelectList SectionSetupList => new SelectList(SectionSetups, nameof(SectionSetup.Id), nameof(SectionSetup.Name));
    }
}
