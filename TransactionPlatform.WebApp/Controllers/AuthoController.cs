using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.WebApp.Data;

namespace TransactionPlatform.WebApp.Controllers
{
    public class AuthoController : Controller
    {
        private readonly IAuthRepository authRep;

        public AuthoController(IAuthRepository authRep)
        {
            this.authRep = authRep;
        }
        public IActionResult Register(AuthoUserDto authUser)
        {
            if (!ModelState.IsValid) { return null; }

            if (  !authRep.UserExist(authUser.UsersAccess.Username).Result)
            {
                authRep.Register(authUser.User, authUser.Password);
                return  RedirectToAction("Index", "DashBoard");

            }
            return null;
            
        }   
        public IActionResult LogIn(AuthoUserDto authUser)
        {
            if (!ModelState.IsValid) { return null; }
            if (authRep.Login(authUser.UsersAccess.Username, authUser.Password).Result != null)
            {

                return RedirectToAction("Index", "DashBoard");
            }
            return null;
        }
    }
}