using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChicasEventos.Models;

namespace ChicasEventos.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}