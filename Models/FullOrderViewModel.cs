using ChicasEventos.Models;

public class FullOrderViewModel
{
    public OrderFormViewModel FormData { get; set; }
    public List<CartItemRequest> CartItems { get; set; } // Reutilizando a classe que já criamos
}