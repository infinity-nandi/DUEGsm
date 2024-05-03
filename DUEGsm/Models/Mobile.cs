using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUEGsm.Models
{
    public class Mobile
    {
        [Key]
        public int Id { get; set; }
        //Márka mint samsung/apple
        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Márka")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [MaxLength(60)]
        [Display(Name = "Modell")]
        //Model mint galaxy s25/iphone 15
        public string Modell { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Szín")]
        public string Color { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Operációs rendszer")]
        public string OperatingSystem { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Képernyő")]
        public string Screen { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Processzor")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Első kamera")]
        public string FrontCamera { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Hátsó kamera")]
        public string BackCamera { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Tárhely")]
        public int Stroage { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Leírás")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Ár")]
        public int Price { get; set; }

        [Required(ErrorMessage = "A mező nem lehet üres!")]
        [Display(Name = "Feltőltési dátum")]
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }

        [Display(Name = "Kép")]
        public byte[]? Image { get; set; }

        public List<OrderProduct>? OrderProducts { get; set; }

        public ICollection<ProductPicture>? ProductPictures { get; set; }

        [NotMapped]
        public List<IFormFile> PictureFiles { get; set; } = new List<IFormFile>();

        //Majd még a képet hozzáadom/hozzáadjuk később
    }
}
