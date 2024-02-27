using System;
using System.Collections.Generic;
using System.Text;

namespace FiboUser.Constants
{
    public class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Premissions.{module}.Create",
                $"Premissions.{module}.Delete",
                $"Premissions.{module}.Update",
                $"Premissions.{module}.View",
                $"Premissions.{module}.Index",
                $"Premissions.{module}.BranchReport",
            };
        }
        public static class ApplicationPermission
        {
            //Account Register
            public const string AccountView = "Permissions.Account.View";
            public const string AccountRegister = "Permissions.Account.Register";
            public const string AccountIndex = "Permissions.Account.Index";
            public const string Delete = "Permissions.Products.Delete";

            
            //Branch
            public const string BranchView = "Permissions.Branch.View";
            public const string BranchCreate = "Permissions.Branch.Create";
            public const string BranchDelete = "Permissions.Branch.Delete";
            public const string BranchIndex = "Permissions.Branch.Index";
            public const string BranchUpdate = "Permissions.Branch.Update";
            public const string BranchRerport = "Permissions.Branch.BranchReport";


            //District
            public const string DistrictView = "Permissions.District.View";
            public const string DistrictCreate = "Permissions.District.Create";
            public const string DistrictDelete = "Permissions.District.Delete";
            public const string DistrictIndex = "Permissions.District.Index";
            public const string DistrictUpdate = "Permissions.District.Update";

          

           

            //Fascal Year
            public const string FiscalYearView = "Permissions.FiscalYear.View";
            public const string FiscalYearCreate = "Permissions.FiscalYear.Create";
            public const string FiscalYearUpdate = "Permissions.FiscalYear.Update";
            public const string FiscalYearDelete = "Permissions.FiscalYear.Delete";
            public const string FiscalYearIndex = "Permissions.FiscalYear.Index";

           
            //Local Level
            public const string LocalLevelView = "Permissions.LocalLevel.View";
            public const string LocalLevelCreate = "Permissions.LocalLevel.Create";
            public const string LocalLevelDelete = "Permissions.LocalLevel.Delete";
            public const string LocalLevelIndex = "Permissions.LocalLevel.Index";
            public const string LocalLevelUpdate = "Permissions.LocalLevel.Update";

           
            //Office
            public const string OfficeView = "Permissions.Office.View";
            public const string OfficeCreate = "Permissions.Office.Create";
            public const string OfficeDelete = "Permissions.Office.Delete";
            public const string OfficeDetails = "Permissions.Office.Details";
            public const string OfficeIndex = "Permissions.Office.Index";
            public const string OfficeUpdate = "Permissions.Office.Update";

            
            //Provience
            public const string ProvienceView = "Permissions.Provience.View";
            public const string ProvienceCreate = "Permissions.Provience.Create";
            public const string ProvienceDelete = "Permissions.Provience.Delete";
            public const string ProvienceIndex = "Permissions.Provience.Index";
            public const string ProvienceUpdate = "Permissions.Provience.Update";

            //ManageMarks
            public const string ManageMarksView = "Permissions.ManageMarks.View";
            public const string ManageMarksStudentManageMarks = "Permissions.ManageMarks.StudentManageMarks";
            public const string ManageMarksIndex = "Permissions.ManageMarks.Index";
            public const string ManageMarksUpdate = "Permissions.ManageMarks.Update";
            public const string ManageMarksCreate = "Permissions.ManageMarks.Create";


            //Student
            public const string StudentView = "Permissions.Student.View";
            public const string StudentCreate = "Permissions.Student.Create";
            public const string StudentDelete = "Permissions.Student.Delete";
            public const string StudentIndex = "Permissions.Student.Index";
            public const string StudentUpdate = "Permissions.Student.Update";

            //Subject
            public const string SubjectView = "Permissions.Subject.View";
            public const string SubjectCreate = "Permissions.Subject.Create";
            public const string SubjectDelete = "Permissions.Subject.Delete";
            public const string SubjectIndex = "Permissions.Subject.Index";
            public const string SubjectUpdate = "Permissions.Subject.Update";

            //SectionSetup
            public const string SectionSetupView = "Permissions.SectionSetup.View";
            public const string SectionSetupCreate = "Permissions.SectionSetup.Create";
            public const string SectionSetupDelete = "Permissions.SectionSetup.Delete";
            public const string SectionSetupIndex = "Permissions.SectionSetup.Index";
            public const string SectionSetupUpdate = "Permissions.SectionSetup.Update";

            //Term
            public const string TermView = "Permissions.Term.View";
            public const string TermCreate = "Permissions.Term.Create";
            public const string TermDelete = "Permissions.Term.Delete";
            public const string TermIndex = "Permissions.Term.Index";
            public const string TermUpdate = "Permissions.Term.Update";

            //Teacher
            public const string TeacherView = "Permissions.Teacher.View";
            public const string TeacgerCreate = "Permissions.Teacher.Create";
            public const string TeacherDelete = "Permissions.Teacher.Delete";
            public const string TeacherIndex = "Permissions.Teacher.Index";
            public const string TeacherUpdate = "Permissions.Teacher.Update";

            //Session
            public const string SessionView = "Permissions.Session.View";
            public const string SessionCreate = "Permissions.Session.Create";
            public const string SessionDelete = "Permissions.Session.Delete";
            public const string SessionIndex = "Permissions.Session.Index";
            public const string SessionUpdate = "Permissions.Session.Update";

            //School
            public const string SchoolView = "Permissions.School.View";
            public const string SchoolCreate = "Permissions.School.Create";
            public const string SchoolDelete = "Permissions.School.Delete";
            public const string SchoolIndex = "Permissions.School.Index";
            public const string SchoolUpdate = "Permissions.School.Update";

            //ClassSetup
            public const string ClassSetupView = "Permissions.ClassSetup.View";
            public const string ClassSetupCreate = "Permissions.ClassSetup.Create";
            public const string ClassSetupDelete = "Permissions.ClassSetup.Delete";
            public const string ClassSetupIndex = "Permissions.ClassSetup.Index";
            public const string ClassSetupUpdate = "Permissions.ClassSetup.Update";

            //ClassSetup
            public const string RoleView = "Permissions.Role.View";
            public const string RoleCreate = "Permissions.Role.Index";

            //ClassSetup
            public const string PermissionView = "Permissions.Permission.View";
            public const string PermissionCreate = "Permissions.Permission.Index";

        }
    }
}
