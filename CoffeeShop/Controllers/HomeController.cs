using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ShopDBContext db = new ShopDBContext();
            return View();
        }

        public IActionResult Shop()
        {
            ShopDBContext db = new ShopDBContext();
     
            return View();
        }

        public IActionResult Register(Users users)
        {
            ShopDBContext db = new ShopDBContext();
            db.Users.Add(new Users()
            {
                Username = users.Username,
                Email = users.Email,
                Password = users.Password
            });
            db.Users.Add(users);
            db.SaveChanges();
            return View();
        }

        public IActionResult MakeNewUser(Users u)
        {
            return View();
        }

        //need one action to load registraion page also need a view
        public IActionResult Registers()
        {
            //if no view is speciified it default to action name
            return View();
        }

        //public IActionResult Verify(/*string password, string confirm*/) 
        //{
        //    if (ViewBag.password == ViewBag.confirm)
        //    {
        //        return Registered();
        //    }
        //    else
        //    {
        //        return Wrong();
        //    }
        //}

        public IActionResult Wrong()
        {
            return View();
        }

        public IActionResult Registered(string username, string email, string password, string phone, int age, string favoritColor)
        {
            if (ViewBag.password == ViewBag.confirm)
            {
                ViewBag.Name = username;
                ViewBag.Email = email;
                ViewBag.Password = password;
                ViewBag.Phone = phone;
                ViewBag.Age = age;
                ViewBag.FavoriteColor = favoritColor;
                return View();
            }
            else
            {
                return Wrong();
            }
        }

        //one action to take user inputs and diplay user name
        public IActionResult Display()
        {
            return View();
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
