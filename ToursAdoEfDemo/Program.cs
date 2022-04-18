using System;
using System.Data.SqlClient;
using System.Linq;
using ToursAdoEfDemo.Ef;

namespace System.Data.Objects { }
namespace ToursAdoEfDemo

{
    class Program
    {

        static void AdoNetDemo()
        {
            var connection = new SqlConnection(@"Server=.\SQLEXPRESS; Database = Tours; Trusted_Connection = True;");
            connection.Open();

            //var command = connection.CreateCommand();
            //command.CommandText = "SELECT TourID, Price FROM Tours ORDER BY Price DESC";
            //var reader = command.ExecuteReader();
            //Console.WriteLine("1) Вывести список туров, отсортированных по убыванию стоимости");
            //while (reader.Read())
            //{
            //    Console.WriteLine($"TourID={reader.GetInt32(reader.GetOrdinal("TourID"))} Price={ reader.GetInt32(reader.GetOrdinal("Price"))}");
            //}
            //reader.Close();

            //var command1 = connection.CreateCommand();
            //command1.CommandText = "SELECT TourID, Price, NumberOfDays FROM Tours ORDER BY Price/NumberOfDays ASC";
            //var reader1 = command1.ExecuteReader();
            //Console.WriteLine("2) Вывести список туров, отсортированных по возрастанию стоимости дня пребывания");
            //while (reader1.Read())
            //{
            //    Console.WriteLine($"TourID={reader1.GetInt32(reader1.GetOrdinal("TourID"))} Price={ reader1.GetInt32(reader1.GetOrdinal("Price"))}" +
            //        $" NumberOfDays={reader1.GetInt32(reader1.GetOrdinal("NumberOfDays"))}");
            //}
            //reader1.Close();

            //var command2 = connection.CreateCommand();
            //command2.CommandText = "SELECT TourID, Price FROM Tours WHERE Price > (SELECT AVG(Price) FROM Tours)";
            //var reader2 = command2.ExecuteReader();
            //Console.WriteLine("3) Вывести список туров, стоимостью выше среднего по базе");
            //while (reader2.Read())
            //{
            //    Console.WriteLine($"TourID={reader2.GetInt32(reader2.GetOrdinal("TourID"))} Price={reader2.GetInt32(reader2.GetOrdinal("Price"))}");
            //}
            //reader2.Close();

            //var command3 = connection.CreateCommand();
            //command3.CommandText = "SELECT DepartureCityID, COUNT(*) AS NumberOfTours FROM Tours GROUP BY DepartureCityID";
            //var reader3 = command3.ExecuteReader();
            //Console.WriteLine("4) Вывести пары: {город, число туров}, используя группировку(GroupBy, Count)");
            //while (reader3.Read())
            //{
            //    Console.WriteLine($"DepartureCityID={reader3.GetInt32(reader3.GetOrdinal("DepartureCityID"))} NumberOfTours={reader3.GetInt32(reader3.GetOrdinal("NumberOfTours"))}");
            //}
            //reader3.Close();

            //var command4 = connection.CreateCommand();
            //command4.CommandText = "UPDATE Tours SET Price = Price/2 WHERE Price = (SELECT MAX(Price) FROM Tours)";
            //int number = command4.ExecuteNonQuery();
            //Console.WriteLine("5) Извлечь тур с максимальной ценой, уценить его в полтора раза. Результат сохранить");
            //Console.WriteLine("Обновлено объектов: {0}", number);

            //connection.Close();

            //var command5 = connection.CreateCommand();
            //command5.CommandText = "DELETE FROM Tours WHERE Price = (SELECT MIN(Price) FROM Tours)";
            //int number1 = command5.ExecuteNonQuery();
            //Console.WriteLine("6) Найти тур с минимальной ценой и удалить из базы");
            //Console.WriteLine("Обновлено объектов: {0}", number1);

            //var command6 = connection.CreateCommand();
            //command6.CommandText = "DECLARE @minNumberOfToursCountryID INT = (SELECT TOP(1) CountryID FROM Tours GROUP BY CountryID ORDER BY COUNT(*)) " +
            //    "INSERT INTO Tours (Price, NumberOfDays, DepartureCityID, CountryID) VALUES(135000, 14, 1266, @minNumberOfToursCountryID)";
            //int number2 = command6.ExecuteNonQuery();
            //Console.WriteLine("7) Найти страну с наименьшим числом туров и добавить в неё новый");
            //Console.WriteLine("Обновлено объектов: {0}", number2);

            connection.Close();
        }

