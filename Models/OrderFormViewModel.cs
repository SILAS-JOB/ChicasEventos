using System.ComponentModel.DataAnnotations;

public class OrderFormViewModel
{
    [Required] public string Nome { get; set; }
    [Required] public string Telefone { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    public string NomeEvento { get; set; }
    public DateTime? DataEvento { get; set; }
    public int? NumeroConvidados { get; set; }
    public string LocalEvento { get; set; }
    public string Observacoes { get; set; }
}