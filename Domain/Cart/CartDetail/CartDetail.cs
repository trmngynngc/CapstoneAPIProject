namespace Domain.Cart;

public class CartDetail
{
    public string CartId { get; set; }
    public Cart Cart { get; set; }

    public Guid ProductId { get; set; }
    public Product.Product Product{ get; set; }

    public int Quantity { get; set; }
}
