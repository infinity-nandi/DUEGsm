using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUEGsm.Models
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Mobile))]
        public int ProductID { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }

        public Mobile? Mobiles { get; set; }
        public Order? Order { get; set; }
    }
}
