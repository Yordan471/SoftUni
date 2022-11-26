using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculator(double firstNumber, double secondNumber, string operation)
        {
            string result = string.Empty;

            switch (operation)
            {
                case "+":
                    result = $"{firstNumber + secondNumber}";
                    break;
                case "-":
                    result = $"{firstNumber - secondNumber}";
                    break;
                case "*":
                    result = $"{firstNumber - secondNumber}";
                    break;
                case "/":
                    result = $"{firstNumber - secondNumber}";
                    break;
                default:
                    result = "Invalid operator";
                    break;
            }

            ViewBag.Result = result;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
