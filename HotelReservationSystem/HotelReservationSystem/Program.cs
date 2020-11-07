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
            /// UC1 --Adding the hotel name and rate per day for regular customers only
            HotelReservationRepository.AddHotelRecords("Lakewood", 110);
            HotelReservationRepository.AddHotelRecords("Bridgewood", 150);
            HotelReservationRepository.AddHotelRecords("Ridgewood", 220);
            /// Display the record in the hotel record dictionary
            HotelReservationRepository.DisplayRecordsInDictionary();
            /// UC 2 -- Print the hotel with the cheapest rates
            HotelReservationRepository.FindCheapestHotel();
            Console.ReadLine();

        }
    }
}
