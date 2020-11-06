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
    using System.Text;
    public class HotelReservationRepository
    {
        /// <summary>
        /// Dictionary to store the record of the hotel and the rate of thehotel
        /// </summary>
        public static Dictionary<string, HotelDetails> onlineHotelRecords = new Dictionary<string, HotelDetails>();

        /// <summary>
        /// UC1 -- Adding the Hotel Record to the online hotel record dictionary
        /// </summary>
        /// <param name="hotelName">Name of the hotel.</param>
        /// <param name="ratePerDay">The rate per day.</param>
        public static void AddHotelRecords(string hotelName, int ratePerDay)
        {
            if (onlineHotelRecords.ContainsKey(hotelName))
            {
                Console.WriteLine("Record Already exists. Kindly enter a different record...");
            }
            else
            {
                HotelDetails newHotelRecord = new HotelDetails(hotelName, ratePerDay);
                onlineHotelRecords.Add(hotelName, newHotelRecord);
            }
        }
        public static void DisplayRecordsInDictionary()
        {
            foreach (var records in onlineHotelRecords)
            {
                Console.WriteLine($"Hotel Name = {records.Key}, Rate Per Day = {records.Value.ratePerDay}\n");
            }    
        }
    }
}
