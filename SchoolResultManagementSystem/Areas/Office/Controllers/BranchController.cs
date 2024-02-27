using FiboAddress.InfraStructure.Repository;
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
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IBranchRepository _repo;
        private readonly IBranchAssembler _assembler;
        private readonly IDistrictRepository _districtRepository;
        private readonly IProvienceRepository _provienceRepository;
        private readonly ILocalLevelRepository _localLevelRepository;
        private readonly IOfficeRepository _officeRepository;

        public BranchController(IBranchService branchService, IBranchRepository repo,
            IProvienceRepository provienceRepository, IBranchAssembler assembler,
            IDistrictRepository districtRepository,
            ILocalLevelRepository localLevelRepository, IOfficeRepository officeRepository)
        {
            _repo = repo;
            _assembler = assembler;
            _branchService = branchService;
            _localLevelRepository = localLevelRepository;
            _districtRepository = districtRepository;
            _provienceRepository = provienceRepository;
            _officeRepository = officeRepository;
        }
        public async Task<IActionResult> Index(BranchViewModel vm, string message, string messege)
        {
            vm.Branches = new List<Branch>();
            var branch = await _repo.GetAllBranchAsync();
            vm.Branches = branch;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            BranchDto dto = new BranchDto()
            {
                LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
                Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                Districts = await _districtRepository.GetAllDistrictAsync(),
                Offices = await _officeRepository.GetAllOfficeAsync()

            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(BranchDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _branchService.InsertAsync(dto);
                    return RedirectToAction("Index", "Branch", new { message = "Branch has been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalide Data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact System Administrator.";
            }
            return View(dto);
        }

        [HttpGet()]
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {

            }
            var branch = await _repo.GetByIdAsync(id.Value) ?? throw new Exception();
            BranchDto dto = new BranchDto()
            {
                LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
                Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                Districts = await _districtRepository.GetAllDistrictAsync(),
                Offices = await _officeRepository.GetAllOfficeAsync()
            };

            _assembler.copyFrom(dto, branch);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(BranchDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _branchService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Branch", new { message = "Branch has been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalide Data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact System Administrator.";
            }
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var branch = await _repo.GetByIdAsync(id) ?? throw new Exception();
            return View(branch);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Branch branch)
        {
            try
            {
                if (branch != null)
                {
                    await _branchService.Delete(branch.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Branch", new { message = "Branch has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View(branch);
        }
    }
}
