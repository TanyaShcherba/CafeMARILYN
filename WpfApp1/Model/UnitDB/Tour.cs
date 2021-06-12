using System;

namespace WpfApp1.Model.UnitDB
{
    public class Tour
    {
          public Tour()
        {
        }

        public Tour(double price, DateTime departureDate, int personCount, int daysCount, Country country, Hotel hotel,
            TourType tourType, Nutrition nutrition, Client client, Discount discount)
        {
            Price = price;
            DepartureDate = departureDate;
            PersonCount = personCount;
            DaysCount = daysCount;
            Country = country;
            IdCountry = country.Id;
            Hotel = hotel;
            IdHotel = hotel.Id;
            TourType = tourType;
            IdTourType = tourType.Id;
            Nutrition = nutrition;
            IdNutrition = nutrition.Id;
            Client = client;
            IdClient = client.Id;
            Discount = discount;
            IdDiscount = discount.Id;
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public int PersonCount { get; set; }
        public int DaysCount { get; set; }
        public Country Country { get; set; }
        public int IdCountry { get; set; }
        public Hotel Hotel { get; set; }
        public int IdHotel { get; set; }
        public TourType TourType { get; set; }
        public int IdTourType { get; set; }
        public Nutrition Nutrition { get; set; }
        public int IdNutrition { get; set; }
        public Client Client { get; set; }
        public int IdClient { get; set; }
        public Discount Discount { get; set; }
        public int IdDiscount { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Tour tour)
                return Price == tour.Price
                       && DepartureDate == tour.DepartureDate
                       && PersonCount == tour.PersonCount
                       && DaysCount == tour.DaysCount
                       && Country == tour.Country
                       && Hotel == tour.Hotel
                       && TourType == tour.TourType
                       && Nutrition == tour.Nutrition
                       && Client == tour.Client
                       && Discount == tour.Discount;

            return false;
        }
    }
}