using FiboAddress.InfraStructure.Repository;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboSchool;
using FiboOffice.InfraStructure.Repository;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.InfraStructure.Service;
using FiboSchool.Src.Dto;
using FiboSchool.Src.ViewModel;
using FiboUser.InfraStructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Areas.School.Controllers
{
  
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentAssembler _studentAssembler;
        private readonly IProvienceRepository _provienceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ILocalLevelRepository _localLevelRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserBranchRepository _userBranchRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IClassSetupRepository _classSetupRepository;
        private readonly ISectionSetupRepository _sectionSetupRepository;
        public StudentController(IStudentService studentService
        , IStudentRepository studentRepository
            , IStudentAssembler studentAssembler
            , IProvienceRepository provienceRepository
            , IDistrictRepository districtRepository
            , ILocalLevelRepository localLevelRepository
            , UserManager<ApplicationUser> userManager
            , IUserBranchRepository userBranchRepository
            , IBranchRepository branchRepository
            , IFiscalYearRepository fiscalYearRepository
            , IClassSetupRepository classSetupRepository
            , ISectionSetupRepository sectionSetupRepository
            )
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
            _studentAssembler = studentAssembler;
            _provienceRepository = provienceRepository;
            _districtRepository = districtRepository;
            _localLevelRepository = localLevelRepository;
            _userBranchRepository = userBranchRepository;
            _userManager = userManager;
            _branchRepository = branchRepository;
            _fiscalYearRepository = fiscalYearRepository;
            _classSetupRepository = classSetupRepository;
            _sectionSetupRepository = sectionSetupRepository;
        }
        public async Task<IActionResult> Index(StudentViewModel vm, string message, string messege)
        {
            vm.Students = new List<Student>();
            var student = await _studentRepository.GetAllStudentAsync();

            vm.Students = student;

            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            StudentDto dto = new StudentDto
            {
                Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                Districts = await _districtRepository.GetAllDistrictAsync(),
                LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
                ClassSetUps = await _classSetupRepository.GetAllClassSetupAsync(),
                SectionSetups = await _sectionSetupRepository.GetAllSectionSetupAsync(),
            };
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(StudentDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var userBranches = await _userBranchRepository.GetAllUserBranchAsync();
                    var userBranch = userBranches.Where(x => x.UserId == user.Id).FirstOrDefault();

                    var fiscalYearList = await _fiscalYearRepository.GetAllFiscalYearAsync();
                    var _activeFiscalYear = fiscalYearList.Where(x => x.IsActive()).FirstOrDefault();


                    await _studentService.Insertasync(dto);
                    return RedirectToAction("Index", "Student", new { message = "Student has been saved successfully." });
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
            return View(dto);
        }

        [HttpGet()]
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {

            }
            var student = await _studentRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            StudentDto dto = new StudentDto()
            {
                LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
                Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                Districts = await _districtRepository.GetAllDistrictAsync(),
                Students = await _studentRepository.GetAllStudentAsync(),
                ClassSetUps = await _classSetupRepository.GetAllClassSetupAsync(),
                SectionSetups = await _sectionSetupRepository.GetAllSectionSetupAsync(),
            };

            _studentAssembler.copyFrom(dto, student);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(StudentDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Student", new { message = "Student has been updated successfully." });
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
            var student = await _studentRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(student);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Student student)
        {
            try
            {
                if (student != null)
                {
                    await _studentService.Delete(student.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Student", new { message = "Student has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {

            }
            return View(student);
        }
        [HttpGet()]
        public async Task<IActionResult> Profile()
        {
            return View();
        }
    }
}
