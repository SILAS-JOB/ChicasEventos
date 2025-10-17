using ChicasEventos.Models;

public class FullOrderViewModel
{
    public OrderFormViewModel FormData { get; set; }
    public List<CartItemRequest> CartItems { get; set; } 
}