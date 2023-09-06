using E_COMMERCEMVC.Models;
using E_COMMERCEMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCEMVC.Controllers
{
    public class CategoryController : Controller
    {
        ICategory categoryRepository;
        IProduct productRepository;
        ICartItem cartItemRepository;
        public CategoryController(ICategory _categoryRepository, IProduct _productRepository , ICartItem _cartItemRepository)
        {
            categoryRepository= _categoryRepository;
            productRepository= _productRepository;
            cartItemRepository = _cartItemRepository;
        }
        //public ActionResult GetAll() 
        //{
        //    return View(categoryRepository.GetAll());
        //}
        //public ActionResult CatbyId(int id)
        //{
        //    return View(categoryRepository.GetById(id));
        //}
        public IActionResult GetProdByCatId(int CatId)
        {
            
            return View(categoryRepository.GetByCatID(CatId));

        }
        public IActionResult New()
        {
            ViewData["Prods"] = productRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult New(Category newCat)
        {
            if (ModelState.IsValid == true)//Server side validation
            {
                try
                {
                    categoryRepository.Insert(newCat);
                    return RedirectToAction("GetAll");
                }
                catch (Exception ex)
                {
                    //send info ==>view
                    ModelState.AddModelError("Exception", ex.InnerException.Message);
                }
            }
            ViewData["Prods"] = productRepository.GetAll();
            return View(newCat);
        }
        public void Delete(int id) {
            categoryRepository.DeleteById(id);
        }
        public IActionResult Edit(int id)
        {
            Category CatModel = categoryRepository.GetById(id);
            ViewData["Prods"] = productRepository.GetAll();
            return View(CatModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, Category CatForm)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(id, CatForm);
                return RedirectToAction("GetAll");
            }
            ViewData["Prods"] = productRepository.GetAll();
            return View(CatForm);
        }

    }
}
