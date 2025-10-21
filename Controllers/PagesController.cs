using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChicasEventos.Models;
using ChicasEventos.Services;
using Org.BouncyCastle.Crypto.Prng; //Cryptografia 
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ChicasEventos.Controllers
{
    public class PagesController : Controller
    {
        private readonly StaticDataService _dataService;
        private readonly IEmailService _emailService;
        
        private readonly ILogger _logger;
        private readonly EmailSettings _emailSettings;

        public PagesController(StaticDataService dataService, IEmailService emailService, ILogger<PagesController> logger, IConfiguration config, IOptions<EmailSettings> emailSettings)
        {
            _dataService = dataService;
            _emailService = emailService;
            _logger = logger;
            _emailSettings = emailSettings.Value;
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
        public IActionResult _StaffingServicePartial(string category)
        {
            var model = _dataService.GetStaffingServicesByCategory(category);
            return PartialView("_StaffingServicePartial", model);
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
                else if (item.Type == "staffing")
                {
                    var staffingService = _dataService.GetStaffingServiceById(item.Id); 
                    if (staffingService != null)
                    {
                        var selectedOption = staffingService.PricingOptions.FirstOrDefault(p => p.Id == item.OptionId);
                        if (selectedOption != null)
                        {
                            viewModel.Add(new {
                                Title = staffingService.Title,
                                Label = selectedOption.Label,
                                Price = selectedOption.Price
                            });
                        }
                    }
                }
            }
            return PartialView("_CartItemsListPartial", viewModel);
        }

        public IActionResult _OrderFormPartial()
        {
            return PartialView("_OrderFormPartial", new OrderFormViewModel());
        }

        // [HttpPost]
        // public async Task<IActionResult> SendOrder([FromBody] FullOrderViewModel fullOrder)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest("Dados do formulário inválidos");
        //     }

        //     var emailBody = new StringBuilder();
        //     emailBody.AppendLine("<h1>Novo Pedido de Orçamento Recebido</h1>");
        //     emailBody.AppendLine("<h2>Dados do Cliente:</h2>");
        //     emailBody.AppendLine($"<p><strong>Nome:</strong> {fullOrder.FormData.Nome}</p>");
        //     emailBody.AppendLine($"<p><strong>Email:</strong> {fullOrder.FormData.Email}</p>");
        //     emailBody.AppendLine($"<p><strong>Telefone:</strong> {fullOrder.FormData.Telefone}</p>");
        //     emailBody.AppendLine("<h2>Detalhes do Evento:</h2>");
        //     emailBody.AppendLine($"<p><strong>Nome do Evento:</strong> {fullOrder.FormData.NomeEvento}</p>");
        //     //Add Resto
        //     emailBody.AppendLine("<hr><h2>Itens do Orçamento:</h2><ul>");

        //     foreach (var item in fullOrder.CartItems)
        //     {
        //         if (item.Type == "service")
        //         {
        //             var service = _dataService.GetServiceById(item.Id);
        //             if (service != null) emailBody.AppendLine($"<li>Serviço: {service.Titulo} ({service.Category})</li>");

        //         }
        //         else if (item.Type == "package")
        //         {
        //             var package = _dataService.GetPackageById(item.Id);
        //             if (package != null) emailBody.AppendLine($"<li>Pacote: {package.Nome} ({package.PrecoPorPessoa})");
        //         }
        //     }
        //     emailBody.AppendLine("</ul>");

        //     try
        //     {
        //         var companyEmail = "atendimentochicas@gmail.com"; //email hardcoded
        //         var subject = $"Novo Orçamento de {fullOrder.FormData.Nome} - Evento: {fullOrder.FormData.NomeEvento}";
        //         await _emailService.SendOrderEmailAsync(companyEmail, subject, emailBody.ToString());

        //         return Ok(new { message = "Orçamento enviado com sucesso! Entraremos em contato em breve." });
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, "Ocorreu uma exceção ao tentar enviar o e-mail do pedido");
        //         return StatusCode(500, "Ocorreu um erro ao enviar seu orçamento. Por favor, tente novamente.");
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> SendOrder([FromBody] FullOrderViewModel fullOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados do formulário inválidos");
            }

            var emailBody = new StringBuilder();
            decimal totalCost = 0; // <-- Variável para o total
            var itemDescriptions = new List<string>(); // <-- Lista para guardar as descrições dos itens

            // --- PRIMEIRO, CALCULAMOS O TOTAL E COLETAMOS AS DESCRIÇÕES ---
            foreach (var item in fullOrder.CartItems)
            {
                if (item.Type == "service")
                {
                    var service = _dataService.GetServiceById(item.Id);
                    if (service != null) 
                    {
                        itemDescriptions.Add($"Serviço: {service.Titulo} ({service.Category})");
                        // Serviços simples não têm preço definido no seu modelo, então não somamos
                    }
                }
                else if (item.Type == "package")
                {
                    var package = _dataService.GetPackageById(item.Id);
                    if (package != null)
                    {
                        itemDescriptions.Add($"Pacote: {package.Nome} ({package.PrecoPorPessoa})");
                        // PrecoPorPessoa é string, precisaria converter para decimal para somar
                    }
                }
                // ✅ ADICIONE ESTE BLOCO PARA "STAFFING"
                else if (item.Type == "staffing")
                {
                    var staffingService = _dataService.GetStaffingServiceById(item.Id);
                    if (staffingService != null)
                    {
                        var selectedOption = staffingService.PricingOptions.FirstOrDefault(p => p.Id == item.OptionId);
                        if (selectedOption != null && selectedOption.Price > 0)
                        {
                            itemDescriptions.Add($"Equipe: {staffingService.Title} ({selectedOption.Label})");
                            totalCost += selectedOption.Price; // Soma o preço da opção escolhida
                        }
                    }
                }
            }

            // --- AGORA, CONSTRUÍMOS O E-MAIL COM O TOTAL CALCULADO ---
            emailBody.AppendLine("<h1>Novo Pedido de Orçamento Recebido</h1>");
            emailBody.AppendLine("<h2>Dados do Cliente:</h2>");
            emailBody.AppendLine($"<p><strong>Nome:</strong> {fullOrder.FormData.Nome}</p>");
            emailBody.AppendLine($"<p><strong> {fullOrder.FormData.Email}</strong></p>");
            emailBody.AppendLine("<hr><h2>Itens do Orçamento:</h2><ul>");

            foreach(var description in itemDescriptions)
            {
                emailBody.AppendLine($"<li>{description}</li>");
            }
            emailBody.AppendLine("</ul>");

            // ✅ ADICIONE O TOTAL AO FINAL DO E-MAIL
            emailBody.AppendLine("<hr>");
            emailBody.AppendLine($"<h3><strong>Total (serviços de equipe): {totalCost.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}</strong></h3>");

            try
            {
                var companyEmail = _emailSettings.SenderEmail;
                var subject = $"Novo Orçamento de {fullOrder.FormData.Nome}";
                await _emailService.SendOrderEmailAsync(companyEmail, subject, emailBody.ToString());
                return Ok(new { message = "Orçamento enviado com sucesso!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu uma exceção ao tentar enviar o e-mail do pedido");
                return StatusCode(500, "Ocorreu um erro ao enviar seu orçamento.");
            }
        }
    }
}