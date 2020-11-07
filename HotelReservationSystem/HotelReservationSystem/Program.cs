// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystem
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Welcome to Hotel Reservation Program");
            Console.WriteLine("====================================");
            /// UC1 -- Adding the hotel name and rate per day for regular customers only
            /// UC3 -- Adding the provision for weekend and weekday rate per day
            /// UC5 -- Adding the provision of ratings to the hotels
            HotelReservationRepository.AddHotelRecords("Lakewood", 110, 90, 3);
            HotelReservationRepository.AddHotelRecords("Bridgewood", 150, 50, 4);
            HotelReservationRepository.AddHotelRecords("Ridgewood", 220, 150, 5);
            /// Display the record in the hotel record dictionary
            HotelReservationRepository.DisplayRecordsInDictionary();
            ///// UC 2 and 4 -- Print the hotel with the cheapest rates
            ///// Also considered the weekend and weekdays to compute the total expense
            //HotelReservationRepository.FindCheapestHotel();
            /// UC 6 -- Print the hotel with the cheapest rates and best ratings
            /// Also considered the weekend and weekdays to compute the total expense
            Tuple<string, int, int> output = HotelReservationRepository.FindCheapestBestRatedHotels();
            Console.WriteLine("Cheapest Hotel - {0}, Cheapest Rate - {1}, Best Rating - {2} ", output.Item1, output.Item2, output.Item3);
            Console.ReadLine();
        }
    }
}
