using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToursAdoEfDemo.Ef
{
    class ToursContext : DbContext
    {

        public DbSet<DepartureCity> DepartureCities { get; set; }

        //public class Country
        //{
        //    public int CountryID;
        //    public string CountryName;
        //}

        //public class Tour
        //{
        //    public int TourID;
        //    public Decimal Price;
        //    public int NumberOfDays;
        //    public DepartureCity DepartureCity;
        //    public Country Country;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database = ToursEF; Trusted_Connection = True;");
            base.OnConfiguring(optionsBuilder);
        }

        public void CreateDbIfExist()
        {
            this.Database.EnsureCreated();
        }
    }

    public class DepartureCity
    {
        public int DepartureCityID; { get; set; }
        public string DepartureCityName; { get; set; }
    }
}
