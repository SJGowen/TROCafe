using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeAPI.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Probability to replace the integer OrderId with a GUID, 
        // that way no chance of getting duplicate OrderID's
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SKU { get; set; }
    }
}
