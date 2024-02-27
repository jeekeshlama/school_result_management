using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiboAddress.InfraStructure.Assembler;
using FiboAddress.InfraStructure.Repository;
using FiboAddress.InfraStructure.Service;
using FiboAddress.Src.Dto;
using FiboAddress.Src.ViewModel;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Entity.FiboAddress;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Areas.Address.Controllers
{
    public class ProvienceController : Controller
    {
        private readonly IProvienceService _provienceService;
        private readonly IProvienceRepository _provienceRepository;
        private readonly IProvienceAssembler _provienceAssembler;

        public ProvienceController(IProvienceService provienceService, IProvienceRepository provienceRepository, IProvienceAssembler provienceAssembler )
        {
            _provienceRepository = provienceRepository;
            _provienceAssembler = provienceAssembler;
            _provienceService = provienceService;
        }
        public async Task<IActionResult> Index(ProvienceViewModel vm, string message,string messege)
        {
            vm.Proviences = new List<Provience>();
            var provience = await _provienceRepository.GetAllProvienceAsync();
            vm.Proviences = provience;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ProvienceDto dto = new ProvienceDto
            {

            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ProvienceDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _provienceService.Insertasync(dto);
                    return RedirectToAction("Index", "Provience", new { message = "Provience has been saved successfully." });
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
            var entity = await _provienceRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            ProvienceDto dto = new ProvienceDto();
            _provienceAssembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ProvienceDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _provienceService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Provience", new { message = "Provience has been saved successfully." });
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
            var provience = await _provienceRepository.GetByIdAsync(id)?? throw new Exception();
            return View(provience);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Provience provience)
        {
            try
            {
                if (provience != null)
                {
                    await _provienceService.Delete(provience.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Provience", new { messege = "Provience been Delete successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(provience);
        }
    }
}
