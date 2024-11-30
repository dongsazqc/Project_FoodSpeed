using System;
using System.Collections.Generic;

namespace asm.Models
{
    public partial class Product
    {
        public Product()
        {
            ComboDetails = new HashSet<ComboDetail>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? StockQuantity { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
