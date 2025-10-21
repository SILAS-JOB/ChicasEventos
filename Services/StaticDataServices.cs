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
                    Titulo = "Coquetel",
                    DescricaoBreve = "Serviço volante com finger food",
                    SubtituloModal = "Tudo é preparado com ingredientes frescos e selecionados oferecendo assim uma experiência gastronômica única.",
                    ItensInclusos = ["Bartender ", "Coquetéis clássicos e autorais","Decoração temática"],
                    ImagemPrincipalCard = "/img/products/coqueteis/coq1.jpg",
                    ImagemGrandeModal = "/img/products/coqueteis/coq1.jpg",
                    ImagensPequenasModal = ["/img/products/coqueteis/coq2.jpg", "/img/products/coqueteis/coq3.jpeg"]
                    },
                new ServiceViewModel {
                Id = 102,
                Category = "Buffet",
                Titulo = "Coffee Break",
                DescricaoBreve = "Perfeito para reuniões e conferências",
                SubtituloModal = "Coffee break completo com seleção de cafés premium, chás e sucos especiais, além dos lanches variados. Uma solução ideal para eventos corporativos oferecendo qualidade, praticidade e sofisticação.",
                ItensInclusos = ["Café premium e chás especiais", "Lanches e salgados variados", "Sucos naturais e água mineral", "Equipamentos profissionais de apoio ", "Atendimento especializado",],
                ImagemPrincipalCard = "/img/products/coffebreak/cb3.jpg",
                ImagemGrandeModal = "/img/products/coffebreak/cb3.jpg",
                ImagensPequenasModal = ["/img/products/coffebreak/cb4.jpg", "/img/products/coffebreak/cb2.jpg"]
                },
                new ServiceViewModel { 
                Id = 103,
                Category = "Buffet",
                Titulo = "Brunch",
                DescricaoBreve = "Mix café da manhã + almoço",
                SubtituloModal = "Brunch completo combinando o melhor do café da manhã e almoço. Perfeito para eventos matinais e próximos do horário de almoço",
                ItensInclusos = ["Pratos quentes e frios", "Frutas frescas da estação", "Pães artesanais", "Pratos quentes e frios com receitas simples e também sofisticadas", "Bebidas variadas"],
                ImagemPrincipalCard = "/img/products/brunch/bb4.jpg",
                ImagemGrandeModal = "/img/products/brunch/bb4",
                ImagensPequenasModal = [ "/img/products/brunch/bb3.jpg", "/img/products/brunch/bb1.jpeg"]},
                new ServiceViewModel { 
                Id = 104,
                Category = "Buffet",
                Titulo = "Almoço/Jantar",
                DescricaoBreve = "Pratos quentes e frios com receitas simples e também sofisticadas",
                SubtituloModal = "Oferecemos refeições completas compostas por uma seleção de pratos quentes, saladas, acompanhamentos e sobremesas. Nosso cardápio é cuidadosamente elaborado para atender aos mais diversos paladares com sabor e variedade.",
                ItensInclusos = ["Pratos quentes variados", "Saladas frescas", "Acompanhamentos especiais", "Sobremesas caseiras", "Bebidas inclusas"],
                ImagemPrincipalCard = "/img/products/almoco_jantar/aljn4.jpg",
                ImagemGrandeModal = "/img/products/almoco_jantar/aljn4.jpg",
                ImagensPequenasModal = [ "/img/products/almoco_jantar/aljn3.jpeg", "/img/products/almoco_jantar/aljn1.jpg"]},
                new ServiceViewModel { 
                Id = 106,
                Category = "Buffet",
                Titulo = "Ilha de Drinks",
                DescricaoBreve = "Drinks e espumantes",
                SubtituloModal = "Serviço completo de bar com uma seleção de drinks especiais, espumantes,vinhos e opções não alcoólicas. O bartender garantirá profissionalismo para seu evento.",
                ItensInclusos = ["Estrutura completa", "Bartender especializado", "Drinks autorais e clássicos", "Seleção de espumantes e vinhos", "Variedade de bebidas não alcoólicas"],
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
                    Descricao = "Perfeito para eventos corporativos e reuniões de negócios. Oferece um cardápio equilibrado com opções saudáveis e saborosas, ideal para coffee breaks e almoços executivos.",
                    ImagemPrincipal = "/img/products/coqueteis/coq1.jpg",
                    ImagensPequenas = ["/img/products/coqueteis/coq1.jpg","/img/products/coqueteis/coq1.jpg"],
                    ItensInclusos= ["Bar de drinks completo", "Espumantes e champanhes", "Finger foods variados", "Bartender profissional", "Equipamentos de bar", "Decoração básica"],
                    Nome = "Pacote bronze",
                    PrecoPorPessoa= "R$89/pessoa"
                },
                new PackageViewModel
                {
                    Id = 502,
                    Categoria = "Buffet",
                    Descricao = "Ideal para eventos de médio porte e celebrações especiais. Inclui uma seleção mais elaborada de pratos e bebidas, com maior variedade e qualidade premium.",
                    ImagemPrincipal = "/img/products/almoco_janta/aljn3.jpeg",
                    ImagensPequenas = ["/img/products/almoco_janta/aljn3.jpeg","/img/products/almoco_janta/aljn3.jpeg"],
                ItensInclusos= ["Bar de drinks premium", "Espumantes e champanhes selecionados", "Menu executivo completo", "Bartender especializado", "Equipamentos profissionais", "Decoração temática", "Garçom dedicado"],
                    Nome = "Pacote prata",
                    PrecoPorPessoa= "R$149/pessoa"
                },
                new PackageViewModel
                {
                    Id = 503,
                    Categoria = "Buffet",
                    Descricao = "Nossa opção mais luxuosa e completa. Perfeito para eventos de gala, casamentos e celebrações especiais. Oferece uma experiência gastronômica de alto nível com serviço personalizado.",
                    ImagemPrincipal = "/img/products/coffebreak/cb3.jpg",
                    ImagensPequenas = ["/img/products/coffebreak/cb3.jpg","/img/products/coffebreak/cb3.jpg"],
                    ItensInclusos= ["Bar de drinks exclusivo", "Champanhes e vinhos premium", "Menu gourmet completo", "Chef especializado", "Equipamentos de luxo", "Decoração personalizada", "Equipe completa de garçons", "Serviço de maitre", "Menu sob medida"],
                    Nome = "Pacote ouro",
                    PrecoPorPessoa= "R$229/pessoa"
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
                DescricaoBreve = "Imagens aéreas espetaculares",
                SubtituloModal = "Filmagem aérea com drone para capturar ângulos únicos e espetaculares do seu evento. Imagens que impressionam e destacam a grandiosidade do momento.",
                ItensInclusos = ["Piloto de drone certificado", "Equipamentos profissionais", "Imagens aéreas espetaculares", "Diferentes ângulos de filmagem", "Edição especializada"],
                ImagemPrincipalCard = "/img/products/drone/dd4.jpeg",
                ImagemGrandeModal = "/img/products/drone/dd4.jpeg",
                ImagensPequenasModal = ["/img/products/drone/dd1.jpeg", "/img/products/drone/dd2.jpeg"],
                },

                new ServiceViewModel
                {
                    Id = 204,
                Category = "Audiovisual",
                Titulo = "Social Media",
                DescricaoBreve = "Conteúdo para redes sociais",
                SubtituloModal = "Criação de conteúdo específico para redes sociais com linguagem de marca. Stories, posts e conteúdo interativo para engajar sua audiência.",
                ItensInclusos = ["Conteúdo para Instagram/Facebook", "Stories e posts interativos", "Linguagem de marca personalizada", "Entrega rápida do conteúdo", "Estratégia de engajamento"],
                ImagemPrincipalCard = "/img/products/socialmedia/ss4.jpg",
                ImagemGrandeModal = "/img/products/socialmedia/ss4.jpg",
                ImagensPequenasModal = ["/img/products/socialmedia/ss3.jpg", "/img/products/socialmedia/ss2.jpg"],
                },

                new ServiceViewModel
                {
                    Id = 205,
                Category = "Audiovisual",
                Titulo = "Streaming",
                DescricaoBreve = "Transmissão ao vivo do evento",
                SubtituloModal = "Transmissão ao vivo profissional do seu evento para plataformas como YouTube, Facebook e Instagram. Alcance uma audiência maior e preserve o momento.",
                ItensInclusos = ["Transmissão ao vivo profissional", "Múltiplas plataformas", "Qualidade HD/4K", "Interação com a audiência", "Gravação para posterior visualização"],
                ImagemPrincipalCard = "/img/products/streaming/tt4.jpeg",
                ImagemGrandeModal = "/img/products/streaming/tt4.jpeg",
                ImagensPequenasModal = ["/img/products/streaming/tt3.jpeg", "/img/products/streaming/tt2.jpeg"],
                },

                new ServiceViewModel
                {
                    Id = 206,
                Category = "Audiovisual",
                Titulo = "Edição",
                DescricaoBreve = "Pós-produção e finalização",
                SubtituloModal = "Serviços de pós-produção profissional com edição especializada, correção de cor, efeitos especiais e finalização em alta qualidade.",
                ItensInclusos = ["Edição profissional especializada", "Correção de cor", "Efeitos especiais", "Finalização em alta qualidade", "Entrega em diferentes formatos"],
                ImagemPrincipalCard = "/img/products/edicao/ed1.jpeg",
                ImagemGrandeModal = "/img/products/edicao/ed1.jpeg",
                ImagensPequenasModal = ["/img/products/edicao/ed4.jpeg", "/img/products/edicao/ed3.png"],
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
                DescricaoBreve = "Estratégia completa do evento",
                SubtituloModal = "Desenvolvimento de estratégia completa para o evento, incluindo cronograma, orçamento e definição de objetivos.",
                ItensInclusos = ["Estratégia completa do evento", "Definição de objetivos", "Cronograma detalhado", "Orçamento planejado" , "Análise de viabilidade"],
                ImagemPrincipalCard = "/img/products/planejamento/pp1.jpeg",
                ImagemGrandeModal = "/img/products/planejamento/pp1.jpeg",
                ImagensPequenasModal = ["/img/products/planejamento/pp2.png"] },

                new ServiceViewModel
                {
                    Id = 302,
                Category = "Cerimonial",
                Titulo = "Cronograma",
                DescricaoBreve = "Timeline detalhada e organizada",
                SubtituloModal = "Desenvolvimento de cronograma detalhado com todas as etapas do evento, desde o planejamento até a execução.",
                ItensInclusos = ["Timeline detalhada", "Marcos importantes", "Prazos definidos", "Responsabilidades claras", "Acompanhamento contínuo"],
                ImagemPrincipalCard = "/img/products/cronograma/cc2.jpeg",
                ImagemGrandeModal = "/img/products/cronograma/cc2.jpeg",
                ImagensPequenasModal = ["/img/products/cronograma/cc1.jpeg"],
                },

                new ServiceViewModel
                {
                    Id = 303,
                Category = "Cerimonial",
                Titulo = "Fornecedores",
                DescricaoBreve = "Rede de parceiros confiáveis",
                SubtituloModal = "Gestão completa da rede de fornecedores, desde a seleção até a coordenação no dia do evento.",
                ItensInclusos = ["Rede de fornecedores qualificados", "Seleção criteriosa", "Negociação de preços", "Coordenação de entregas", "Acompanhamento de qualidade"],
                ImagemPrincipalCard = "/img/products/fornecedores/ff2.jpg",
                ImagemGrandeModal = "/img/products/fornecedores/ff2.jpg",
                ImagensPequenasModal = ["/img/products/fornecedores/ff1.jpg"],
                },

                new ServiceViewModel
                {
                    Id = 304,
                Category = "Cerimonial",
                Titulo = "Execução",
                DescricaoBreve = "Coordenação no dia do evento",
                SubtituloModal = "Coordenação completa no dia do evento, garantindo que tudo saia conforme planejado.",
                ItensInclusos = ["Coordenação no dia do evento", "Supervisão de todas as atividades", "Resolução de problemas", "Comunicação com fornecedores", "Garantia de qualidade"],
                ImagemPrincipalCard = "/img/products/execucao/ee1.png",
                ImagemGrandeModal = "/img/products/execucao/ee1.png",
                ImagensPequenasModal = ["/img/products/execucao/ee2.jpeg"],
                },

                new ServiceViewModel
                {
                    Id = 305,
                Category = "Cerimonial",
                Titulo = "Coordenação",
                DescricaoBreve = "Gestão completa do evento",
                SubtituloModal = "Coordenação geral de todos os aspectos do evento, garantindo harmonia entre todos os serviços.",
                ItensInclusos = ["Coordenação geral", "Gestão de equipes", "Comunicação eficiente", "Resolução de conflitos", "Garantia de qualidade"],
                ImagemPrincipalCard = "/img/products/coordenacao/cc2.jpg",
                ImagemGrandeModal = "/img/products/coordenacao/cc2.jpg",
                ImagensPequenasModal = ["/img/products/coordenacao/cc1.jpg"],
                },

                new ServiceViewModel
                {
                    Id = 306,
                Category = "Cerimonial",
                Titulo = "Produção",
                DescricaoBreve = "Criação e desenvolvimento do evento",
                SubtituloModal = "Produção completa do evento, desde a concepção criativa até a execução final.",
                ItensInclusos = ["Concepção criativa", "Desenvolvimento do conceito", "Produção de materiais", "Coordenação artística", "Execução final"],
                ImagemPrincipalCard = "/img/products/producao/ppp1.jpeg",
                ImagemGrandeModal = "/img/products/producao/ppp1.jpeg",
                ImagensPequenasModal = ["/img/products/producao/ppp2.png"],
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
                DescricaoBreve = "Atendimento profissional e eficiente",
                SubtituloModal = "Equipe de garçons treinados e experientes para garantir um atendimento de excelência durante todo o evento.",
                ItensInclusos = ["Garçons profissionais treinados", "Atendimento personalizado", ""],
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