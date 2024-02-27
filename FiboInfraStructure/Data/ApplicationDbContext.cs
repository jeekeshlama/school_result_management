
using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Entity.FiboOffice;
using FiboInfraStructure.Entity.FiboSchool;
using FiboInfraStructure.Entity.FiboUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Data
{
    public class ApplicationUser : IdentityUser
    {

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<ClassSetup> ClassSetups { get; set; }
        public virtual DbSet<SectionSetup> SectionSetups { get; set; }

        // Address
        public virtual DbSet<Provience> Proviences { get; set; }
        public virtual DbSet<District> Districts { get; set; }

        public virtual DbSet<LocalLevel> LocalLevels { get; set; }


        // Office
        // public virtual DbSet<Employee> Employees { get; set; }
        //   public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<FiscalYear> FiscalYears { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<UserBranch> UserBranches { get; set; }

        //School 
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SessionSetup> SessionSetup { get; set; }
        public virtual DbSet<SchoolSetUp> SchoolSetUps { get; set; }
        //  public virtual DbSet<StaffSetup> StaffSetups { get; set; }



        public virtual DbSet<ManageMarks> ManageMarks { get; set; }
         public virtual DbSet<ManageMarksDetail> ManageMarksDetails { get; set; }

        public virtual DbSet<Term> Term { get; set; }
        // public virtual DbSet<Notice> Notices { get; set; }
       public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<AssignTeacher> AssignTeachers { get; set; }

        //Date
        // public virtual DbSet<Year> Years { get; set; }
        // public virtual DbSet<Month> Months { get; set; }


    }
}
