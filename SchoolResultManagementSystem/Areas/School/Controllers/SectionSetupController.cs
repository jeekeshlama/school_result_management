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
    public class SectionSetupController : Controller
    {
        private readonly ISectionSetupService _service;
        private readonly ISectionSetupRepository _repository;
        private readonly ISectionSetupAssembler _assembler;
        public SectionSetupController(ISectionSetupService service, ISectionSetupRepository repository, ISectionSetupAssembler assembler)
        {
            _repository = repository;
            _service = service;
            _assembler = assembler;
        }
        public async Task<IActionResult> Index(SectionSetupViewModel vm, string message, string messege)
        {
            vm.SectionSetups = new List<SectionSetup>();
            var sectionSetup = await _repository.GetAllSectionSetupAsync();
            vm.SectionSetups = sectionSetup;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            SectionSetupDto dto = new SectionSetupDto
            {


            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(SectionSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "SectionSetup", new { message = "Section Setup has been saved successfully." });
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
            SectionSetupDto dto = new SectionSetupDto();
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(SectionSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "SectionSetup", new { message = "Section Setup has been updated successfully." });
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
            var sectionSetup = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(sectionSetup);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(SectionSetup sectionSetup)
        {
            try
            {
                if (sectionSetup != null)
                {
                    await _service.Delete(sectionSetup.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "SectionSetup", new { messege = "Section Setup been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(sectionSetup);
        }
    }
}
