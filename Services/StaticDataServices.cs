using ChicasEventos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChicasEventos.Services
{
    public class StaticDataService
    {
        private readonly List<ServiceViewModel> _allServices;
        private readonly List<PackageViewModel> _allPackages;
        public StaticDataService()
        {
            _allServices = new List<ServiceViewModel>();
            _allServices.AddRange(GetBuffetData());
            _allServices.AddRange(GetAudiovisualData());
            _allServices.AddRange(GetCerimonialData());
            _allServices.AddRange(GetRhData());


            _allPackages = new List<PackageViewModel>();
            _allPackages.AddRange(GetBuffetPackages());
        }

        public List<ServiceViewModel> GetServicesByCategory(string category)
        {
            return _allServices.Where(s => s.Category.Equals(category, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<PackageViewModel> GetPackageByCategory(string category)
        {
            return _allPackages.Where(p => p.Categoria.Equals(category, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public ServiceViewModel GetServiceById(int id)
        {
            return _allServices.FirstOrDefault(s => s.Id == id);
        }

        public PackageViewModel GetPackageById(int id)
        {
            return _allPackages.FirstOrDefault(p => p.Id == id);    
        }

        // --- Métodos privados para carregar os dados de cada categoria ---

        private List<ServiceViewModel> GetBuffetData()
        {
            return new List<ServiceViewModel> {
                new ServiceViewModel {
                    Id = 101,
                    Category = "Buffet",
                    Titulo = "Coquetéis",
                    DescricaoBreve = "A",
                    SubtituloModal = "A",
                    ItensInclusos = ["A","A"],
                    ImagemPrincipalCard = "/img/buffet/coquetel_card.jpg",
                    ImagemGrandeModal = ".",
                    ImagensPequenasModal = ["Sas","a"]
                    },
                new ServiceViewModel { Id = 102, Category = "Buffet", Titulo = "Coffee Break", /* ... */ ImagemPrincipalCard = "/img/buffet/coffee_card.jpg" },
                new ServiceViewModel { Id = 103, Category = "Buffet", Titulo = "Brunch", /* ... */ ImagemPrincipalCard = "/img/buffet/brunch_card.jpg" },
                new ServiceViewModel { Id = 104, Category = "Buffet", Titulo = "Almoço/Jantar", /* ... */ ImagemPrincipalCard = "/img/buffet/jantar_card.jpg" },
                new ServiceViewModel { Id = 105, Category = "Buffet", Titulo = "Sobremesas & Doces", /* ... */ ImagemPrincipalCard = "/img/buffet/doces_card.jpg" },
                new ServiceViewModel { Id = 106, Category = "Buffet", Titulo = "Bebidas & Bar", /* ... */ ImagemPrincipalCard = "/img/buffet/bar_card.jpg" },
            };
        }
        
        private List<PackageViewModel> GetBuffetPackages()
        {
            return new List<PackageViewModel>
            {
                new PackageViewModel
                {
                    Id = 501,
                    Categoria = "Buffet",
                    Descricao = "AAAA",
                    ImagemPrincipal = "a",
                    ImagensPequenas = ["a","a"],
                    ItensInclusos= ["a"],
                    Nome = "a",
                    PrecoPorPessoa= "R$29.99"
                },
                new PackageViewModel
                {
                    Id = 502,
                    Categoria = "Buffet",
                    Descricao = "AAAA",
                    ImagemPrincipal = "a",
                    ImagensPequenas = ["a","a"],
                    ItensInclusos= ["a"],
                    Nome = "a",
                    PrecoPorPessoa= "R$29.99"
                },
                new PackageViewModel
                {
                    Id = 503,
                    Categoria = "Buffet",
                    Descricao = "AAAA",
                    ImagemPrincipal = "a",
                    ImagensPequenas = ["a","a"],
                    ItensInclusos= ["a"],
                    Nome = "a",
                    PrecoPorPessoa= "R$29.99"
                }

            };
        }
        
        private List<ServiceViewModel> GetAudiovisualData() {
            return new List<ServiceViewModel> {
                new ServiceViewModel { Id = 201, Category = "Audiovisual", Titulo = "Sonorização", /* ... */ ImagemPrincipalCard = "/img/audiovisual/som_card.jpg" },
                // ... outros 5 itens de Audiovisual ...
            };
        }

        private List<ServiceViewModel> GetCerimonialData() { /* ... 6 itens ... */ return new List<ServiceViewModel>(); }
        private List<ServiceViewModel> GetRhData() { /* ... 6 itens ... */ return new List<ServiceViewModel>(); }
    }
}