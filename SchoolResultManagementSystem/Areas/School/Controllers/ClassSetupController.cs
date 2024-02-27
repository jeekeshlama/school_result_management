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
    public class ClassSetupController : Controller
    {
        private readonly IClassSetupService _service;
        private readonly IClassSetupRepository _repository;
        private readonly IClassSetupAssembler _assembler;
        public ClassSetupController(IClassSetupService service, IClassSetupRepository repository, IClassSetupAssembler assembler)
        {
            _repository = repository;
            _service= service;
            _assembler = assembler;
        }
        public async Task<IActionResult> Index(ClassSetupViewModel vm, string message,string messege)
        {
            
            vm.ClassSetups = new List<ClassSetup>();
            var classSetup = await _repository.GetAllClassSetupAsync();
            vm.ClassSetups = classSetup;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ClassSetupDto dto = new ClassSetupDto
            {

            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ClassSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "ClassSetup", new { message = "Class Setup has been saved successfully." });
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
            ClassSetupDto dto = new ClassSetupDto();
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ClassSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "ClassSetup", new { message= "Class Setup has been saved successfully." });
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
            var classSetup = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(classSetup);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(ClassSetup classSetup)
        {
            try
            {
                if (classSetup != null)
                {
                    await _service.Delete(classSetup.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "ClassSetup", new { messege = "Class Setup been Delete successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(classSetup);
        }
    }
}
