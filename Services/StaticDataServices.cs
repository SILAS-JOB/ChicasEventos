using ChicasEventos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChicasEventos.Services
{
    public class StaticDataService
    {
        private readonly List<ServiceViewModel> _allServices;
        private readonly List<PackageViewModel> _allPackages;
        private readonly List<StaffingServiceViewModel> _allStaffingServices;
        public StaticDataService()
        {
            _allServices = new List<ServiceViewModel>();
            _allServices.AddRange(GetBuffetData());
            _allServices.AddRange(GetAudiovisualData());
            _allServices.AddRange(GetCerimonialData());
            _allServices.AddRange(GetRhData());


            _allPackages = new List<PackageViewModel>();
            _allPackages.AddRange(GetBuffetPackages());

            _allStaffingServices = new List<StaffingServiceViewModel>();
            _allStaffingServices.AddRange(GetRhData_Staffing());
            _allStaffingServices.AddRange(GetAudiovisualData_Staffing());
            _allStaffingServices.AddRange(GetCerimonialData_Staffing());


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
                    ImagemPrincipal = "/img/products/brunch/bb1.jpeg",
                    ImagensPequenas = ["/img/products/brunch/bb3.jpg","/img/products/brunch/bb4.jpg"],
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

        private List<ServiceViewModel> GetAudiovisualData()
        {
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

        private List<ServiceViewModel> GetCerimonialData()
        {
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
        private List<ServiceViewModel> GetRhData()
        { /* ... 6 itens ... */
            return new List<ServiceViewModel>
            {
                new ServiceViewModel {
                Id = 401,
                Category = "RH",
                Titulo = "Garçons",
                DescricaoBreve = "Atendimento profissional e eficiente",
                SubtituloModal = "Equipe de garçons treinados e experientes para garantir um atendimento de excelência durante todo o evento.",
                ItensInclusos = ["GarÃ§ons profissionais treinados", "Atendimento personalizado", ""],
                ImagemPrincipalCard = "/img/products/garçom/gg1.jpg",
                ImagemGrandeModal = "/img/products/garçom/gg1.jpg",
                ImagensPequenasModal = ["/img/products/garçom/gg3.jpg", "/img/products/garçom/gg4.jpeg"] },

                new ServiceViewModel
                {
                    Id = 402,
                Category = "RH",
                Titulo = "Recepção",
                DescricaoBreve = "Boas-vindas e orientação aos convidados",
                SubtituloModal = "Equipe de recepção para dar as boas-vindas aos convidados, orientar sobre o evento e garantir uma experiência acolhedora.",
                ItensInclusos = ["Recepcionistas treinadas", "Boas-vindas personalizadas", "Orientação sobre o evento", "Controle de acesso", "Atendimento cordial"],
                ImagemPrincipalCard = "/img/products/recepção/rr3.jpg",
                ImagemGrandeModal = "/img/products/recepção/rr3.jpg",
                ImagensPequenasModal = ["/img/products/recepção/rr4.jpg", "/img/products/recepção/rr1.jpeg"],
                },

                new ServiceViewModel
                {
                    Id = 403,
                Category = "RH",
                Titulo = "Segurança",
                DescricaoBreve = "Proteção e controle de acesso",
                SubtituloModal = "Equipe de segurança especializada para garantir a proteÃ§Ã£o dos convidados e controle de acesso ao evento.",
                ItensInclusos = ["Seguranças profissionais", "Controle de acesso", "Monitoramento do evento", "Proteção dos convidados", "Protocolos de seguranÃ§a"],
                ImagemPrincipalCard = "/img/products/segurança/ss4.jpg",
                ImagemGrandeModal = "/img/products/segurança/ss4.jpg",
                ImagensPequenasModal = ["/img/products/segurança/ss3.png", "/img/products/segurança/ss2.png"],
                },

                new ServiceViewModel
                {
                    Id = 404,
                Category = "RH",
                Titulo = "Apoio Operacional",
                DescricaoBreve = "Suporte logí­stico completo",
                SubtituloModal = "Equipe de apoio para todas as necessidades operacionais do evento, garantindo que tudo funcione perfeitamente.",
                ItensInclusos = ["Suporte logí­stico completo", "Resolução de problemas", "Apoio aos fornecedores", "Coordenação de atividades", "Disponibilidade total"],
                ImagemPrincipalCard = "/img/products/operacional/oo3.png",
                ImagemGrandeModal = "/img/products/operacional/oo3.png",
                ImagensPequenasModal = ["/img/products/operacional/oo1.png", "/img/products/operacional/oo2.jpeg"],
                },

                new ServiceViewModel
                {
                    Id = 405,
                Category = "RH",
                Titulo = "Coordenação",
                DescricaoBreve = "Gestão completa do evento",
                SubtituloModal = "Coordenação geral de todos os aspectos do evento, garantindo harmonia entre todos os serviços.",
                ItensInclusos = ["Coordenação geral", "Gestão de equipes", "Comunicação eficiente", "ResoluÃ§Ã£o de conflitos", "Garantia de qualidade"],
                ImagemPrincipalCard = "/img/products/coordenacao/cc1.jpg",
                ImagemGrandeModal = "/img/products/coordenacao/cc1.jpg",
                ImagensPequenasModal = ["/img/products/coordenacao/cc2.jpg"],
                },

                new ServiceViewModel
                {
                    Id = 406,
                Category = "RH",
                Titulo = "Briefing",
                DescricaoBreve = "Orientação prévia da equipe",
                SubtituloModal = "Sessão de orientação prévia com toda a equipe para alinhar expectativas e garantir execução perfeita.",
                ItensInclusos = ["Orientação prévia completa", "Alinhamento de expectativas", "Treinamento especí­fico", "Comunicação de diretrizes", "Preparação da equipe"],
                ImagemPrincipalCard = "/img/products/briefing/bb1.jpeg",
                ImagemGrandeModal = "/img/products/briefing/bb1.jpeg",
                ImagensPequenasModal = ["/img/products/briefing/bb2.jpg"],
                }
            
            };
        }
                public List<StaffingServiceViewModel> GetStaffingServicesByCategory(string category)
        {
            return _allStaffingServices.Where(s => s.Category.Equals(category, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public StaffingServiceViewModel GetStaffingServiceById(int id)
        {
            return _allStaffingServices.FirstOrDefault(s => s.Id == id);
        }
        private List<StaffingServiceViewModel> GetAudiovisualData_Staffing()
        {
            return new List<StaffingServiceViewModel>
            {
                new StaffingServiceViewModel {
                Id = 701, Category = "Audiovisual", Title = "Fotógrafo", Description = "Cobertura fotográfica profissional",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 801, Label = "2h - R$ 600", Price = 600.00m },
                    new PricingOptionViewModel { Id = 802, Label = "4h - R$ 1000", Price = 1000.00m },
                    new PricingOptionViewModel { Id = 803, Label = "6h - R$ 1300", Price = 1300.00m },
                    new PricingOptionViewModel { Id = 804, Label = "Acima de 6h - A combinar", Price = 0}
                }
            },
                new StaffingServiceViewModel {
                Id = 702, Category = "Audiovisual", Title = "Social Media", Description = "Conteúdo para redes sociais",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 805, Label = "2h - R$ 400", Price = 400.00m },
                    new PricingOptionViewModel { Id = 806, Label = "4h - R$ 700", Price = 700.00m },
                    new PricingOptionViewModel { Id = 807, Label = "6h - R$ 950", Price = 950.00m },
                    new PricingOptionViewModel { Id = 808, Label = "Acima de 6h - A combinar", Price = 0}
                }
            },
                new StaffingServiceViewModel {
                Id = 703, Category = "Audiovisual", Title = "Operador de Drone", Description = "Imagens aéreas com drone",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 809, Label = "2h - R$ 700", Price = 700.00m },
                    new PricingOptionViewModel { Id = 810, Label = "4h - R$ 1250", Price = 1250.00m },
                    new PricingOptionViewModel { Id = 811, Label = "6h - R$ 1600", Price = 1600.00m },
                    new PricingOptionViewModel { Id = 812, Label = "Acima de 4h - A combinar", Price = 0}
                }
            },
                 new StaffingServiceViewModel {
                Id = 704, Category = "Audiovisual", Title = "Video", Description = "Filmagem e edição profissional",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 813, Label = "Até 2h - R$ 700", Price = 700.00m },
                    new PricingOptionViewModel { Id = 814, Label = "Até 4h - R$ 1300", Price = 1300.00m },
                    new PricingOptionViewModel { Id = 815, Label = "Até 6h - R$ 1800", Price = 1800.00m },
                    new PricingOptionViewModel { Id = 11815, Label = "Acima de 6h - A combinar", Price = 0 }
                }
            },
                new StaffingServiceViewModel {
                Id = 705, Category = "Audiovisual", Title = "Cobertura ao Vivo", Description = "Transmissão ao vivo do evento",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 816, Label = "Até 2h - R$ 700", Price = 700.00m },
                    new PricingOptionViewModel { Id = 817, Label = "Até 4h - R$ 1200", Price = 1200.00m },
                    new PricingOptionViewModel { Id = 818, Label = "Até 6h - R$ 1700", Price = 1700.00m },
                    new PricingOptionViewModel { Id = 11818, Label = "Acima de 6h - A combinar", Price = 0 }
                }
            },
                new StaffingServiceViewModel {
                Id = 706, Category = "Audiovisual", Title = "Editor de Vídeo", Description = "Edição e pós-produção de vídeos",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 11816, Label = "Até 2h - R$ 700", Price = 700.00m },
                    new PricingOptionViewModel { Id = 11817, Label = "Até 4h - R$ 1200", Price = 1200.00m },
                    new PricingOptionViewModel { Id = 11818, Label = "Até 6h - R$ 1700", Price = 1700.00m },
                    new PricingOptionViewModel { Id = 11819, Label = "Acima de 6h - A combinar", Price = 0 }
                }
            },
            };
        }

        private List<StaffingServiceViewModel> GetRhData_Staffing()
        {
            return new List<StaffingServiceViewModel>
            {
                new StaffingServiceViewModel {
                Id = 707, Category = "RH", Title = "Garçom", Description = "Atendimento profissional e especializado",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 821, Label = "2h - R$ 70", Price = 70.00m },
                    new PricingOptionViewModel { Id = 822, Label = "4h - R$ 120", Price = 120.00m },
                    new PricingOptionViewModel { Id = 823, Label = "6h - R$ 160", Price = 160.00m },
                    new PricingOptionViewModel { Id = 824, Label = "Acima de 6h - A combinar", Price = 0}
                }
            },
                new StaffingServiceViewModel {
                Id = 708, Category = "RH", Title = "Recepcionista", Description = "Boas-vindas e orientação aos convidados",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 825, Label = "2h - R$ 90", Price = 90.00m },
                    new PricingOptionViewModel { Id = 826, Label = "4h - R$ 160", Price = 160.00m },
                    new PricingOptionViewModel { Id = 827, Label = "6h - R$ 220", Price = 220.00m },
                    new PricingOptionViewModel { Id = 828, Label = "Acima de 6h - A combinar", Price = 0}
                }
            },
                new StaffingServiceViewModel {
                Id = 709, Category = "RH", Title = "Segurança", Description = "Proteção e controle de acesso",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 829, Label = "2h - R$ 100", Price = 100.00m },
                    new PricingOptionViewModel { Id = 830, Label = "4h - R$ 180", Price = 180.00m },
                    new PricingOptionViewModel { Id = 831, Label = "6h - R$ 250", Price = 250.00m },
                    new PricingOptionViewModel { Id = 832, Label = "Acima de 6h - A combinar", Price = 0}
                }
            },
                new StaffingServiceViewModel {
                Id = 710, Category = "RH", Title = "Apoio Operacional", Description = "Suporte logístico completo",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 833, Label = "2h - R$ 100", Price = 100.00m },
                    new PricingOptionViewModel { Id = 834, Label = "4h - R$ 150", Price = 150.00m },
                    new PricingOptionViewModel { Id = 835, Label = "6h - R$ 200", Price = 200.00m },
                    new PricingOptionViewModel { Id = 836, Label = "Acima de 6h - A combinar", Price = 0}
                }
            },
                new StaffingServiceViewModel {
                Id = 711, Category = "RH", Title = "Briefing", Description = "Orientação e prévia da equipe",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 837, Label = "2h - R$ 120", Price = 120.00m },
                    new PricingOptionViewModel { Id = 838, Label = "4h - R$ 220", Price = 220.00m },
                    new PricingOptionViewModel { Id = 839, Label = "6h - R$ 320", Price = 320.00m },
                }
            },
                new StaffingServiceViewModel {
                Id = 712, Category = "RH", Title = "Coordenação", Description = "Organização e limpeza da copa",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 840, Label = "2h - R$ 120", Price = 120.00m },
                    new PricingOptionViewModel { Id = 841, Label = "4h - R$ 220", Price = 220.00m },
                    new PricingOptionViewModel { Id = 842, Label = "6h - R$ 320", Price = 320.00m },
                }
            },
            };
        }
        
        private List<StaffingServiceViewModel> GetCerimonialData_Staffing() 
        { 
            return new List<StaffingServiceViewModel>
            {
                new StaffingServiceViewModel {
                Id = 714, Category = "Cerimonial", Title = "Planejamento", Description = "Estratégia completa do evento",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 844, Label = "R$ 1000", Price = 1000.00m },
                }
            },
                new StaffingServiceViewModel {
                Id = 715, Category = "Cerimonial", Title = "Cronograma", Description = "Timeline detalhada e organizada",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 848, Label = "R$ 700", Price = 700.00m },
                }
            },
                new StaffingServiceViewModel {
                Id = 716, Category = "Cerimonial", Title = "Fornecedor", Description = "Rede de parceiros confiáveis",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 852, Label = "$ 800", Price = 800.00m },
                }
            },
                new StaffingServiceViewModel {
                Id = 717, Category = "Cerimonial", Title = "Excecução", Description = "Coordenação do dia do evento",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 855, Label = "R$ 900", Price = 900.00m },
                }
            },
                new StaffingServiceViewModel {
                Id = 718, Category = "Cerimonial", Title = "Coordenação", Description = "Gestão completa do evento",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 856, Label = "R$ 800", Price = 800.00m },
                }
            },
                new StaffingServiceViewModel {
                Id = 719, Category = "Cerimonial", Title = "Produção", Description = "Criação e desenvolvimento do evento",
                PricingOptions = new List<PricingOptionViewModel> {
                    new PricingOptionViewModel { Id = 857, Label = "R$ 1200", Price = 1200.00m },
                }
            },
            }; 
        }
    }
}

