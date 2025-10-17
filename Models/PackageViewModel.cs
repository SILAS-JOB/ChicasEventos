namespace ChicasEventos.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        public string Categoria { get; set; } // "Buffet", "Audiovisual", etc.
        public string Nome { get; set; } // "Pacote bronze"
        public string PrecoPorPessoa { get; set; } // "A partir de R$ 89/pessoa"
        public string Descricao { get; set; } // "Perfeita para eventos corporativos..."
        public List<string> ItensInclusos { get; set; }
        public string ImagemPrincipal { get; set; }
        public List<string> ImagensPequenas { get; set; }
    }
}