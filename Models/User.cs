using System;
using System.Collections.Generic;

namespace asm.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
