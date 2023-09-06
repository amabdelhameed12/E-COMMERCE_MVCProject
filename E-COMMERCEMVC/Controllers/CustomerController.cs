using E_COMMERCEMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCEMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogin _customerRepository;

        public CustomerController(ILogin customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // ///////////////////////////////
        public ActionResult Login()
        {
            return View();
        }

   
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (_customerRepository.Found(username, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }

        // /////////////////////////////////////
        public ActionResult ResetPassword()
        {
            return View();
        }

  
        [HttpPost]
        public ActionResult ResetPassword(string OldPassword, string Newpassword)
        {
            if (_customerRepository.Reset(OldPassword, Newpassword))
            {
                ViewBag.Success = "Password has been reset successfully";
                return View();
            }
            else
            {
                ViewBag.Error = "Invalid password";
                return View();
            }
        }
    }
}
