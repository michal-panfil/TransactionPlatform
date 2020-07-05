using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Register(IFormCollection form)
        {
            var authUser = new AuthoUserDto
            {
                User = new User()
                {
                    FirstName = form["FirstName"],
                    LastName = form["LastName"],
                    Email = form["Email"],
                    Company = form["Company"],
                },
                UsersAccess = new UsersAccess()
                {
                    Username = form["Email"]
                },
                Password = form["Password"]
            };
            
            if (  !authRep.UserExist(authUser.User.Email).Result)
            {
                authRep.Register(authUser);
                return  RedirectToAction("Index", "DashBoard");

            }            
            return null;
            
        }   
        public IActionResult LogIn(AuthoUserDto formData)
        {
            if (!ModelState.IsValid) { return null; }

            if (authRep.Login(formData.UsersAccess.Username, formData.Password).Result != null)
            {

                return RedirectToAction("Index", "DashBoard");
            }
            return null;
        }
    }
}