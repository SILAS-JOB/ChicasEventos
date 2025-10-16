using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChicasEventos.Models;
using ChicasEventos.Services;
using Org.BouncyCastle.Crypto.Prng;

namespace ChicasEventos.Controllers
{
    public class PagesController : Controller
    {
        private readonly StaticDataService _dataService;

        public PagesController()
        {
            _dataService = new StaticDataService();
        }
        public IActionResult Buffet()
        {
            ViewData["ServiceTitle"] = "Buffet";
            var services = _dataService.GetServicesByCategory("Buffet");
            return View(services);
        }
        public IActionResult Audiovisual()
        {
            ViewData["ServiceTitle"] = "Audiovisual";
            var services = _dataService.GetServicesByCategory("Audiovisual");
            return View(services);
        }
        public IActionResult RH()
        {
            ViewData["ServiceTitle"] = "RH";
            var services = _dataService.GetServicesByCategory("RH");
            return View(services);
        }

        public IActionResult Cerimonial()
        {
            ViewData["ServiceTitle"] = "Cerimonial";
            var services = _dataService.GetServicesByCategory("Cerimonial");
            return View(services);
        }

        public IActionResult _ServiceDetailPartial(int id)
        {
            var service = _dataService.GetServiceById(id);
            if (service == null)
            {
                return Content("Detalhes não encontrados.");
            }
            return PartialView("_ServiceDetailPartial", service);
        }
    }
}