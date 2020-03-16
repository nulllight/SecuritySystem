using SecureSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureSystem.Logic
{
    public static class DataInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Видеокамера 8pf99",
                        Discription = "Оптическое приближение, 4k",
                        Price = 20000,
                        Specifications = "Предназначена для слежки за помещением"
                    },
                    new Product
                    {
                        Name = "Видеокамера 99pf100",
                        Discription = "Оптическое приближение, съемка в темноте",
                        Price = 40000,
                        Specifications = "Предназначена для слежки на улице"
                    },
                    new Product
                    {
                        Name = "Датчик движения ggEr66emy",
                        Discription = "Дальность обнаружения 10 метров",
                        Price = 60000,
                        Specifications = "Предназначен для помещений"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

