using E_COMMERCEMVC.Models;
using E_COMMERCEMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCEMVC.Controllers
{
    public class OrderController : Controller
    {
       
            private readonly IOrder _orderRepository;

            public OrderController(IOrder orderRepository)
            {
                _orderRepository = orderRepository;
            }

            // /////////////////////////////////////////////////
            public ActionResult Details(int id)
            {
                Order order = _orderRepository.GetById(id);
                return View(order);
            }

            public ActionResult Create()
            {
                return View();
            }

          
            [HttpPost]
            public ActionResult Create(Order order)
            {
                try
                {
                    _orderRepository.Insert(order);
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    return View();
                }
            }
        }
    }

