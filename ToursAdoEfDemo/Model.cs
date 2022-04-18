using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToursAdoEfDemo
{
    public class DepartureCity
    {
        public int DepartureCityID;
        public string DepartureCityName;
    }

    public class Country
    {
        public int CountryID;
        public string CountryName;
    }

    public class Tour
    {
        public int TourID;
        public Decimal Price;
        public int NumberOfDays;
        public DepartureCity DepartureCity;
        public Country Country;
    }

    public class Database
    {
        public List<DepartureCity> DepartureCities;
        public List<Country> Countries;
        public List<Tour> Tours;

        public Database()
        {
            DepartureCities = new List<DepartureCity>
            {
                new DepartureCity {DepartureCityID = 832, DepartureCityName = "Moscow"},
                new DepartureCity {DepartureCityID = 1266, DepartureCityName = "Kazan"},
                new DepartureCity {DepartureCityID = 1264, DepartureCityName = "Saint Petersburg"},
            };

            Countries = new List<Country>
            {
                new Country {CountryID = 139, CountryName = "Japan"},
                new Country {CountryID = 50, CountryName = "Spain"},
                new Country {CountryID = 2, CountryName = "Australia"},
                new Country {CountryID = 59, CountryName = "China"},
            };

            Tours = new List<Tour>
            {
                new Tour {TourID = 1, Price = 150000, NumberOfDays = 7, DepartureCity = DepartureCities[0], Country = Countries[0]},
                new Tour {TourID = 2, Price = 160000, NumberOfDays = 8, DepartureCity = DepartureCities[1], Country = Countries[0]},
                new Tour {TourID = 3, Price = 155000, NumberOfDays = 11, DepartureCity = DepartureCities[2], Country = Countries[0]},
                new Tour {TourID = 4, Price = 84000, NumberOfDays = 14, DepartureCity = DepartureCities[0], Country = Countries[1]},
                new Tour {TourID = 5, Price = 85000, NumberOfDays = 24, DepartureCity = DepartureCities[1], Country = Countries[1]},
                new Tour {TourID = 6, Price = 86000, NumberOfDays = 20, DepartureCity = DepartureCities[2], Country = Countries[1]},
                new Tour {TourID = 7, Price = 250000, NumberOfDays = 9, DepartureCity = DepartureCities[0], Country = Countries[2]},
                new Tour {TourID = 8, Price = 240000, NumberOfDays = 11, DepartureCity = DepartureCities[1], Country = Countries[2]},
                new Tour {TourID = 9, Price = 260000, NumberOfDays = 12, DepartureCity = DepartureCities[2], Country = Countries[2]},
                new Tour {TourID = 10, Price = 130000, NumberOfDays = 11, DepartureCity = DepartureCities[0], Country = Countries[3]},
            };
        }
    }
}
