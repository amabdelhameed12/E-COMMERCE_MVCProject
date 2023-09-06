using E_COMMERCEMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCEMVC.Controllers
{
    public class ProductController : Controller
    {
        IProduct iproductRepo;

      public ProductController(IProduct _productrepo) 
        {
        iproductRepo = _productrepo;
        
        }
     
        public IActionResult Index(int id)
        {
           
            return View(iproductRepo.GetById(id));
        }
    }
}