        static void LinqDemo()
        {
            Database db = new Database();
            //Console.WriteLine("1) Вывести список туров, отсортированных по убыванию стоимости");
            //foreach (Tour t in db.Tours.OrderByDescending(t => t.Price))
            //{
            //    Console.WriteLine(t.TourID);
            //}

            //Console.WriteLine("2) Вывести список туров, отсортированных по возрастанию стоимости дня пребывания");
            //foreach (Tour t in db.Tours.OrderBy(t => t.Price/t.NumberOfDays))
            //{
            //    Console.WriteLine(t.TourID);
            //}

            //Console.WriteLine("3) Вывести список туров, стоимостью выше среднего по базе");
            //foreach (Tour t in db.Tours.Where(t => t.Price > db.Tours.Average(t => t.Price)))
            //{
            //    Console.WriteLine(t.TourID);
            //}

            //Console.WriteLine("4) Вывести пары: { город, число туров}, используя группировку(GroupBy, Count)");
            //foreach (var g in db.Tours.GroupBy(t => t.DepartureCity).Select(x => new {DepartureCityID = x.Key.DepartureCityID, Count = x.Count() }))
            //{
            //    Console.WriteLine($"{g.DepartureCityID}: {g.Count}");
            //}

            Console.WriteLine("5) Извлечь тур с максимальной ценой, уценить его в полтора раза. Результат сохранить");
            Decimal MaxPrice = 0;
            var TourWithMaxPriceID = 0;
            foreach (Tour t in db.Tours)
            {
                if (t.Price > MaxPrice)
                {
                    MaxPrice = t.Price;
                    TourWithMaxPriceID = t.TourID;
                }
            }
            Console.WriteLine("Тур с максимальной ценой = " + TourWithMaxPriceID);

            ////foreach (Tour t in db.Tours)
            ////{
            ////    if (t.TourID == TourWithMaxPriceID)
            ////    {
            ////        t.Price = t.Price / 2;
            ////        db.SaveChanges();
            ////    }
            ////}

            Console.WriteLine("6) Найти тур с минимальной ценой и удалить из базы");

            Decimal MinPrice = 9999999999999999999;
            var TourWithMinPriceID = 0;
            foreach (Tour t in db.Tours)
            {
                if (t.Price < MinPrice)
                {
                    MinPrice = t.Price;
                    TourWithMinPriceID = t.TourID;
                }
            }
            Console.WriteLine("Тур с минимальной ценой = " + TourWithMinPriceID);

            //foreach (Tour t in db.Tours)
            //{
            //    if (t.TourID == TourWithMinPriceID)
            //    {
            //        db.Tours.Remove(t);
            //        db.SaveChanges();
            //    }
            //}

            Console.WriteLine("7) Найти страну с наименьшим числом туров и добавить в неё новый");
            var minNumberOfToursCountryID = db.Tours.
                GroupBy(t => t.Country).
                Select(x => new { CountryID = x.Key.CountryID, Count = x.Count() }).
                OrderBy(x => x.Count).
                First();
            Console.WriteLine("Cтрана с наименьшим числом туров: " + minNumberOfToursCountryID.CountryID);

            //Tour t1 = new Tour {TourID = 11, Price = 135000, NumberOfDays = 14, DepartureCity = DepartureCities[1], Country = minNumberOfToursCountryID.CountryID };

        }
        static void EFDemo()
        {
            ToursContext db = new ToursContext();
            db.CreateDbIfExist();
        }
        static void Main(string[] args)
        {
            //AdoNetDemo();

            //LinqDemo();

            //EFDemo();
        }
    }
}