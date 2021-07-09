using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers.AdminPanel
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()));
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        public ActionResult Index()
        {
            var adminvalues = adminManager.GetList();
            return View(adminvalues);
        }

        public ActionResult AddAdmin()
        {
            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.RoleName,
                                                       Value=x.RoleId.ToString()
                                                   }).ToList();
            ViewBag.valueAdminRole = adminRoleValue;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(LoginDto loginDto)
        {
            authService.AdminRegister(loginDto.AdminUserName, loginDto.AdminMail, loginDto.AdminPassword, loginDto.AdminRoleId);
            return RedirectToAction("Index");
        }


        public ActionResult UpdateAdminRole(int id)
        {
            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.RoleName,
                                                       Value=x.RoleId.ToString()
                                                   }).ToList();

            ViewBag.valueAdminRole = adminRoleValue;
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult UpdateAdminRole(Admin admin)
        {
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var adminValue = adminManager.GetById(id);

            if (adminValue.AdminStatus)
            {
                adminValue.AdminStatus = false;
            }
            else
            {
                adminValue.AdminStatus = true;
            }
            adminManager.Delete(adminValue);
            return RedirectToAction("Index");
        }
    }
}