using System;
using System.Collections.Generic;

namespace asm.Models
{
    public partial class Combo
    {
        public Combo()
        {
            ComboDetails = new HashSet<ComboDetail>();
        }

        public int ComboId { get; set; }
        public string ComboName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
    }
}
