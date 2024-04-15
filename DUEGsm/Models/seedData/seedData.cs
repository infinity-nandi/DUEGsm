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
                        Description = "Description",
                        Price = 300000

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
                        Price = 250000

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
                        Price = 450000

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
                        Price = 250000

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
                        Price = 250000

                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
