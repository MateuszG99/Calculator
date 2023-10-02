using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Jan";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien dobry" : "Dobry Wieczor";

            Dane[] osoby =
                {
                    new Dane {Name = "Mateusz", Surname = "Golonka"},
                    new Dane {Name = "Mateusz", Surname = "Kowalski"},
                    new Dane {Name = "Mateusz", Surname = "Nowy"}
                };


            return View(osoby);
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }

        public IActionResult Kalkulator(Kalkulator calc, string Result)
        {


            float a = calc.Number1;
            float b = calc.Number2;
            float c = 0;

            switch (Result)
            {
                case "Add":
                    c = a + b;
                    break;

                case "Remove":
                    c = a - b;
                    break;

                case "Multiply":
                    c = a * b;
                    break;

                case "Divide":
                    c = a / b;
                    break;
            }

            ViewBag.Result = c;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}