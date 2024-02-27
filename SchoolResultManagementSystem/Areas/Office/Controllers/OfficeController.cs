using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiboAddress.InfraStructure.Repository;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.InfraStructure.Assembler;
using FiboOffice.InfraStructure.Repository;
using FiboOffice.InfraStructure.Service;
using FiboOffice.Src.Dto;
using FiboOffice.Src.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Areas.Offices.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IOfficeService _officeService;
        private readonly IOfficeRepository _officeRepository;
        private readonly IOfficeAssembler _officeAssembler;
        private readonly IProvienceRepository _provienceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ILocalLevelRepository _localLevelRepository;
        private readonly UserManager<ApplicationUser> _userManager;
       
        public OfficeController(IOfficeService officeService
        , IOfficeRepository officeRepository
            , IOfficeAssembler officeAssembler
            , IProvienceRepository provienceRepository
            , IDistrictRepository districtRepository
            , ILocalLevelRepository localLevelRepository
            , UserManager<ApplicationUser> userManager
          
            )
        {
            _officeService = officeService;
            _officeRepository = officeRepository;
            _officeAssembler = officeAssembler;
            _provienceRepository = provienceRepository;
            _districtRepository = districtRepository;
            _localLevelRepository = localLevelRepository;
           
            _userManager = userManager;
          
        }
        public async Task<IActionResult> Index(OfficeViewModel vm, string message,string messege)
        {
            vm.Offices = new List<Office>();
            var offices = await _officeRepository.GetAllOfficeAsync();
            //var user = await _userManager.GetUserAsync(User);
            //var userBranches = await _userBranchRepository.GetAllUserBranchAsync();
            //var userBranch = userBranches.Where(x => x.UserId == user.Id).FirstOrDefault();
            //var branchList = await _branchRepository.GetAllBranchAsync();
            //var branchHeadOffice = branchList.Where(x => x.Name.ToLower() == "kenishbranch").FirstOrDefault();

            //var fiscalYearList = await _fiscalYearRepository.GetAllFiscalYearAsync();
            //var _activeFiscalYear = fiscalYearList.Where(x => x.IsActive()).FirstOrDefault();
            //if (userBranch.BranchId != branchHeadOffice.Id)
            //{
            //    vm.Offices = vm.Offices.Where(x => x.BranchId == userBranch.BranchId).ToList();
            //}
            vm.Offices = offices;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            OfficeDto dto = new OfficeDto
            {
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(OfficeDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _officeService.InsertAsync(dto);
                    return RedirectToAction("Index", "Office", new { message = "Office been saved successfully." });
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
            var office = await _officeRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            OfficeDto dto = new OfficeDto()
            {
                Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                Districts = await _districtRepository.GetAllDistrictAsync(),
                LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
            };
            _officeAssembler.copyFrom(dto, office);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(OfficeDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _officeService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Office", new { message = "Office has been updated successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid Data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var office = await _officeRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(office);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Office office)
        {
            try
            {
                if (office != null)
                {
                    await _officeService.Delete(office.Id).ConfigureAwait(true);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

            }
            return View(office);
        }

    }
}
