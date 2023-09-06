using E_COMMERCEMVC.Models;
using E_COMMERCEMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCEMVC.Controllers
{
    public class CardController : Controller
    {
        ICartItem _cartItemRepository;
        IProduct _product;

        public CardController(ICartItem cartItemRepository,IProduct productRepo)
        {
            _cartItemRepository = cartItemRepository;
            _product = productRepo;
        }

        // ///////////////////////////////////////////////
        [HttpPost]
        public ActionResult Index( int[]  id )
        {
            
            List<Product> products = new List<Product>();
            foreach (var p in id)
            {
                
                var a = _product.GetById(p);
                products.Add(a);

            }

            return View(products);


        }

        //[HttpGet]
        //public ActionResult Index( )
        //{
        //    return View();
        //}

        ///////////////////////////////////////////////
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create( int PrdId , CartItem cartItem)
        {
            var product = _product.GetById( PrdId );
            _cartItemRepository.Insert(cartItem);
            return RedirectToAction("Index");
           
        }


        


        ///////////////////////////////////////////////////
        public ActionResult Edit(int id)
        {
            CartItem cartItem = _cartItemRepository.GetById(id);
            return View(cartItem);
        }

        //
        [HttpPost]
        public ActionResult Edit(int id, CartItem cartItem)
        {
            try
            {
                _cartItemRepository.Update(id, cartItem);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // /////////////////////////////////
        public ActionResult Delete(int id)
        {
            CartItem cartItem = _cartItemRepository.GetById(id);
            return View(cartItem);
        }

       
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _cartItemRepository.DeleteById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
