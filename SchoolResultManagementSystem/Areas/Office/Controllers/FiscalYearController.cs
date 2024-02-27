using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.InfraStructure.Assembler;
using FiboOffice.InfraStructure.Repository;
using FiboOffice.InfraStructure.Service;
using FiboOffice.Src.Dto;
using FiboOffice.Src.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Areas.Offices.Controllers
{
    public class FiscalYearController : Controller
    {
        private readonly IFiscalYearRepository _repo;
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IFiscalYearAssembler _assembler;
        public FiscalYearController(IFiscalYearRepository repo, IFiscalYearService fiscalYearService, IFiscalYearAssembler assembler)
        {
            _repo = repo;
            _fiscalYearService = fiscalYearService;
            _assembler = assembler;
        }
        public async Task<IActionResult> Index(FiscalYearViewModel vm, string message, string messege)
        {
            vm.FiscalYears = new List<FiscalYear>();
            var fy = await _repo.GetAllFiscalYearAsync();
            vm.FiscalYears = fy;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            FiscalYearDto dto = new FiscalYearDto
            {
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(FiscalYearDto dto)
        {
            try
            {
                var fiscalYears = await _repo.GetAllFiscalYearAsync();
                if (ModelState.IsValid)
                {
                    string[] startMiti = dto.StartDate.Split('-');
                    string[] EndMiti = dto.EndDate.Split('-');
                    dto.FiscalYearName = startMiti[0] + "/" + EndMiti[0];
                    dto.FiscalYearCode = (fiscalYears.Count + 1).ToString("00");
                    await _fiscalYearService.Insertasync(dto);
                    return RedirectToAction("Index", "FiscalYear", new { message = "Fiscal Year has been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please Contact Administrator.";
            }
            return View(dto);
        }

        [HttpGet()]
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {
                throw new Exception();
            }
            var fy = await _repo.GetByIdAsync(id.Value) ?? throw new Exception();
            FiscalYearDto dto = new FiscalYearDto(); 
            _assembler.copyFrom(dto, fy);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(FiscalYearDto dto)
        {
            try
            {
                var fiscalYears = await _repo.GetAllFiscalYearAsync();
                if (ModelState.IsValid)
                {
                    string[] startMiti = dto.StartDate.Split('-');
                    string[] EndMiti = dto.EndDate.Split('-');
                    dto.FiscalYearName = startMiti[0] + "/" + EndMiti[0];
                    await _fiscalYearService.UpdateAsync(dto);
                    return RedirectToAction("Index", "FiscalYear", new { message = "Fiscal Year has been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please Contact Administrator.";
            }
            return View();
        }

        public async Task<IActionResult> ToggleStatus(long id)
        {
            var fy = await _repo.GetByIdAsync(id) ?? throw new Exception();
            return View(fy);
        }

        [HttpPost()]
        public async Task<IActionResult> ToggleStatus(FiscalYear fy)
        {
            try
            {
                if (fy != null)
                {
                    fy = await _repo.GetByIdAsync(fy.Id) ?? throw new Exception();
                    await _fiscalYearService.ToggleStatus(fy).ConfigureAwait(true);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View(fy);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var fy = await _repo.GetByIdAsync(id) ?? throw new Exception();
            return View(fy);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(FiscalYear fy)
        {
            try
            {
                if (fy != null)
                {
                    await _fiscalYearService.Delete(fy.Id).ConfigureAwait(true);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View(fy);
        }
    }
}
