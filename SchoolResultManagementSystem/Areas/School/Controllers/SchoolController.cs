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
    public class SchoolController : Controller
    {
        private readonly ISchoolSetupService _service;
        private readonly ISchoolSetupRepository _repository;
        private readonly ISchoolSetupAssembler _assembler;
        public SchoolController(ISchoolSetupService service, ISchoolSetupRepository repository, ISchoolSetupAssembler assembler)
        {
            _repository = repository;
            _service = service;
            _assembler = assembler;
        }
        public async Task<IActionResult> Index(SchoolSetupViewModel vm, string message, string messege)
        {
            vm.SchoolSetups = new List<SchoolSetUp>();
            var school = await _repository.GetAllSchoolSetupAsync();
            vm.SchoolSetups = school;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            SchoolSetupDto dto = new SchoolSetupDto
            {


            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(SchoolSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "School", new { message = "School Setup has been saved successfully." });
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
            SchoolSetupDto dto = new SchoolSetupDto();
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(SchoolSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "School", new { message = "School Setup has been updated successfully." });
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
            var school = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(school);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed( SchoolSetUp schoolSetUp)
        {
            try
            {
                if (schoolSetUp != null)
                {
                    await _service.Delete(schoolSetUp.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "School", new { messege = "School Setup been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(schoolSetUp);
        }
    }
}
