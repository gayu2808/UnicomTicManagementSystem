using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Controllers
{

        public class LoginController : ControllerBase
        {

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            private IActionResult View()
            {
                throw new NotImplementedException();
            }

            [HttpPost]
            public IActionResult Login(string username, string password)
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                   // object ViewBag = null;
                   // ViewBag.ErrorMessage = "Username and password are required";
                    return View();
                }

               /* if (username == "admin" && password == "password123")
                {*/
                    return RedirectToAction("Index", "Home");  
               /* }
                else
                {
                    ViewBag.Errormessage = "Invalid username or password.";
                    return View();
                }*/
            }
        }
}

