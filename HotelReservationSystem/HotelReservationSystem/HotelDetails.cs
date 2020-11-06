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
        public int ratePerDay;
        /// <summary>
        /// Parameterised Constructor to initialise the instance of the Hotel Details By the value passed by user
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="ratePerDay"></param>
        public HotelDetails(string hotelName, int ratePerDay)
        {
            this.hotelName = hotelName;
            this.ratePerDay = ratePerDay;
        }
    }
}
