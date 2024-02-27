using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.InfraStructure.Service;
using FiboSchool.Src.Dto;
using FiboSchool.Src.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolResultManagementSystem.Areas.School.Controllers
{
    public class AssignTeacherController : Controller
    {
        private readonly IAssignTeacherService _service;
        private readonly IAssignTeacherRepository _repository;
        private readonly ISubjectRepository _subjectrepository;
        private readonly IClassSetupRepository _classrepository;
        private readonly ISectionSetupRepository _sectionrepository;
        private readonly ITeacherRepository _teacherrepository;

        private readonly IAssignTeacherAssembler _assembler;
        public AssignTeacherController(IAssignTeacherService service, IAssignTeacherRepository repository, IAssignTeacherAssembler assembler, ISubjectRepository subjectrepository, ISectionSetupRepository sectionSetupRepository, IClassSetupRepository classSetupRepository, ITeacherRepository teacherRepository)
        {
            _repository = repository;
            _service = service;
            _assembler = assembler;
            _subjectrepository = subjectrepository;
            _classrepository = classSetupRepository;
            _teacherrepository = teacherRepository;
            _sectionrepository = sectionSetupRepository;
        }
        public async Task<IActionResult> Index(AssignTeacherViewModel vm, string message, string messege)
        {
            vm.AssignTeachers = new List<AssignTeacher>();
            var assignteacher = await _repository.GetAllAssignTeacherAsync();
            vm.AssignTeachers = assignteacher;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            AssignTeacherDto dto = new AssignTeacherDto
            {
                Subjects = await _subjectrepository.GetAllSubjectAsync(),
                ClassSetups = await _classrepository.GetAllClassSetupAsync(),
                SectionSetups = await _sectionrepository.GetAllSectionSetupAsync(),
                Teachers = await _teacherrepository.GetAllTeacherAsync(),


            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(AssignTeacherDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "AssignTeacher", new { message = "Teacher  has been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(dto);
        }

        [HttpGet()]
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {

            }
            var entity = await _repository.GetByIdAsync(id.Value) ?? throw new Exception();
            AssignTeacherDto dto = new AssignTeacherDto
            {
                Subjects = await _subjectrepository.GetAllSubjectAsync(),
                ClassSetups = await _classrepository.GetAllClassSetupAsync(),
                SectionSetups = await _sectionrepository.GetAllSectionSetupAsync(),
                Teachers = await _teacherrepository.GetAllTeacherAsync(),


            };
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(AssignTeacherDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "AssignTeacher", new { message = "Teacher  has been udpated successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var assignteacher = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(assignteacher);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(AssignTeacher assignteacher)
        {
            try
            {
                if (assignteacher != null)
                {
                    await _service.Delete(assignteacher.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "AssignTeacher", new { messege = "Teacher has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(assignteacher);
        }
        public async Task<JsonResult> LoadSubject(long Id)
        {
            var subjectList = await _subjectrepository.GetAllSubjectAsync();
            var subject = subjectList.Where(x => x.ClassId == Id).ToList();
            List<Subject> list = new List<Subject>();
            foreach (var item in subject)
            {
                list.Add(new Subject { Id = (long)item.Id, SubjectName = item.SubjectName });
            }
            return Json(list);
        }
    }
}
