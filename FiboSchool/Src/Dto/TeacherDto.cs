using FiboInfraStructure.Entity.FiboSchool;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboSchool.Src.Dto
{
    public class TeacherDto:BaseDto
    {
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public long? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        [NotMapped()]
        public IList<Subject> Subjects { get; set; } = new List<Subject>();
        public SelectList SubjectList => new SelectList(Subjects, nameof(Subject.Id), nameof(Subject.SubjectName));
    }
}
