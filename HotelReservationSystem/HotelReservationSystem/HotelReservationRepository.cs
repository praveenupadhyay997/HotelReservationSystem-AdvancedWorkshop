// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelReservationRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class HotelReservationRepository
    {
        /// <summary>
        /// Dictionary to store the record of the hotel and the totalExpense of thehotel
        /// </summary>
        public static Dictionary<string, HotelDetails> onlineHotelRecords = new Dictionary<string, HotelDetails>();
        /// <summary>
        /// UC1 -- Adding the Hotel Record to the online hotel record dictionary
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="weekdayRate"></param>
        /// <param name="weekendRate"></param>
        public static void AddHotelRecords(string hotelName, int weekdayRate, int weekendRate)
        {
            if (onlineHotelRecords.ContainsKey(hotelName))
            {
                Console.WriteLine("Record Already exists. Kindly enter a different record...");
            }
            else
            {
                HotelDetails newHotelRecord = new HotelDetails(hotelName, weekdayRate, weekendRate);
                onlineHotelRecords.Add(hotelName, newHotelRecord);
            }
        }
        /// <summary>
        /// Method to displat the details of record in the address book
        /// </summary>
        public static void DisplayRecordsInDictionary()
        {
            foreach (var records in onlineHotelRecords)
            {
                Console.WriteLine($"Hotel Name = {records.Key}, WeekDay Rate Per Day = {records.Value.weekdayRate}, WeekDay Rate Per Day = {records.Value.weekendRate}\n");
            }    
        }
        /// <summary>
        /// UC2 -- Finds the cheapest hotel for the date range
        /// First finding the hotel with minimum totalExpense per day
        /// </summary>
        public static void FindCheapestHotel()
        {
            /// Catching the exception of null value to the sorted list
            try
            {
                /// Getting the check-in date or the start date
                Console.WriteLine("Enter the booking date(DD,MM,YYYY):");
                DateTime bookingDate = DateTime.Parse(Console.ReadLine());
                /// Getting the check-in date or the start date
                Console.WriteLine("Enter the check-out date(DD,MM,YYYY):");
                DateTime checkoutDate = DateTime.Parse(Console.ReadLine());
                /// Computing the number ofdays of stay requested by the customer
                int noOfDaysOfStay = (checkoutDate - bookingDate).Days + 1;
                /// Dictionary to store the (rateperday*numberofdaysofStay) and name of the hotel as the key
                Dictionary<string, int> rateRecords = new Dictionary<string, int>();
                /// Iterating over the online hotel records to store the total expense and hotel name
                foreach (var records in onlineHotelRecords)
                {
                    int totalExpense = records.Value.weekdayRate * noOfDaysOfStay;
                    rateRecords.Add(records.Value.hotelName, totalExpense);
                }
                /// Executing the order by total expense and fetching the minimum value of rate
                var keyValueForSorted = rateRecords.OrderBy(keyValueForSorted => keyValueForSorted.Value).First();
                /// Returning the custom sized null exception for no entry of the rate value
                if (keyValueForSorted.Key == null)
                    throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.RATE_ENTRY_NOT_EXIST, "There was no total Expense entry for the cheapest hotel.");
                Console.WriteLine("Cheapest Hotel - {0}, Cheapest Rate - {1}", keyValueForSorted.Key, keyValueForSorted.Value);
            }
            catch (HotelReservationCustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
