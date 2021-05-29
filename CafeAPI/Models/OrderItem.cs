using System.ComponentModel.DataAnnotations;

namespace CafeAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SKU { get; set; }
    }
}
