namespace asm.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
        public string ImageUrl { get; set; }

    }
}
