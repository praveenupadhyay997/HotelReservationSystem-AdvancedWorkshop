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
        public static void DriverFunctionForCustomerType(int type)
        {
            /// UC 2 and 4 -- Print the hotel with the cheapest rates
            /// Also considered the weekend and weekdays to compute the total expense
            HotelReservationRepository.FindCheapestHotel(type);
            /// UC 6 -- Print the hotel with the cheapest rates and best ratings
            /// Also considered the weekend and weekdays to compute the total expense
            Tuple<string, int, int> output = HotelReservationRepository.FindCheapestBestRatedHotels(type);
            Console.WriteLine("Cheapest Hotel - {0}, Cheapest Rate - {1}, Best Rating - {2} ", output.Item1, output.Item2, output.Item3);
            /// UC 7 -- Print the hotel with best ratings and rates for it
            Tuple<string, int, int> outputForBestRating = HotelReservationRepository.BestRatedHotelForDateRange(type);
            Console.WriteLine("Cheapest Hotel - {0}, Cheapest Rate - {1}, Best Rating - {2} ", outputForBestRating.Item1, outputForBestRating.Item2, outputForBestRating.Item3);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Welcome to Hotel Reservation Program");
            Console.WriteLine("====================================");
            /// UC1 -- Adding the hotel name and rate per day for regular customers only
            /// UC3 -- Adding the provision for weekend and weekday rate per day
            /// UC5 -- Adding the provision of ratings to the hotels
            HotelReservationRepository.DefiningAdditionRepository(CustomerType.REGULAR);
            HotelReservationRepository.DefiningAdditionRepository(CustomerType.REWARD);
            /// Display the record in the hotel record dictionary
            HotelReservationRepository.DisplayRecordsInDictionary();
            Console.WriteLine("Have you upgraded from the regular customer -");
            string choice = Console.ReadLine().ToLower();
            if(choice == "yes")
            {
                DriverFunctionForCustomerType(2);
            }
            else
            {
                DriverFunctionForCustomerType(1);
            }
            Console.ReadLine();
        }
    }
}
