using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiboInfraStructure.Entity.FiboSchool;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.InfraStructure.Service;
using FiboSchool.Src.Dto;
using FiboSchool.Src.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Areas.School.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly IPerformanceService _service;
        private readonly IPerformanceRepository _repository;
        private readonly IPerformanceAssembler _assembler;
        private readonly IStudentRepository _studentrepository;
        private readonly IClassSetupRepository _classrepository;
        private readonly ISessionSetupRepository _sessionrepository;
        private readonly ITermRepository _termrepository;
        private readonly ISectionSetupRepository _sectionrepository;

        public PerformanceController(
            IPerformanceService service
            , IPerformanceRepository repository,
            IPerformanceAssembler assembler
            , IStudentRepository studentRepository
            , IClassSetupRepository classSetupRepository
            , ISessionSetupRepository sessionSetupRepository
            , ITermRepository termRepository
            , ISectionSetupRepository sectionSetupRepository)
        {
            _repository = repository;
            _service = service;
            _assembler = assembler;
            _studentrepository = studentRepository;
            _classrepository = classSetupRepository;
            _sessionrepository = sessionSetupRepository;
            _termrepository = termRepository;
            _sectionrepository = sectionSetupRepository;
        }
        public async Task<IActionResult> Index(PerformanceViewModel vm, string message, string messege)
        {
            vm.Performances = new List<Performance>();
            var performance = await _repository.GetAllPerformanceAsync();
            vm.Performances = performance;
            ViewBag.Message = message;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            PerformanceDto dto = new PerformanceDto
            {
                //ClassSetUps = await _classrepository.GetAllClassSetupAsync(),
                //Studentlist = await _studentrepository.GetAllStudentAsync(),
                //SessionSetUpList = await _sessionrepository.GetAllSessionSetupAsync(),
                //Terms = await _termrepository.GetAllTermAsync(),
                //SectionSetUpList = await _sectionrepository.GetAllSectionSetupAsync(),
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(PerformanceDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "Performance", new { message = "Performance has been saved successfully." });
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
            PerformanceDto dto = new PerformanceDto
            {
                //ClassSetUps = await _classrepository.GetAllClassSetupAsync(),
                //Studentlist = await _studentrepository.GetAllStudentAsync(),
                //SessionSetUpList = await _sessionrepository.GetAllSessionSetupAsync(),
                //Terms = await _termrepository.GetAllTermAsync(),
                //SectionSetUpList = await _sectionrepository.GetAllSectionSetupAsync(),
            };
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(PerformanceDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "Performance", new { message = "Performance has been saved successfully." });
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
            var performance = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(performance);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Performance performance)
        {
            try
            {
                if (performance != null)
                {
                    await _service.Delete(performance.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Performance", new { messege = "Performance been Delete successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(performance);
        }
    }
}
