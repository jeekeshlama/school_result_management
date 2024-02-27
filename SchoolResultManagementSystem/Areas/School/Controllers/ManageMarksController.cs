using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Common;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FiboInfraStructure;
namespace SchoolManagementSystem.Areas.School.Controllers
{

    public class ManageMarksController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserBranchRepository _userBranchRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IManageMarksRepository _manageMarksRepository;
        private readonly IManageMarksService _manageMarksService;
        private readonly IManageMarksAssembler _manageMarksAssembler;
        private readonly IStudentRepository _studentRepository;
        private readonly ISessionSetupRepository _sessionSetupRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IClassSetupRepository _classSetupRepository;
        private readonly IManageMarksDetailRepository _detailRepo;
        private readonly ISectionSetupRepository _sectionSetupRepository;
        private readonly ITermRepository _termRepository;
        private readonly IPerformanceService _service;
        private readonly IPerformanceRepository _repository;
        private readonly IPerformanceAssembler _assembler;
        public ManageMarksController(
            UserManager<ApplicationUser> userManager
            , IUserBranchRepository userBranchRepository
            , IBranchRepository branchRepository
            , IFiscalYearRepository fiscalYearRepository
            , IManageMarksRepository manageMarksRepository
            , IManageMarksService manageMarksService
            , IManageMarksAssembler manageMarksAssembler
            , IStudentRepository studentRepository
            , ISessionSetupRepository sessionSetupRepository
            , ISubjectRepository subjectRepository
            , IClassSetupRepository classSetupRepository
            , IManageMarksDetailRepository detailRepo
            , ISectionSetupRepository sectionSetupRepository
            , ITermRepository termRepository
            , IPerformanceService service
            , IPerformanceRepository repository
            , IPerformanceAssembler assembler
            )
        {
            _userBranchRepository = userBranchRepository;
            _userManager = userManager;
            _branchRepository = branchRepository;
            _fiscalYearRepository = fiscalYearRepository;
            _manageMarksRepository = manageMarksRepository;
            _manageMarksService = manageMarksService;
            _manageMarksAssembler = manageMarksAssembler;
            _studentRepository = studentRepository;
            _sessionSetupRepository = sessionSetupRepository;
            _subjectRepository = subjectRepository;
            _classSetupRepository = classSetupRepository;
            _detailRepo = detailRepo;
            _sectionSetupRepository = sectionSetupRepository;
            _termRepository = termRepository;
            _repository = repository;
            _service = service;
            _assembler = assembler;
        }
        public async Task<IActionResult> Index(ManageMarksViewModel vm, string message)
        {
            vm.ManageMarksList = new List<ManageMarks>();
            var marks = await _manageMarksRepository.GetAllMarksAsync();

            vm.ManageMarksList = marks;

            ViewBag.Message = message;
            return View(vm);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ManageMarksDto dto = new ManageMarksDto
            {
                Students = await _studentRepository.GetAllStudentAsync(),
                ClassSetUps = await _classSetupRepository.GetAllClassSetupAsync(),
                SessionSetups = await _sessionSetupRepository.GetAllSessionSetupAsync(),
                Subjects = await _subjectRepository.GetAllSubjectAsync(),
                SectionSetups = await _sectionSetupRepository.GetAllSectionSetupAsync(),
                Terms = await _termRepository.GetAllTermAsync()
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ManageMarksDto dto)
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


                    dto.FiscalYearId = _activeFiscalYear.Id;
                    await _manageMarksService.Insertasync(dto);
                    return RedirectToAction("Index", "ManageMarks", new { message = "Marks has been saved successfully." });
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
            var marks = await _manageMarksRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            ManageMarksDto dto = new ManageMarksDto()
            {
                Students = await _studentRepository.GetAllStudentAsync(),
                ClassSetUps = await _classSetupRepository.GetAllClassSetupAsync(),
                SessionSetups = await _sessionSetupRepository.GetAllSessionSetupAsync(),
                Subjects = await _subjectRepository.GetAllSubjectAsync(),
                SectionSetups = await _sectionSetupRepository.GetAllSectionSetupAsync(),
                Terms = await _termRepository.GetAllTermAsync()
            };
            _manageMarksAssembler.copyFrom(dto, marks);
            var marksDetailList = await _detailRepo.GetAllMarksDetailAsync();
            var marksDetail = marksDetailList.Where(x => x.ManageMarksId == marks.Id).ToList();
            dto.ManageMarksDetails = marksDetail;

            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ManageMarksDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _manageMarksService.UpdateAsync(dto);
                    return RedirectToAction("Index", "ManageMarks", new { message = "Marks has been saved successfully." });
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
            var marks = await _manageMarksRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(marks);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(ManageMarks marks)
        {
            try
            {
                if (marks != null)
                {
                    await _manageMarksService.Delete(marks.Id).ConfigureAwait(true);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

            }
            return View(marks);
        }
        [HttpGet()]
        public async Task<IActionResult> ViewMarks(long? id)
        {
            ManageMarksViewModel vm = new ManageMarksViewModel();

            var marks = await _manageMarksRepository.GetByIdAsync(id.Value) ?? throw new Exception();

            var detailList = await _detailRepo.GetAllMarksDetailAsync();
            var _detail = detailList.Where(x => x.ManageMarksId == id).ToList();
            vm.ManageMarks = marks;
            vm.DetailList = _detail;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> StudentManageMarks(ManageMarksViewModel vm)
        {

            var marks = await _manageMarksRepository.GetAllMarksAsync();

            var detailList = await _detailRepo.GetAllMarksDetailAsync();
            vm.ManageMarksList = marks;
            vm.DetailList = detailList;
            vm.ClassSetUps = await _classSetupRepository.GetAllClassSetupAsync();
            vm.SectionSetups = await _sectionSetupRepository.GetAllSectionSetupAsync();
            vm.StudentList = await _studentRepository.GetAllStudentAsync();
            vm.Terms = await _termRepository.GetAllTermAsync();

            if (vm.ClassId > 0)
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.ClassSetupId == vm.ClassId).ToList();
                vm.StudentList = vm.StudentList.Where(x => x.ClassSetupId == vm.ClassId).ToList();
            }
            else
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.ClassSetupId == vm.ClassSetUps.FirstOrDefault().Id).ToList();
                vm.StudentList = vm.StudentList.Where(x => x.ClassSetupId == vm.ClassSetUps.FirstOrDefault().Id).ToList();
                vm.ClassId = vm.ClassSetUps.FirstOrDefault().Id;
            }
            if (vm.SectionId > 0)
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.SectionSetupId == vm.SectionId).ToList();
                vm.StudentList = vm.StudentList.Where(x => x.SectionSetupId == vm.SectionId).ToList();
            }
            else
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.SectionSetupId == vm.SectionSetups.FirstOrDefault().Id).ToList();
                vm.StudentList = vm.StudentList.Where(x => x.SectionSetupId == vm.SectionSetups.FirstOrDefault().Id).ToList();
                vm.SectionId = vm.SectionSetups.FirstOrDefault().Id;
            }
            if (vm.TermId > 0)
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.TermId == vm.TermId).ToList();
            }
            else
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.TermId == vm.Terms.FirstOrDefault().Id).ToList();
                vm.TermId = vm.Terms.FirstOrDefault().Id;
            }
            if (vm.ClassId > 0)
            {
                List<Subject> list = new List<Subject>();
                var subjectList = await _subjectRepository.GetAllSubjectAsync();
                var subject = subjectList.Where(x => x.ClassId == vm.ClassId).ToList();
                foreach (var item in subject)
                {
                    list.Add(new Subject { Id = item.Id, SubjectName = item.SubjectName });
                }
                vm.SubjectList = list;
            }
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Marks(long? id, long? classId, long? sectionId, long? termId)
        {
            PerformanceDto dto = new PerformanceDto
            {
            };
            var marks = await _manageMarksRepository.GetAllMarksAsync();
            var detailList = await _detailRepo.GetAllMarksDetailAsync();
            dto.StudentList = await _studentRepository.GetAllStudentAsync();
            dto.ManageMarksList = marks;
            dto.DetailList = detailList;
            dto.DetailList = dto.DetailList.Where(x => x.StudentId == id).ToList();
            dto.StudentList = dto.StudentList.Where(x => x.Id == id).ToList();
            dto.AllClassStudentList = await _studentRepository.GetAllStudentAsync();
            dto.AllClassStudentList = dto.AllClassStudentList.Where(x => x.ClassSetupId == classId && x.SectionSetupId == sectionId).ToList();
            dto.AllDetailList = detailList;
            if (classId > 0)
            {
                dto.ManageMarksList = dto.ManageMarksList.Where(x => x.ClassSetupId == classId).ToList();
            }
            if (sectionId > 0)
            {
                dto.ManageMarksList = dto.ManageMarksList.Where(x => x.SectionSetupId == sectionId).ToList();
            }
            if (termId > 0)
            {
                dto.ManageMarksList = dto.ManageMarksList.Where(x => x.TermId == termId).ToList();
            }
            if (classId > 0)
            {
                List<Subject> list = new List<Subject>();
                var subjectList = await _subjectRepository.GetAllSubjectAsync();
                var subject = subjectList.Where(x => x.ClassId == classId).ToList();
                foreach (var item in subject)
                {
                    list.Add(new Subject { Id = item.Id, SubjectName = item.SubjectName });
                }
                dto.SubjectList = list;
            }
            ViewBag.ClassId = classId;
            ViewBag.SectionId = sectionId;
            ViewBag.TermId = termId;
            return View(dto);
        }
        [HttpPost()]
        public async Task<IActionResult> Marks(PerformanceDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var userBranches = await _userBranchRepository.GetAllUserBranchAsync();
                    var userBranch = userBranches.Where(x => x.UserId == user.Id).FirstOrDefault();

                    await _service.Insertasync(dto);
                    return RedirectToAction("Result", "ManageMarks", new { id = dto.StudentId, classId = dto.ClassId, sectionId = dto.SectionSetupId, termId = dto.TermId, message = "Result has been saved successfully." });
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
        public async Task<IActionResult> UpdateMarks(long? id, long? classId, long? sectionId, long? termId)
        {
            var performanceList = await _repository.GetAllPerformanceAsync();
            var performance = performanceList.Where(x => x.StudentId == id && x.ClassId == classId && x.TermId == termId && x.SectionSetupId == sectionId).FirstOrDefault();
            PerformanceDto dto = new PerformanceDto
            {
                Id = performance.Id,
                CreatedBy = performance.CreatedBy,
                CreatedDate = performance.CreatedDate,
                Division = performance.Division,
                TotalGrade = performance.TotalGrade,
                Percentage = performance.Percentage,
                Discipline = performance.Discipline,
                Position = performance.Position,
                StudentId = performance.StudentId,
                SessionSetupId = performance.SessionSetupId,
                TermId = performance.TermId,
                ClassId = performance.ClassId,
                SectionSetupId = performance.SectionSetupId,
                BranchId = performance.BranchId
            };

            var marks = await _manageMarksRepository.GetAllMarksAsync();
            var detailList = await _detailRepo.GetAllMarksDetailAsync();
            dto.StudentList = await _studentRepository.GetAllStudentAsync();
            dto.ManageMarksList = marks;
            dto.DetailList = detailList;
            dto.DetailList = dto.DetailList.Where(x => x.StudentId == id).ToList();
            dto.StudentList = dto.StudentList.Where(x => x.Id == id).ToList();

            if (classId > 0)
            {
                dto.ManageMarksList = dto.ManageMarksList.Where(x => x.ClassSetupId == classId).ToList();
            }
            if (sectionId > 0)
            {
                dto.ManageMarksList = dto.ManageMarksList.Where(x => x.SectionSetupId == sectionId).ToList();
            }
            if (termId > 0)
            {
                dto.ManageMarksList = dto.ManageMarksList.Where(x => x.TermId == termId).ToList();
            }
            if (classId > 0)
            {
                List<Subject> list = new List<Subject>();
                var subjectList = await _subjectRepository.GetAllSubjectAsync();
                var subject = subjectList.Where(x => x.ClassId == classId).ToList();
                foreach (var item in subject)
                {
                    list.Add(new Subject { Id = item.Id, SubjectName = item.SubjectName });
                }
                dto.SubjectList = list;
            }
            return View(dto);
        }
        [HttpPost()]
        public async Task<IActionResult> UpdateMarks(PerformanceDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Result", "ManageMarks", new { id = dto.StudentId, classId = dto.ClassId, sectionId = dto.SectionSetupId, termId = dto.TermId, message = "Result has been saved successfully." });
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
        public async Task<IActionResult> Result(long? id, long? classId, long? sectionId, long? termId, string message)
        {
            ResultViewModel vm = new ResultViewModel
            {
            };
            var marks = await _manageMarksRepository.GetAllMarksAsync();
            var detailList = await _detailRepo.GetAllMarksDetailAsync();
            vm.StudentList = await _studentRepository.GetAllStudentAsync();
            var performance = await _repository.GetAllPerformanceAsync();
            vm.Performance = performance.Where(x => x.StudentId == id && x.ClassId == classId && x.SectionSetupId == sectionId && x.TermId == termId).FirstOrDefault();
            vm.ManageMarksList = marks;
            vm.DetailList = detailList;
            vm.DetailList = vm.DetailList.Where(x => x.StudentId == id).ToList();
            vm.StudentList = vm.StudentList.Where(x => x.Id == id).ToList();
            if (classId > 0)
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.ClassSetupId == classId).ToList();
            }
            if (sectionId > 0)
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.SectionSetupId == sectionId).ToList();
            }
            if (termId > 0)
            {
                vm.ManageMarksList = vm.ManageMarksList.Where(x => x.TermId == termId).ToList();
            }
            if (classId > 0)
            {
                List<Subject> list = new List<Subject>();
                var subjectList = await _subjectRepository.GetAllSubjectAsync();
                var subject = subjectList.Where(x => x.ClassId == classId).ToList();
                foreach (var item in subject)
                {
                    list.Add(new Subject { Id = item.Id, SubjectName = item.SubjectName });
                }
                vm.SubjectList = list;
            }
            return View(vm);
        }
       
        public async Task<JsonResult> getManageMarks(long id, long sectionId, [FromServices] ICompositeViewEngine viewEngine)
{
    var _result = new ResponseData();

    try
    {
        var list = await _studentRepository.GetAllStudentAsync();

        if (id > 0)
        {
            list = list.Where(x => x.ClassSetupId == id).ToList();
        }
        if (sectionId > 0)
        {
            list = list.Where(x => x.SectionSetupId == sectionId).ToList();
        }

        // Check if students already exist in the database

        // Filter out existing students

        if (list.Count() > 0)
        {
            ManageMarksDto dto = new ManageMarksDto()
            {
                Students = list,
            };
            string dtResult = await RenderPartialView("_manageMarksPartialView", viewEngine, dto);
            _result.Success = true;
            _result.Message = dtResult;
        }
        else
        {
            _result.Message = "Data Not Found.";
        }
    }
    catch (Exception ex)
    {
        _result.Success = false;
        _result.Message = ex.Message;
    }

    return Json(_result);
}

        protected async Task<string> RenderPartialView(string viewName, ICompositeViewEngine _viewEngine, object model = null)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = _viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }


        public async Task<JsonResult> LoadSubject(long Id)
        {
            var subjectList = await _subjectRepository.GetAllSubjectAsync();
            var subject = subjectList.Where(x => x.ClassId == Id).ToList();
            List<Subject> list = new List<Subject>();
            foreach (var item in subject)
            {
                list.Add(new Subject { Id = (long)item.Id, SubjectName = item.SubjectName });
            }
            return Json(list);
        }
       

    }
}
