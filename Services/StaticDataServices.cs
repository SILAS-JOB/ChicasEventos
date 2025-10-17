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
                    ImagemPrincipalCard = "/img/products/coqueteis/coq1.jpg",
                    ImagemGrandeModal = ".",
                    ImagensPequenasModal = ["Sas","a"]
                    },
                new ServiceViewModel {
                Id = 102,
                Category = "Buffet",
                Titulo = "Coffee Break",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"]
                },
                new ServiceViewModel { 
                Id = 103,
                Category = "Buffet",
                Titulo = "Brunch",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"]},
                new ServiceViewModel { 
                Id = 104,
                Category = "Buffet",
                Titulo = "Almoço/Jantar",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"]},
                new ServiceViewModel { 
                Id = 105,
                Category = "Buffet",
                Titulo = "Sobremesas & Doces",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"] },
                new ServiceViewModel { 
                Id = 106,
                Category = "Buffet",
                Titulo = "Bebidas & Bar",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"]},
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
                new ServiceViewModel {
                Id = 201,
                Category = "Audiovisual",
                Titulo = "Fotografia",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"] },

                new ServiceViewModel
                {
                    Id = 202,
                Category = "Audiovisual",
                Titulo = "Vídeo",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 203,
                Category = "Audiovisual",
                Titulo = "Drone",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 204,
                Category = "Audiovisual",
                Titulo = "Social Media",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 205,
                Category = "Audiovisual",
                Titulo = "Streaming",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 206,
                Category = "Audiovisual",
                Titulo = "Edição",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                }

            };
        }

        private List<ServiceViewModel> GetCerimonialData() {
            return new List<ServiceViewModel>
            {
                new ServiceViewModel {
                Id = 301,
                Category = "Cerimonial",
                Titulo = "Planejamento",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"] },

                new ServiceViewModel
                {
                    Id = 302,
                Category = "Cerimonial",
                Titulo = "Cronograma",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 303,
                Category = "Cerimonial",
                Titulo = "Fornecedores",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 304,
                Category = "Cerimonial",
                Titulo = "Execução",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 305,
                Category = "Cerimonial",
                Titulo = "Coordenação",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 306,
                Category = "Cerimonial",
                Titulo = "Produção",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                }
            };
        }
        private List<ServiceViewModel> GetRhData() { /* ... 6 itens ... */
            return new List<ServiceViewModel>
            {
            new ServiceViewModel {
                Id = 401,
                Category = "RH",
                Titulo = "Garçons",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"] },

                new ServiceViewModel
                {
                    Id = 402,
                Category = "RH",
                Titulo = "Recepção",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 403,
                Category = "RH",
                Titulo = "Segurança",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 404,
                Category = "RH",
                Titulo = "Apoio Operacional",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 405,
                Category = "RH",
                Titulo = "Coordenação",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                },

                new ServiceViewModel
                {
                    Id = 406,
                Category = "RH",
                Titulo = "Briefing",
                DescricaoBreve = "A",
                SubtituloModal = "A",
                ItensInclusos = ["A"],
                ImagemPrincipalCard = "/img/buffet/coffee_card.jpg",
                ImagemGrandeModal = "A",
                ImagensPequenasModal = ["A"],
                }
            }; 
        }
    }
}