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

namespace SchoolManagementSystem.Areas.School.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _service;
        private readonly ISubjectRepository _repository;
        private readonly IClassSetupRepository _classSetuprepository;
        private readonly ISubjectAssembler _assembler;
        public SubjectController(ISubjectService service, ISubjectRepository repository, ISubjectAssembler assembler, IClassSetupRepository classSetuprepository)
        {
            _repository = repository;
            _service = service;
            _assembler = assembler;
            _classSetuprepository = classSetuprepository;
        }
        public async Task<IActionResult> Index(SubjectViewModel vm, string message, string messege)
        {
            vm.Subjects = new List<Subject>();
            var subject = await _repository.GetAllSubjectAsync();
            vm.Subjects = subject;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            SubjectDto dto = new SubjectDto
            {
                ClassSetups = await _classSetuprepository.GetAllClassSetupAsync()
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(SubjectDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "Subject", new { message = "Subject  has been saved successfully." });
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
            SubjectDto dto = new SubjectDto
            {
                ClassSetups = await _classSetuprepository.GetAllClassSetupAsync()
            };
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(SubjectDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "Subject", new { message = "Subject  has been udpated successfully." });
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
            var subject = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(subject);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Subject subject)
        {
            try
            {
                if (subject != null)
                {
                    await _service.Delete(subject.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Subject", new { messege = "Subject has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(subject);
        }
        public async Task<IActionResult> subjectinfo(SubjectViewModel vm)
        {
            var sub = await _repository.GetAllSubjectAsync();
            var cls = await _classSetuprepository.GetAllClassSetupAsync();
            vm.classes = cls;
            vm.Subjects = sub;
            return View(vm);
        }
    }
}
