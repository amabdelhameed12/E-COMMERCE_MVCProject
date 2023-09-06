using E_COMMERCEMVC.Models;
using E_COMMERCEMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_COMMERCEMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IProduct iproductRepo;
        public HomeController(ILogger<HomeController> logger , IProduct product)
        {
            _logger = logger;
            iproductRepo = product;
        }

    public IActionResult Index()
        {
            return View(iproductRepo.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}