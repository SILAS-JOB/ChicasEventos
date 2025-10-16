namespace ChicasEventos.Models
{
    public class ServicoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<string> ItensInclusos { get; set; }
        // Essencial para o carrossel!
        public List<string> ImagensCarousel { get; set; } 
    }
}