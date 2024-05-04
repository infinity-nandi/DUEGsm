using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUEGsm.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public string? Status { get; set; }
        public DateTime? OrderDate { get; set; }

        public List<OrderProduct>? OrderProducts { get; set; }
        public List<Mobile>? Mobiles { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
