using DUEGsm.Data;
using Microsoft.EntityFrameworkCore;

namespace DUEGsm.Models.seedData
{
    public static class seedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Mobiles.Any())
                {
                    return;   // DB has been seeded
                }
                context.Mobiles.AddRange(
                    new Mobile
                    {
                        Brand = "Apple",
                        Modell = "Iphone 14",
                        Color = "Lila",
                        OperatingSystem = "iOS",
                        Screen = "OLED 1920x1080",
                        Processor = "Valami",
                        FrontCamera = "14px",
                        BackCamera = "28",
                        Stroage = 124,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In mollis nunc sed id. Praesent semper feugiat nibh sed pulvinar proin gravida hendrerit lectus. Ac placerat vestibulum lectus mauris. Pulvinar mattis nunc sed blandit libero. Nec feugiat in fermentum posuere urna nec. Donec pretium vulputate sapien nec sagittis aliquam malesuada bibendum. Leo urna molestie at elementum. Ultrices vitae auctor eu augue. Morbi quis commodo odio aenean sed adipiscing diam donec adipiscing. Ut consequat semper viverra nam libero justo laoreet sit amet. Sed pulvinar proin gravida hendrerit lectus a. Tristique magna sit amet purus gravida quis blandit. Et tortor consequat id porta nibh venenatis cras sed. Neque sodales ut etiam sit amet. Eget nulla facilisi etiam dignissim diam quis enim. In ornare quam viverra orci sagittis.",
                        Price = 300000,
                        UploadDate = DateTime.Parse("2023-7-10"),

                    },
                    new Mobile
                    {
                        Brand = "Apple",
                        Modell = "iphone 12",
                        Color = "Kék",
                        OperatingSystem = "iOS",
                        Screen = "OLED 1920x1080",
                        Processor = "Valami",
                        FrontCamera = "14px",
                        BackCamera = "28",
                        Stroage = 124,
                        Description = "Description",
                        Price = 250000,
                        UploadDate = DateTime.Parse("2023-7-10"),

                    },
                    new Mobile
                    {
                        Brand = "Samsung",
                        Modell = "galaxy s24",
                        Color = "Kék",
                        OperatingSystem = "Android",
                        Screen = "OLED 1920x1080",
                        Processor = "Valami",
                        FrontCamera = "14px",
                        BackCamera = "28",
                        Stroage = 256,
                        Description = "Description",
                        Price = 450000,
                        UploadDate = DateTime.Parse("2023-7-10"),

                    },
                    new Mobile
                    {
                        Brand = "Apple",
                        Modell = "Iphone XS",
                        Color = "Piros",
                        OperatingSystem = "iOS",
                        Screen = "OLED 1920x1080",
                        Processor = "Valami",
                        FrontCamera = "14px",
                        BackCamera = "28",
                        Stroage = 124,
                        Description = "Description",
                        Price = 250000,
                        UploadDate = DateTime.Parse("2023-7-10"),

                    },
                    new Mobile
                    {
                        Brand = "Samsung",
                        Modell = "A51",
                        Color = "Kék",
                        OperatingSystem = "Android",
                        Screen = "OLED 1920x1080",
                        Processor = "Valami",
                        FrontCamera = "14px",
                        BackCamera = "28",
                        Stroage = 124,
                        Description = "Description",
                        Price = 250000,
                        UploadDate = DateTime.Parse("2023-7-10"),

                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
