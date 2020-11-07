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
            //getting days of week from method
            HotelReservationRepository.bookingDate = System.DateTime.Parse("11,09,2020");
            HotelReservationRepository.checkoutDate = System.DateTime.Parse("12,09,2020");
            // Actual returned output tuple
            Tuple<string, int, int> outputForBestRating = HotelReservationRepository.BestRatedHotelForDateRange(2);
            // Expected output tuple
            Tuple<string, int, int> expectedOutputTuple = new Tuple<string, int, int>("Ridgewood", 140, 5);
            //assert
            Assert.AreEqual(expectedOutputTuple, outputForBestRating);
        }
    }
}