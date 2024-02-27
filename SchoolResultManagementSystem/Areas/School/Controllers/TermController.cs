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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Areas.School.Controllers
{
   
    public class TermController : Controller
    {
        private readonly ITermService _service;
        private readonly ITermRepository _repository;
        private readonly ITermAssembler _assembler;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserBranchRepository _userBranchRepository;
        private readonly IBranchRepository _branchRepository;
        public TermController(ITermService service, ITermRepository repository, ITermAssembler assembler
            , UserManager<ApplicationUser> userManager
            , IUserBranchRepository userBranchRepository
            , IBranchRepository branchRepository)
        {
            _repository = repository;
            _service = service;
            _assembler = assembler;
            _userBranchRepository = userBranchRepository;
            _userManager = userManager;
            _branchRepository = branchRepository;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(TermViewModel vm, string message, string messege)
        {
            vm.Terms = new List<Term>();
            var term = await _repository.GetAllTermAsync();
            vm.Terms = term;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(TermDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var userBranches = await _userBranchRepository.GetAllUserBranchAsync();
                    var userBranch = userBranches.Where(x => x.UserId == user.Id).FirstOrDefault();
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "Term", new { message = "Term has been saved successfully." });
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
            TermDto dto = new TermDto();
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(TermDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "Term", new { message = "Term has been updated successfully." });
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
            var term = await _repository.GetByIdAsync(id) ?? throw new Exception();
            return View(term);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Term term)
        {
            try
            {
                if (term != null)
                {
                    await _service.Delete(term.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Term", new { messege = "Term has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(term);
        }
    }
}
