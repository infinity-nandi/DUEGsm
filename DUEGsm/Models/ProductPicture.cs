using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUEGsm.Models
{
    public class ProductPicture
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Mobile))]
        public int ProductID { get; set; }
        public byte[] Picture { get; set; }

        [NotMapped]
        public string Image
        {
            get
            {
                var base64 = Convert.ToBase64String(Picture);
                return String.Format("data:image/jpg;base64,{0}", base64);
            }
        }
    }
}
