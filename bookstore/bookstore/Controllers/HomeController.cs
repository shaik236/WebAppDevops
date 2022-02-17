using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
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
            return View();
        }

        public IActionResult Books()
        {

            //IQueryable<Techbook> items = from item in StoresContext

            IQueryable<Techbook> items = null;
            //IQueryable<Techbook> items = from item in StoresContext
            //                             orderby item.Id
            //                             select item;

            List<Techbook> ls = new List<Techbook>();

            Techbook t1 = new Techbook();
            t1.Id = 1;
            t1.Name = "test1";
            t1.Value = 1000;

            ls.Add(t1);

            //List<Techbook> result = items.ToList();

            List<Techbook> result = ls;


            return View(result);
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
