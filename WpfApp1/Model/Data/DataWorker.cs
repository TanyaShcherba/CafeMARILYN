using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp1.Model.UnitDB;

namespace WpfApp1.Model.Data
{
    public static class DataWorker
    {
        #region AddMethods

        //Add Client
        public static string AddNewClient(string fio, string passNum)
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Clients.Any(el => el.PassNum == passNum))
                {
                    var newClient = new Client { Fio = fio, PassNum = passNum };
                    db.Clients.Add(newClient);
                    db.SaveChangesAsync();
                    return "Клиент успешно добавлен";
                }

                return "Данный клиент уже существует";
            }
        }

        //Add County
        public static string AddNewCountry(string name)
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Countries.Any(el => el.Name == name))
                {
                    var newCountry = new Country { Name = name };
                    db.Countries.Add(newCountry);
                    db.SaveChangesAsync();
                    return "Страна успешно добавлена";
                }

                return "Данная страна уже существует";
            }
        }

        //Add Discount
        public static string AddNewDiscount(int discount)
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Discounts.Any(el => el.Percent == discount))
                {
                    var newDiscount = new Discount { Percent = discount };
                    db.Discounts.Add(newDiscount);
                    db.SaveChangesAsync();
                    return "Скидка успешно добавлена";
                }

                return "Данная скидка уже существует";
            }
        }

        //Add Hotel
        public static string AddNewHotel(string name, int hotelClass)
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Hotels.Any(el => el.Name == name))
                {
                    var newHotel = new Hotel { Name = name, Class = hotelClass };
                    db.Hotels.Add(newHotel);
                    db.SaveChangesAsync();
                    return "Отель успешно добавлена";
                }

                return "Данный отель уже существует";
            }
        }

        //Add Nutrition
        public static string AddNewNutrition(string name)
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Nutritions.Any(el => el.Name == name))
                {
                    var newNutrition = new Nutrition { Name = name };
                    db.Nutritions.Add(newNutrition);
                    db.SaveChangesAsync();
                    return "Тип питания успешно добавлена";
                }

                return "Данный тип питания уже существует";
            }
        }

        //Add Staff
        public static string AddNewStaff(string fio, double salary)
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Staves.Any(el => el.Fio == fio))
                {
                    var newStaff = new Staff { Fio = fio, Salary = salary };
                    db.Staves.Add(newStaff);
                    db.SaveChangesAsync();
                    return "Сотрудник успешно добавлена";
                }

                return "Cотрудник уже существует";
            }
        }

        //Add Tour type
        public static string AddNewTourType(string type)
        {
            using (var db = new ApplicationContext())
            {
                if (!db.TourTypes.Any(el => el.Type == type))
                {
                    var newTourType = new TourType { Type = type };
                    db.TourTypes.Add(newTourType);
                    db.SaveChangesAsync();
                    return "Тип тура успешно добавлена";
                }

                return "Данный тип тура уже существует";
            }
        }

        //Add Tour
        public static string AddNewTour(double price, DateTime departureTime, int personCount, int daysCount,
            Country country, Hotel hotel, TourType tourType, Nutrition nutrition, Client client, Discount discount)
        {
            using (var db = new ApplicationContext())
            {
                var newTour = new Tour(price, departureTime, personCount, daysCount, country, hotel, tourType,
                    nutrition, client, discount);
                if (db.Tours.Any(el => el.Equals(newTour)))
                {
                    db.Tours.Add(newTour);
                    db.SaveChangesAsync();
                    return "Тур успешно добавлен";
                }

                return $"Данный тур уже существует";
            }
        }

        #endregion

        #region RemoveMethods

        //Remove Client
        public static string DeleteClient(Client client)
        {
            using (var db = new ApplicationContext())
            {
                db.Clients.Remove(client);
                db.SaveChangesAsync();
                return $"Клиент {client.Fio} удалён";
            }
        }

        //Remove Country
        public static string DeleteCountry(Country country)
        {
            using (var db = new ApplicationContext())
            {
                db.Countries.Remove(country);
                db.SaveChangesAsync();
                return $"Страна {country.Name} удалена";
            }
        }

        //Remove Discount
        public static string DeleteDiscount(Discount discount)
        {
            using (var db = new ApplicationContext())
            {
                db.Discounts.Remove(discount);
                db.SaveChangesAsync();
                return $"Скидка в {discount.Percent}% удалена";
            }
        }

        //Remove Hotel
        public static string DeleteHotel(Hotel hotel)
        {
            using (var db = new ApplicationContext())
            {
                db.Hotels.Remove(hotel);
                db.SaveChangesAsync();
                return $"Отель {hotel.Name}";
            }
        }

        //Remove Nutrition
        public static string DeleteNutrition(Nutrition nutrition)
        {
            using (var db = new ApplicationContext())
            {
                db.Nutritions.Remove(nutrition);
                db.SaveChangesAsync();
                return $"Питание {nutrition.Name} удалено";
            }
        }

        //Remove Staff
        public static string DeleteStaff(Staff staff)
        {
            using (var db = new ApplicationContext())
            {
                db.Staves.Remove(staff);
                db.SaveChangesAsync();
                return $"Сотрудник {staff.Fio} удалён";
            }
        }

        //Remove TourType
        public static string DeleteToutType(TourType type)
        {
            using (var db = new ApplicationContext())
            {
                db.TourTypes.Remove(type);
                db.SaveChangesAsync();
                return $"Тип тура {type.Type} удалён";
            }
        }

        //Remove Tour
        public static string DeleteTour(Tour tour)
        {
            using (var db = new ApplicationContext())
            {
                db.Tours.Remove(tour);
                db.SaveChangesAsync();
                return $"Запись тура под номером {tour.Id} удалена";
            }
        }

        #endregion

        #region GetMethods

        public static List<Client> GetAllClients()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Clients.ToList();
            }
        }

        public static List<Country> GetAllCountries()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Countries.ToList();
            }
        }

        public static List<Hotel> GetAllHotels()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Hotels.ToList();
            }
        }

        public static List<Discount> GetAlDiscounts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Discounts.ToList();
            }
        }

        public static List<Nutrition> GetAllNutritions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Nutritions.ToList();
            }
        }

        public static List<Staff> GetAllStaves()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Staves.ToList();
            }
        }

        public static List<TourType> GetAllTourTypes()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.TourTypes.ToList();
            }
        }

        public static List<Tour> GetAllTours()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Tours.ToList();
            }
        }

        #endregion
    }
}