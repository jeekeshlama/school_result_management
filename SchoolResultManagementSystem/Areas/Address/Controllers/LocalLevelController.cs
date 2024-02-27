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
    public class LocalLevelController : Controller
    {
        private readonly ILocalLevelService _localLevelService;
        private readonly ILocalLevelRepository _localLevelRepository;
        private readonly ILocalLevelAssembler _localLevelAssembler;
        private readonly IDistrictRepository _districtRepository;
        public LocalLevelController(ILocalLevelService localLevelService, ILocalLevelRepository localLevelRepository , ILocalLevelAssembler localLevelAssembler, IDistrictRepository districtRepository )
        {
            _localLevelService = localLevelService;
            _localLevelRepository = localLevelRepository;
            _localLevelAssembler = localLevelAssembler;
            _districtRepository = districtRepository;
        }
        public async Task<IActionResult> Index(LocalLevelViewModel vm, string message)
        {
            vm.localLevels = new List<LocalLevel>();
            var locallevel = await _localLevelRepository.GetAllLocalLevelAsync();
            vm.localLevels = locallevel;
            ViewBag.Message = message;
            return View(vm);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            LocalLevelDto localLevelDto = new LocalLevelDto

            {
                Districts = await _districtRepository.GetAllDistrictAsync(),
            };
            return View(localLevelDto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(LocalLevelDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _localLevelService.Insertasync(dto);
                    return RedirectToAction("Index", "LocalLevel", new { message = "Local Level has been saved successfully." });
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
            var entity = await _localLevelRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            LocalLevelDto dto = new LocalLevelDto
            {
                Districts =await _districtRepository.GetAllDistrictAsync()
            };
            _localLevelAssembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(LocalLevelDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _localLevelService.UpdateAsync(dto);
                    return RedirectToAction("Index", "LocalLevel", new { message = "Local Level has been Updated successfully." });
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
            var district = await _localLevelRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(district);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(LocalLevel localLevel)
        {
            try
            {
                if (localLevel != null)
                {
                    await _localLevelService.Delete(localLevel.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "LocalLevel", new { message = "Local Level has been Deleted successfully." });
                }
            }
            catch (Exception ex)
            {

            }
            return View(localLevel);
        }
    }
}