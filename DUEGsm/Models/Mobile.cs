namespace DUEGsm.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        //Márka mint samsung/apple
        public string? Brand { get; set; }
        //Model mint galaxy s24/iphone 15
        public string Modell { get; set; }
        public string Color { get; set; }
        public string OperatingSystem { get; set; }
        public string Screen { get; set; }
        public string Processor { get; set; }
        public string FrontCamera { get; set; }
        public string BackCamera { get; set; }
        public int Storage { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        //Majd még a képet hozzáadom/hozzáadjuk később
    }
}
