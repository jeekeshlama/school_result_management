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
    public class TeacherController : Controller
    {
        private readonly ITeacherService _service;
        private readonly ITeacherRepository _repository;
        private readonly ISubjectRepository _subjectrepository;
        private readonly ITeacherAssembler _assembler;
        public TeacherController(ITeacherService service, ITeacherRepository repository, ITeacherAssembler assembler, ISubjectRepository subjectrepository)
        {
            _repository = repository;
            _service = service;
            _assembler = assembler;
            _subjectrepository = subjectrepository;
        }
        public async Task<IActionResult> Index(TeacherViewModel vm, string message, string messege)
        {
            vm.Teachers = new List<Teacher>();
            var teacher = await _repository.GetAllTeacherAsync();
            vm.Teachers = teacher;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            TeacherDto dto = new TeacherDto
            {
                Subjects = await _subjectrepository.GetAllSubjectAsync()
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(TeacherDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "Teacher", new { message = "Teacher  has been saved successfully." });
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
            TeacherDto dto = new TeacherDto
            {
                Subjects = await _subjectrepository.GetAllSubjectAsync()
            };
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(TeacherDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "Teacher", new { message = "Teacher  has been udpated successfully." });
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
            var teacher = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(teacher);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Teacher teacher)
        {
            try
            {
                if (teacher != null)
                {
                    await _service.Delete(teacher.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Teacher", new { messege = "Teacher has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(teacher);
        }

    }
}
