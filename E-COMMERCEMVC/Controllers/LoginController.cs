using E_COMMERCEMVC.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using E_COMMERCEMVC.Models;
using NuGet.Protocol.Core.Types;

namespace E_COMMERCEMVC.Controllers
{
    public class LoginController : Controller
    {
        ILogin login;
        public LoginController(ILogin _login) 
        { 
            login = _login;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email ,string password )
        {
            var a=login.Found(Email , password);
            if (a)
            {
                Customer customermodel = login.find(Email, password);
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim("Id", customermodel.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, customermodel.FirstName.ToString()));
                //identity.AddClaim(new Claim(ClaimTypes.Role, customermodel.Role.ToString()));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");

            }

            return View();


        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index" , "Home");
        }

        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewUser(Customer customer)
        {

            if (customer!=null)
            {
                login.Insert(customer);
                return RedirectToAction("Index");
            }
          
            return View("NewUser", customer);
        }
       
      
          
      



    }
    
}
