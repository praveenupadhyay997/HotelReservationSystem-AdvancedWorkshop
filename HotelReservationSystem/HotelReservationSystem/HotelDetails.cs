// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelDetails.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystem
{
    using System.Collections.Generic;
    using System.Text;
    using System;
    public class HotelDetails
    {
        /// <summary>
        /// Data Member for hotel name and rate for a day
        /// </summary>
        public string hotelName;
        /// UC3 -- Differentiating between the weekday and weekend rates by specifying two different member variables
        public int weekdayRate;
        public int weekendRate;
        /// UC5 -- Adding the feature to allocate rating to the hotel in dictionary
        public int rating;
        /// <summary>
        /// Parameterised Constructor to initialise the instance of the Hotel Details By the value passed by user
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="ratePerDay"></param>
        public HotelDetails(string hotelName, int weekdayRate, int weekendRate, int rating)
        {
            this.hotelName = hotelName;
            this.weekdayRate = weekdayRate;
            this.weekendRate = weekendRate;
            this.rating = rating;
        }
    }
}
