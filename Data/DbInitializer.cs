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
                    CoatOfArmsPath = "/images/moscow_coat.png",
                    Attractions = new List<Attraction>
                    {
                        new Attraction
                        {
                            Name = "Красная площадь",
                            Description = "Главная площадь Москвы...",
                            History = "Красная площадь появилась в конце XV века...",
                            ImagePath = "/images/reg_square.jpg",
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
                    ImagePath = "/images/spb.jpg",
                    CoatOfArmsPath = "/images/spb_coat.png",
                    Attractions = new List<Attraction>
                    {
                        new Attraction
                        {
                            Name = "Эрмитаж",
                            Description = "Один из крупнейших и самых старых музеев мира...",
                            History = "Основан в 1764 году Екатериной II...",
                            ImagePath = "/images/hermitage.jpg",
                            WorkingHours = "10:30-18:00, выходной - понедельник",
                            EntranceFee = 800,
                            CityId = 2
                        }
                    }
                },
        new City
        {
            Name = "Мурманск",
            Region = "Город на северо-западе России",
            Population = 264339,
            History = "16 апреля 1915 года, во время Первой мировой войны, на восточном берегу Кольского залива Баренцева моря был основан Мурманский морской порт ",
            ImagePath = "/images/ekb.jpg",
            CoatOfArmsPath = "/images/ekb_coat.png",
            Attractions = new List<Attraction>
            {
                new Attraction
                {
                    Name = "Мемориал «Защитникам Советского Заполярья в годы Великой Отечественной войны»",
                    Description = "Мемориальный комплекс в Ленинском округе города Мурманска.",
                    History = "Памятник был заложен 10 октября 1969 года, а к его возведению приступили в мае 1974 года",
                    ImagePath = "/images/plotinka.jpg",
                    WorkingHours = "Круглосуточно",
                    EntranceFee = 0
                },
                new Attraction
                {
                    Name = "Арктика",
                    Description = "18-этажное здание(гостиница) в центре Мурманска. Визитная карточка города и самое высокое общественное здание за полярным кругом",
                    History = "Гостиница «Арктика» появилась в столице Мурманской области в 1933 году.",
                    ImagePath = "/images/xnk.jpg",
                    WorkingHours = "Круглосуточно",
                    EntranceFee = 1500
                },
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