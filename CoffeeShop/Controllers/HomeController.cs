using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;
using System.Text.Json;

//Jason Swift

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
            //GRAB A PERSON OBJ AND HOLD IN TEMP DATA
            TempData["Users"]=db.Users.ToList()[0];

            //use json serializer to make obj into json obj
            //searilze takes a obj and builds a string that represent obj properties
            TempData["JsonUsers"] = JsonSerializer.Serialize(db.Users.ToList()[0]);

           // TempData.Keep();
            TempData["bool"] = false;

            return View(db);
        }

        public IActionResult Shop()
        {
            // ShopDBContext db = new ShopDBContext();
            //ViewBag.items = new Items;
            //ViewBag.Name = new name;
            //ViewBag.Price = new price;
            //ViewBag.Quanity = new quanity;
     
            return View();
        }


        public IActionResult Register()
        {
          
            return View();
        }

        public IActionResult MakeNewUser(Users u)
        {
            ShopDBContext db = new ShopDBContext();
            //db.Users.Add(new Users()
            //{
            //    Username = users.Username,
            //    Email = users.Email,
            //    Password = users.Password
            //});
            db.Users.Add(u);
            db.SaveChanges();
            return View(u);
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
