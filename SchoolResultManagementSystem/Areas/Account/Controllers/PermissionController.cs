using FiboInfraStructure.Data;
using FiboUser.Constants;
using FiboUser.Seeds;
using FiboUser.Src.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Areas.Account.Controllers
{
    public class PermissionController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string roleId, string message)
        {
            var model = new PermissionViewModel();
            var allPermission = new List<RoleClaimsViewModel>();
            allPermission.GetPermissions(typeof(Permissions.ApplicationPermission), roleId);
            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;
            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimsValues = allPermission.Select(a => a.Value).ToList();
            var rolesClaimsValue=claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimsValues.Intersect(rolesClaimsValue).ToList();
            foreach (var permission in allPermission)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            model.RoleClaims = allPermission;
            if (message != null)
            {
                ViewBag.Message = message + "for" + role.Name + " Has Been Updated Successfully.";
            }
            return View(model);
        }
        public async Task<IActionResult> Update(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddPermissionClaims(role, claim.Value);
            }
            return RedirectToAction("Login", "Account", new { roleId = model.RoleId, Messege = "Role Updated Successfully." });
        }

        public async Task<IActionResult> UpdateUserRole(PermissionViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            var claims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in claims)
            {
                await _userManager.RemoveClaimAsync(user, claim);
            }
            var selectedClaims = model.UserClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _userManager.AddPermissionClaimsForUser(user, claim.Value);
            }
            return RedirectToAction("Index", new { roleId = model.UserId, Messege = "Permissions" });
        }
    }
}
