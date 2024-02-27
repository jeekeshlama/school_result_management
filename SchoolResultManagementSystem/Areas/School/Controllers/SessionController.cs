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
    public class SessionController : Controller
    {
        private readonly ISessionSetupService _service;
        private readonly ISessionSetupRepository _repository;
        private readonly ISessionSetupAssembler _assembler;
        public SessionController(ISessionSetupService service, ISessionSetupRepository repository, ISessionSetupAssembler assembler)
        {
            _repository = repository;
            _service = service;
            _assembler = assembler;
        }
        public async Task<IActionResult> Index(SessionSetupViewModel vm, string message, string messege)
        {
            vm.SessionSetups = new List<SessionSetup>();
            var school = await _repository.GetAllSessionSetupAsync();
            vm.SessionSetups = school;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            SessionSetupDto dto = new SessionSetupDto
            {


            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(SessionSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "Session", new { message = "Session  has been saved successfully." });
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
            SessionSetupDto dto = new SessionSetupDto();
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(SessionSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "Session", new { message = "Session  has been updated successfully." });
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
        public async Task<IActionResult> ToggleStatus(long id)
        {
            var sessionSetup = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(sessionSetup);
        }

        [HttpPost()]
        public async Task<IActionResult> ToggleStatus(SessionSetup sessionSetup)
        {
            try
            {
                if (sessionSetup != null)
                {
                    sessionSetup = await _repository.GetByIdAsync(sessionSetup.Id) ?? throw new Exception();
                    await _service.ToggleStatus(sessionSetup).ConfigureAwait(true);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View(sessionSetup);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var session = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(session);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(SessionSetup sessionSetup)
        {
            try
            {
                if (sessionSetup != null)
                {
                    await _service.Delete(sessionSetup.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Session", new { messege = "Session has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(sessionSetup);
        }
    }
}
