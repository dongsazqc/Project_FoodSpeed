using System;
using System.Collections.Generic;

namespace asm.Models
{
    public partial class ComboDetail
    {
        public int ComboDetailId { get; set; }
        public int ComboId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Combo Combo { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
