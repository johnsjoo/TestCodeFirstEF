using System;
using System.Globalization;
using System.IO;
using TestCodeFirstEF.Models;

namespace TestCodeFirstEF
{
    class Program
    {
        static string filePath = @"C:\Users\John\Desktop\c# Uppgifter\TestCodeFirstEF\TestCodeFirstEF\Files\TemperaturData.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Reading data..");
            ReadCSVFile(filePath);
            Console.WriteLine("Done!");
        }

        public static void ReadCSVFile(string fileP)
        {
            string[] resultSet = File.ReadAllLines(fileP);
            using (var context = new EFContext())
            {
                foreach (var data in resultSet)
                {
                    WeatherData tmpInfo = new WeatherData();
                    string[] tmpString = data.Split(",");
                    tmpInfo.DateAndTime = DateTime.Parse(tmpString[0]);
                    tmpInfo.Location = tmpString[1];
                    tmpInfo.Temp = decimal.Parse(tmpString[2], CultureInfo.InvariantCulture);
                    tmpInfo.Humidity = int.Parse(tmpString[3], CultureInfo.InvariantCulture);


                    context.Add(tmpInfo);
                }
                context.SaveChanges();
            }
        }
    }
}
