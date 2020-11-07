using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    /// <summary>
    /// Class to define the custom exceptions to be given during the hotel reservatuon problem
    /// </summary>
    public class HotelReservationCustomException : Exception
    {
        /// <summary>
        /// Declaring enum to define the custome exceptions
        /// 0- No value in dictionary
        /// 1- No hotel found by that name or rate per day
        /// </summary>
        public enum ExceptionType
        {
            RATE_ENTRY_NOT_EXIST,
            NO_SUCH_HOTEL
        }
        /// <summary>
        /// Creating an instance of the exception type to initailise with value
        /// </summary>
        public ExceptionType type;
        /// <summary>
        /// Custom Exception to override the base exception message
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public HotelReservationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
