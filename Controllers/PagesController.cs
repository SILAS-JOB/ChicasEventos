using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChicasEventos.Models;
using ChicasEventos.Services;
using Org.BouncyCastle.Crypto.Prng;
using System.Text;

namespace ChicasEventos.Controllers
{
    public class PagesController : Controller
    {
        private readonly StaticDataService _dataService;
        private readonly IEmailService _emailService;
        public PagesController(StaticDataService staticDataService, IEmailService emailService)
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

        public IActionResult _PackagesPartial(string category)
        {
            var packages = _dataService.GetPackageByCategory(category);
            return PartialView("_PackagesPartial", packages);
        }

        public IActionResult _PackageDetailPartial(int id)
        {
            var packages = _dataService.GetPackageById(id);
            return PartialView("_PackageDetailPartial", packages);
        }

        public IActionResult Carrinho()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _GetCartItemsPartial([FromBody] List<CartItemRequest> items)
        {
            var viewModel = new List<object>();

            foreach (var item in items)
            {
                if (item.Type == "service")
                {
                    var service = _dataService.GetServiceById(item.Id);
                    if (service != null) viewModel.Add(service);
                }
                else if (item.Type == "package")
                {
                    var package = _dataService.GetPackageById(item.Id);
                    if (package != null) viewModel.Add(package);
                }
            }

            return PartialView("_CartItemsListPartial", viewModel);
        }

        public IActionResult _OrderFormPartial()
        {
            return PartialView("_OrderFormPartial", new OrderFormViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SendOrder([FromBody] FullOrderViewModel fullOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados do formulário inválidos");
            }

            var emailBody = new StringBuilder();
            emailBody.AppendLine("<h1>Novo Pedido de Orçamento Recebido</h1>");
            emailBody.AppendLine("<h2>Dados do Cliente:</h2>");
            emailBody.AppendLine($"<p><strong>Nome:</strong> {fullOrder.FormData.Nome}</p>");
            emailBody.AppendLine($"<p><strong>Email:</strong> {fullOrder.FormData.Email}</p>");
            emailBody.AppendLine($"<p><strong>Telefone:</strong> {fullOrder.FormData.Telefone}</p>");
            emailBody.AppendLine("<h2>Detalhes do Evento:</h2>");
            emailBody.AppendLine($"<p><strong>Nome do Evento:</strong> {fullOrder.FormData.NomeEvento}</p>");
            //Add Resto
            emailBody.AppendLine("<hr><h2>Itens do Orçamento:</h2><ul>");

            foreach (var item in fullOrder.CartItems)
            {
                if (item.Type == "service")
                {
                    var service = _dataService.GetServiceById(item.Id);
                    if (service != null) emailBody.AppendLine($"<li>Serviço: {service.Titulo} ({service.Category})</li>");

                }
                else if (item.Type == "package")
                {
                    var package = _dataService.GetPackageById(item.Id);
                    if (package != null) emailBody.AppendLine($"<li>Pacote: {package.Nome} ({package.PrecoPorPessoa})");
                }
            }
            emailBody.AppendLine("</ul>");

            try
            {
                var companyEmail = "contato@chicas-eventos.com.br"; // Substitua pelo email real
                var subject = $"Novo Orçamento de {fullOrder.FormData.Nome} - Evento: {fullOrder.FormData.NomeEvento}";
                await _emailService.SendOrderEmailAsync(companyEmail, subject, emailBody.ToString());
                
                return Ok(new { message = "Orçamento enviado com sucesso! Entraremos em contato em breve." });
            } catch(Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao enviar seu orçamento. Por favor, tente novamente.");
            }
        }
    }
}