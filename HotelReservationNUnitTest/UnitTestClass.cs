namespace HotelReservationNUnitTest
{
    using NUnit.Framework;
    using HotelReservationSystem;
    using System;
    public class UnitTestClass
    {
        /// <summary>
        /// TC1 - To get the best rated cheapest hotel for reward customers
        /// </summary>
        [Test]
        public void GivenInputDataForRewardCustomers_ReturnOutputTuple()
        {
            HotelReservationRepository.DefiningAdditionRepository(CustomerType.REWARD);
            /// Passing the check in and check out date and converting it into the date time format
            HotelReservationRepository.bookingDate = System.DateTime.Parse("11,Sep,2020");
            HotelReservationRepository.checkoutDate = System.DateTime.Parse("12,Sep,2020");
            /// Actual returned output tuple
            Tuple<string, int, int> outputForBestRating = HotelReservationRepository.BestRatedHotelForDateRange(2);
            /// Expected output tuple
            Tuple<string, int, int> expectedOutputTuple = new Tuple<string, int, int>("Ridgewood", 140, 5);
            //assert
            Assert.AreEqual(expectedOutputTuple, outputForBestRating);
        }
        /// <summary>
        /// TC2 - Given the invalid date must return a custom exception
        /// </summary>
        [Test]
        public void PassingInvalidDate_ReturnCustomException()
        {
            HotelReservationRepository.DefiningAdditionRepository(CustomerType.REWARD);
            /// Passing the check in and check out date
            string checkInDate = "11-Sep-2020";
            string checkOutDate = "12,Sep,2020";            
            // Actual returned exception message
            if(HotelReservationRepository.IsValidDate(checkInDate) && HotelReservationRepository.IsValidDate(checkOutDate))
                throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.INVALID_DATE_ENTRY, "User Date Entry is not valid.");
            /// Expected output message of enum type
            /// To Compare with the message create instance of the class
            string expectedExceptionMessage = "INVALID_DATE_ENTRY";
            /// Assert
            Assert.AreEqual(expectedExceptionMessage, HotelReservationCustomException.ExceptionType.INVALID_DATE_ENTRY.ToString());
        }
        /// <summary>
        /// TC3 - To get the best rated cheapest hotel for regular customers
        /// </summary>
        [Test]
        public void GivenInputDataForRegularCustomers_ReturnOutputTuple()
        {
            HotelReservationRepository.DefiningAdditionRepository(CustomerType.REGULAR);
            /// Passing the check in and check out date and converting it into the date time format
            HotelReservationRepository.bookingDate = System.DateTime.Parse("11,Sep,2020");
            HotelReservationRepository.checkoutDate = System.DateTime.Parse("12,Sep,2020");
            /// Actual returned output tuple
            Tuple<string, int, int> outputForBestRating = HotelReservationRepository.FindCheapestBestRatedHotels(1);
            /// Expected output tuple
            Tuple<string, int, int> expectedOutputTuple = new Tuple<string, int, int>("Bridgewood", 200, 4);
            //assert
            Assert.AreEqual(expectedOutputTuple, outputForBestRating);
        }
    }
}