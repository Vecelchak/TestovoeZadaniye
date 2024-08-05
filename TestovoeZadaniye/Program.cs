using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Data.SqlClient;

namespace TestovoeZadaniye
{
    internal class Program
    {
        static void Main()
        {
            string connectionString = (@"Data Source=DESKTOP-HU81JFN\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;Encrypt=True;TrustServerCertificate=true"); // Для работы программы введите свою подключённую бд с соответсвующими таблицами и названием бд; Data Source = Имя юзера, Initial Catalog названием бд.
            DateTime startDate = new DateTime(2020, 2, 5);
            DateTime endDate = startDate.AddDays(7);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT an_name, an_price
                           FROM Analysis
                           INNER JOIN Orders ON Analysis.an_id = Orders.ord_an
                           WHERE ord_datetime >= @StartDate AND ord_datetime <= @EndDate";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Анализы проданные с {0:d} по {1:d}:", startDate, endDate);
                while (reader.Read())
                {
                    string an_name = reader["an_name"].ToString();
                    float an_price = (float) reader["an_price"];
                    Console.WriteLine("{0,-20} {1,10}", an_name, an_price);
                }
                reader.Close();
            }
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
        }
    }

}