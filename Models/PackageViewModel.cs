namespace ChicasEventos.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        public string Categoria { get; set; } 
        public string Nome { get; set; } 
        public string PrecoPorPessoa { get; set; } 
        public string Descricao { get; set; } 
        public List<string> ItensInclusos { get; set; }
        public string ImagemPrincipal { get; set; }
        public List<string> ImagensPequenas { get; set; }
    }
}