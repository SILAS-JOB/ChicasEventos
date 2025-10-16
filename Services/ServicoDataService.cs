using ChicasEventos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChicasEventos.Services
{
    public class ServicoDataService
    {
        private readonly List<ServicoViewModel> _servicos;

        public ServicoDataService()
        {
            _servicos = new List<ServicoViewModel>
            {
                new ServicoViewModel 
                { 
                    Id = 1, 
                    Titulo = "Serviço de Coquetel", 
                    Descricao = "Nossos coquetéis são preparados com ingredientes frescos e selecionados, oferecendo uma experiência gastronômica única.",
                    ItensInclusos = new List<string> { "Bartender profissional", "Coquetéis clássicos e autorais", "Finger foods variados" },
                    ImagensCarousel = new List<string> { "/img/coquetel1.jpg", "/img/coquetel2.jpg", "/img/coquetel3.jpg" }
                },
                new ServicoViewModel 
                { 
                    Id = 2, 
                    Titulo = "Almoço Executivo", 
                    Descricao = "Soluções completas para eventos corporativos, com cardápios balanceados e serviço impecável.",
                    ItensInclusos = new List<string> { "Cardápio personalizado", "Mesa de sobremesas", "Serviço de garçons" },
                    ImagensCarousel = new List<string> { "/img/almoco1.jpg", "/img/almoco2.jpg" }
                },
                // ... Adicione os outros 4 serviços aqui
                new ServicoViewModel { Id = 3, Titulo = "Jantar de Gala", /* ... */ ImagensCarousel = new List<string>() },
                new ServicoViewModel { Id = 4, Titulo = "Brunch", /* ... */ ImagensCarousel = new List<string>() },
                new ServicoViewModel { Id = 5, Titulo = "Coffee Break", /* ... */ ImagensCarousel = new List<string>() },
                new ServicoViewModel { Id = 6, Titulo = "Mesa de Frios", /* ... */ ImagensCarousel = new List<string>() }
            };
        }

        public List<ServicoViewModel> GetTodosServicos()
        {
            return _servicos;
        }

        public ServicoViewModel GetServicoPorId(int id)
        {
            return _servicos.FirstOrDefault(s => s.Id == id);
        }
    }
}