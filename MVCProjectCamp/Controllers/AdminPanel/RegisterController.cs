using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class RegisterController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()),new WriterManager(new EfWriterDal()));
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(LoginDto loginDto)
        {
            authService.AdminRegister(loginDto.AdminUserName, loginDto.AdminMail, loginDto.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
        }
    }
}