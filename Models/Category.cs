using System;
using System.Collections.Generic;

namespace asm.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
