using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TravelGuide.Models;

namespace TravelGuide.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Проверяем только города, так как достопримечательности добавляются вместе с ними
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>
            {
                new City
                {
                    Name = "Москва",
                    Region = "Центральный федеральный округ",
                    Population = 12655050,
                    History = "Москва — столица России, город федерального значения...",
                    ImagePath = "/images/moscow.jpg",
                    CoatOfArmsPath = "/images/moscow_coat.jpeg",
                    Attractions = new List<Attraction>
                    {
                        new Attraction
                        {
                            Name = "Красная площадь",
                            Description = "Главная площадь Москвы...",
                            History = "Красная площадь появилась в конце XV века...",
                            ImagePath = "/images/red_square.jpg",
                            WorkingHours = "Круглосуточно",
                            EntranceFee = 0,
                            // Явно указываем связь
                            CityId = 1 // Должен соответствовать ID города
                        },
                        new Attraction
                        {
                            Name = "Останкинская телебашня",
                            Description = "Телевизионная и радиовещательная башня...",
                            History = "Строительство башни было завершено в 1967 году...",
                            ImagePath = "/images/ostankino.jpg",
                            WorkingHours = "10:00-22:00",
                            EntranceFee = 1800,
                            CityId = 1
                        }
                    }
                },
                new City
                {
                    Name = "Санкт-Петербург",
                    Region = "Северо-Западный федеральный округ",
                    Population = 5398000,
                    History = "Санкт-Петербург был основан 27 мая 1703 года...",
                    ImagePath = "https://example.com/spb.jpg",
                    CoatOfArmsPath = "https://example.com/spb_coat.png",
                    Attractions = new List<Attraction>
                    {
                        new Attraction
                        {
                            Name = "Эрмитаж",
                            Description = "Один из крупнейших и самых старых музеев мира...",
                            History = "Основан в 1764 году Екатериной II...",
                            ImagePath = "https://example.com/hermitage.jpg",
                            WorkingHours = "10:30-18:00, выходной - понедельник",
                            EntranceFee = 800,
                            CityId = 2
                        }
                    }
                }
            };

            // Отключаем отслеживание для избежания конфликтов
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            // Добавляем данные
            context.Cities.AddRange(cities);
            
            // Сохраняем изменения
            context.SaveChanges();
            
            // Восстанавливаем стандартное поведение отслеживания
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }
    }
}