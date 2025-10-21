namespace ChicasEventos.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Titulo { get; set; }
        public string DescricaoBreve { get; set; } 
        public string SubtituloModal { get; set; } 
        public string DescricaoCompleta { get; set; } 
        public List<string> ItensInclusos { get; set; }
        public string ImagemPrincipalCard { get; set; } 
        public string ImagemGrandeModal { get; set; } 
        public List<string> ImagensPequenasModal { get; set; } 
}
}