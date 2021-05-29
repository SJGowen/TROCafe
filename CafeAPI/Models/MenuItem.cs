using System.ComponentModel.DataAnnotations;

namespace CafeAPI.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SKU { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
