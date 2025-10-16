using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChicasEventos.Models;
using ChicasEventos.Services;

namespace ChicasEventos.Controllers
{
    public class PagesController : Controller
    {
        private readonly ServicoDataService _servicoData;

        public PagesController()
        {
            _servicoData = new ServicoDataService();
        }
        public IActionResult Buffet()
        {
            var todosServicos = _servicoData.GetTodosServicos();

            return View();
        }
        public IActionResult Audiovisual()
        {
            return View();
        }
        public IActionResult RH()
        {
            return View();
        }

        public IActionResult Cerimonial()
        {
            return View();
        }
    }
}