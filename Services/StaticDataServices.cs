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
                    DescricaoBreve = "Serviço volante com finger food",
                    SubtituloModal = "Nossos coquetéis são preparados com ingredientes frescos e selecionados, oferecendo uma experiência gastronômica única. Inclui finger foods variados e bebidas especiais.",
                    ItensInclusos = ["Bartender profissional", "Coquetéis clássicos e autorais", "Finger foods variados", "Equipamentos de bar completos", "Decoração temática"],
                    ImagemPrincipalCard = "/img/products/coqueteis/coq1.jpg",
                    ImagemGrandeModal = "/img/products/coqueteis/coq1.jpg",
                    ImagensPequenasModal = ["/img/products/coqueteis/coq2.jpg", "/img/products/coqueteis/coq3.jpeg"]
                    },
                new ServiceViewModel {
                Id = 102,
                Category = "Buffet",
                Titulo = "Coffee Break",
                DescricaoBreve = "Perfeito para reuniões e conferências",
                SubtituloModal = "Coffee break completo com café premium, chás, sucos naturais e lanches variados. Ideal para eventos corporativos e reuniões.",
                ItensInclusos = ["Café premium e chás especiais", "Lanches e salgados variados", "Sucos naturais e água", "Equipamentos profissionais", "Atendimento especializado"],
                ImagemPrincipalCard = "/img/products/coffe_break/cb3.jpg",
                ImagemGrandeModal = "/img/products/coffe_break/cb3.jpg",
                ImagensPequenasModal = ["/img/products/coffe_break/cb4.jpg", "/img/products/coffe_break/cb2.jpg"]
                },
                new ServiceViewModel { 
                Id = 103,
                Category = "Buffet",
                Titulo = "Brunch",
                DescricaoBreve = "Mix café da manhã + almoço",
                SubtituloModal = "Brunch completo combinando o melhor do café da manhã e almoço. Perfeito para eventos matinais e ocasiões especiais.",
                ItensInclusos = ["Pratos quentes e frios", "Frutas frescas da estação", "Pães artesanais", "Ovos preparados de várias formas", "Bebidas variadas"],
                ImagemPrincipalCard = "/img/products/brunch/bb4.jpg",
                ImagemGrandeModal = "/img/products/brunch/bb4",
                ImagensPequenasModal = [ "/img/products/brunch/bb3.jpg", "/img/products/brunch/bb1.jpeg"]},
                new ServiceViewModel { 
                Id = 104,
                Category = "Buffet",
                Titulo = "Almoço/Jantar",
                DescricaoBreve = "Buffet quente completo",
                SubtituloModal = "Refeições completas com pratos quentes, saladas, acompanhamentos e sobremesas. Cardápio variado para todos os gostos.",
                ItensInclusos = ["Pratos quentes variados", "Saladas frescas", "Acompanhamentos especiais", "Sobremesas caseiras", "Bebidas inclusas"],
                ImagemPrincipalCard = "/img/products/almoco_jantar/aljn4.jpg",
                ImagemGrandeModal = "/img/products/almoco_jantar/aljn4.jpg",
                ImagensPequenasModal = [ "/img/products/almoco_jantar/aljn3.jpeg", "/img/products/almoco_jantar/aljn1.jpg"]},
                new ServiceViewModel { 
                Id = 105,
                Category = "Buffet",
                Titulo = "Sobremesas & Doces",
                DescricaoBreve = "Finalização doce com mesa temática",
                SubtituloModal = "Mesa de sobremesas temática com doces variados, bolos, tortas e docinhos. Perfeito para finalizar seu evento com doçura.",
                ItensInclusos = ["Bolos e tortas artesanais", "Docinhos variados", "Mesa temática decorada", "Doces sem açúcar (opcional)", "Decoração especial"],
                ImagemPrincipalCard = "/img/products/sobremesas/ss1.png",
                ImagemGrandeModal = "/img/products/sobremesas/ss1.png",
                ImagensPequenasModal = [ "/img/products/sobremesas/ss2.png", "/img/products/sobremesas/ss4.png"] ,  },
                new ServiceViewModel { 
                Id = 106,
                Category = "Buffet",
                Titulo = "Bebidas & Bar",
                DescricaoBreve = "Bar de drinks e espumantes",
                SubtituloModal = "Bar completo com drinks especiais, espumantes, vinhos e bebidas não alcoólicas. Bartender profissional para seu evento.",
                ItensInclusos = ["Bar completo montado", "Bartender profissional", "Drinks especiais e clássicos", "Espumantes e vinhos", "Bebidas não alcoólicas"],
                ImagemPrincipalCard = "/img/products/bebida_bar/bbb1.jpg",
                ImagemGrandeModal = "/img/products/bebida_bar/bbb1.jpg",
                ImagensPequenasModal = ["/img/products/bebida_bar/bbb2.jpg", "/img/products/bebida_bar/bbb3.jpg"]},
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
                    ImagemPrincipal = "/img/products/coqueteis/coq1.jpg",
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
                DescricaoBreve = "Cobertura completa do evento",
                SubtituloModal = "Cobertura fotográfica profissional com equipamentos de última geração. Capturamos os melhores momentos do seu evento com qualidade excepcional.",
                ItensInclusos = ["Fotógrafo profissional experiente", "Equipamentos de última geração", "Cobertura completa do evento", "Entrega rápida das fotos", "Edição profissional incluída"],
                ImagemPrincipalCard = "/img/products/fotografia/ff4.jpg",
                ImagemGrandeModal = "/img/products/fotografia/ff4.jpg",
                ImagensPequenasModal = ["/img/products/fotografia/ff3.jpg", "/img/products/fotografia/ff2.jpg"] },

                new ServiceViewModel
                {
                    Id = 202,
                Category = "Audiovisual",
                Titulo = "Vídeo",
                DescricaoBreve = "Filmagem e edição profissional",
                SubtituloModal = "Filmagem profissional com equipamentos de alta qualidade e edição especializada. Criamos vídeos que contam a história do seu evento.",
                ItensInclusos = ["Filmagem profissional HD/4K", "Equipamentos de alta qualidade", "Edição especializada", "Múltiplas câmeras", "Entrega em diferentes formatos"],
                ImagemPrincipalCard = "/img/products/video/vv3.jpg",
                ImagemGrandeModal = "/img/products/video/vv3.jpg",
                ImagensPequenasModal = ["/img/products/video/vv2.jpeg", "/img/products/video/vv1.jpg"],
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