using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChicasEventos.Models;
using Microsoft.AspNetCore.Authorization;

namespace ChicasEventos.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portifolio()
        {
            return View();
        }

        public IActionResult Sobre()
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