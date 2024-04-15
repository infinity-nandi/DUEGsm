using Microsoft.AspNetCore.Mvc.Rendering;

namespace DUEGsm.Models
{
    public class MobilViewModel
    {
        public List<Mobile>? Mobile { get; set; }
        public SelectList? Modell { get; set; }
        public SelectList? Brand { get; set; }
        public SelectList? Order { get; set; }
        public string? ProductModel { get; set; }
        public string? ProductBrand { get; set; }
        public string? SearchString { get; set; }
        public int? OrderValue { get; set; }
    }
}
