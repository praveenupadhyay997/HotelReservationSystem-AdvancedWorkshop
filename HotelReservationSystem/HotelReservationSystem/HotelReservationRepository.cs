// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelReservationRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystem
{
    using LanguageExt;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class HotelReservationRepository
    {
        /// <summary>
        /// Dictionary to store the record of the hotel and the hotel details for regular customers
        /// </summary>
        public static Dictionary<string, HotelDetails> onlineHotelRecordsForRegularCutomers = new Dictionary<string, HotelDetails>();
        /// <summary>
        /// Dictionary to store the record of the hotel and the hotel details for reward customers
        /// </summary>
        public static Dictionary<string, HotelDetails> onlineHotelRecordsForRewardCutomers = new Dictionary<string, HotelDetails>();
        /// <summary>
        /// Method to add the data to the multiple customer types
        /// </summary>
        /// <param name="customerType"></param>
        public static void DefiningAdditionRepository(CustomerType customerType)
        {
            switch (customerType)
            {
                /// Adding the detail for the regular customer type
                case CustomerType.REGULAR:
                    AddHotelRecords("Lakewood", 110, 90, 3, 1);
                    AddHotelRecords("Bridgewood", 150, 50, 4, 1);
                    AddHotelRecords("Ridgewood", 220, 150, 5, 1);
                    break;
                /// Adding the detail for the rewarded customer type
                case CustomerType.REWARD:
                    AddHotelRecords("Lakewood", 80, 80, 3, 2);
                    AddHotelRecords("Bridgewood", 110, 50, 4, 2);
                    AddHotelRecords("Ridgewood", 100, 40, 5, 2);
                    break;
                /// Catching the exception for the invalid customer type
                default:
                    throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.INVALID_CUSTOMER_TYPE, "Does not support this customer type");
            }
        }
        /// <summary>
        /// UC1 -- Adding the Hotel Record to the online hotel record dictionary
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="weekdayRate"></param>
        /// <param name="weekendRate"></param>
        public static void AddHotelRecords(string hotelName, int weekdayRate, int weekendRate, int rating, int type)
        {
            if(type ==1)
            {
                if (onlineHotelRecordsForRegularCutomers.ContainsKey(hotelName))
                {
                    Console.WriteLine("Record Already exists. Kindly enter a different record...");
                }
                else
                {
                    HotelDetails newHotelRecord = new HotelDetails(hotelName, weekdayRate, weekendRate, rating);
                    onlineHotelRecordsForRegularCutomers.Add(hotelName, newHotelRecord);
                }           
            }
            else
            {
                if (onlineHotelRecordsForRewardCutomers.ContainsKey(hotelName))
                {
                    Console.WriteLine("Record Already exists. Kindly enter a different record...");
                }
                else
                {
                    HotelDetails newHotelRecord = new HotelDetails(hotelName, weekdayRate, weekendRate, rating);
                    onlineHotelRecordsForRewardCutomers.Add(hotelName, newHotelRecord);
                }
            }
        }
        /// <summary>
        /// Calculate the total fare for each hotel and it's type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<string, int> CalculateTotalRateForEachHotel(int type)
        {
            /// Dictionary to store the (rateperday*numberofdaysofStay) and name of the hotel as the key
            Dictionary<string, int> rateRecords = new Dictionary<string, int>();
            /// Catching the exception of null value to the sorted list
            try
            {
                /// Getting the check-in date or the start date
                Console.WriteLine("Enter the booking date(DD,MM,YYYY) -- ");
                DateTime bookingDate = DateTime.Parse(Console.ReadLine());
                /// Getting the check-in date or the start date
                Console.WriteLine("Enter the check-out date(DD,MM,YYYY) -- ");
                DateTime checkoutDate = DateTime.Parse(Console.ReadLine());
                /// Computing the number ofdays of stay requested by the customer
                int noOfDaysOfStay = (checkoutDate - bookingDate).Days + 1;
                /// Iterating over the online hotel records to store the total expense and hotel name
                foreach (var records in ((type==1)? onlineHotelRecordsForRegularCutomers :onlineHotelRecordsForRewardCutomers))
                {
                    int totalExpense = 0;
                    DateTime currentDate = bookingDate;
                    while (currentDate <= checkoutDate)
                    {
                        /// Checking the type of the date - Weekend (Saturday or Sunday)
                        if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            /// Adding the weekend expense in the total expense
                            totalExpense += records.Value.weekendRate;
                        }
                        else
                        {
                            /// Adding the weekday expense in the total expense
                            totalExpense += records.Value.weekdayRate;
                        }
                        /// Moving to the next day to increment the current date
                        currentDate = currentDate.AddDays(1);
                    }
                    rateRecords.Add(records.Value.hotelName, totalExpense);
                }
            }
            catch (HotelReservationCustomException e)
            {
                Console.WriteLine(e.Message);
            }
            return rateRecords;
        }
        /// <summary>
        /// Method to display the details of record in the address book
        /// Refactored to print the detail of different customer types
        /// </summary>
        public static void DisplayRecordsInDictionary()
        {
            /// Displaying the record for the Regular Customers
            Console.WriteLine("=============================================");
            Console.WriteLine(" Regular Customers Detail for the Hotel List ");
            Console.WriteLine("=============================================");
            foreach (var records in onlineHotelRecordsForRegularCutomers)
            {
                Console.WriteLine($"Hotel Name = {records.Key}, WeekDay Rate Per Day = {records.Value.weekdayRate}, WeekDay Rate Per Day = {records.Value.weekendRate}, Ratings = {records.Value.rating}\n");
            }
            /// Displaying the record for the Rewarded Customers
            Console.WriteLine("==============================================");
            Console.WriteLine(" Rewarded Customers Detail for the Hotel List ");
            Console.WriteLine("==============================================");
            foreach (var records in onlineHotelRecordsForRewardCutomers)
            {
                Console.WriteLine($"Hotel Name = {records.Key}, WeekDay Rate Per Day = {records.Value.weekdayRate}, WeekDay Rate Per Day = {records.Value.weekendRate}, Ratings = {records.Value.rating}\n");
            }
        }
        /// <summary>
        /// UC2 -- Finds the cheapest hotel for the date range
        /// UC4 -- Considering the weekend and weekday difference of rates
        /// First finding the hotel with minimum totalExpense per day
        /// </summary>
        public static void FindCheapestHotel(int type)
        {
            /// Catching the exception of null value to the sorted list
            try
            {
                /// Refactor - Fixing the voilation of Dry Principle by calculating the total fare using a method call
                Dictionary<string, int> rateRecords = new Dictionary<string, int>();
                rateRecords = CalculateTotalRateForEachHotel(type);
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
        /// <summary>
        /// UC6 -- Find cheapest best rated hotel for the customer date range of travel
        /// Logic -- Consider the cheapest if it is high in rating and low in cost
        /// Else consider the second next in cost reduction
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, int, int> FindCheapestBestRatedHotels(int type)
        {
            bool flag = false;
            /// Catching the exception of null value to the sorted list
            try
            {
                /// Refactor - Fixing the voilation of Dry Principle by calculating the total fare using a method call
                Dictionary<string, int> rateRecords = new Dictionary<string, int>();
                rateRecords = CalculateTotalRateForEachHotel(type);
                /// Dictionary to store the rating Records and name of dictionary
                Dictionary<string, int> ratingRecords = new Dictionary<string, int>();
                /// Adding the rating and hotel name to the dictionary
                foreach (var records in ((type == 1) ? onlineHotelRecordsForRegularCutomers : onlineHotelRecordsForRewardCutomers))
                {
                    ratingRecords.Add(records.Value.hotelName, records.Value.rating);
                }
                /// Sorting the dictionary element by the rating in descending order
                var keyValueForSortedRating = ratingRecords.OrderByDescending(sortedValuePair => sortedValuePair.Value);
                /// Executing the order by total expense and fetching the minimum value of rate
                var keyValueForSortedByRate = rateRecords.OrderBy(keyValueForSorted => keyValueForSorted.Value);
                /// Getting the length of the sorted dictionary for rating
                int length = (keyValueForSortedRating.Length() / 2);
                /// Deciding the median amply rated hotel for the user
                var ampleRating = keyValueForSortedRating.ElementAt(length);
                /// Declaring a tuple to return name of hotel, rate and rating
                Tuple<string, int, int> outputHotel;
                /// Matching for amply rated and cheapest hotel too
                foreach (var sortByRate in keyValueForSortedByRate)
                {
                    /// Condition check for the most suitable hotel according to  the use cases
                    if (sortByRate.Key == ampleRating.Key)
                    {
                        outputHotel = new Tuple<string, int, int>(sortByRate.Key, sortByRate.Value, ampleRating.Value);
                        flag = true;
                        return outputHotel;
                    }
                }
                /// Returning a default tuple in case of the no match so as to avoid null exception in Program.cs
                if (flag == false)
                    return new Tuple<string, int, int>("", 0, 0);
            }
            catch (HotelReservationCustomException e)
            {
                Console.WriteLine(e.Message);
            }
            /// Avoiding the "not all code path returns a value"
            /// Logically if the execution reach this point then there is no match for the amply located hotel
            /// However it is very unlikely that execution will reach here
            return new Tuple<string, int, int>("", 0, 0);
        }
        /// <summary>
        /// UC7 -- Find the best rated hotel and its cost for a given date range
        /// </summary>
        /// <returns></returns
        public static Tuple<string, int, int> BestRatedHotelForDateRange(int type)
        {
            bool flag = false;
            /// Catching the exception of null value to the sorted list
            try
            {
                /// Refactor - Fixing the voilation of Dry Principle by calculating the total fare using a method call
                Dictionary<string, int> rateRecords = new Dictionary<string, int>();
                rateRecords = CalculateTotalRateForEachHotel(type);
                /// Dictionary to store the rating Records and name of dictionary
                Dictionary<string, int> ratingRecords = new Dictionary<string, int>();
                /// Adding the rating and hotel name to the dictionary
                foreach (var records in ((type == 1) ? onlineHotelRecordsForRegularCutomers : onlineHotelRecordsForRewardCutomers))
                {
                    ratingRecords.Add(records.Value.hotelName, records.Value.rating);
                }
                /// Sorting the dictionary element by the rating in descending order
                var keyValueForSortedRating = ratingRecords.OrderByDescending(sortedValuePair => sortedValuePair.Value).First();
                /// Tuple to be returned in case of best match
                Tuple<string, int, int> outputHotel;
                /// Matching for amply rated and cheapest hotel too
                foreach (var sortByRate in rateRecords)
                {
                    /// Condition check for the most suitable hotel according to  the use cases
                    if (sortByRate.Key == keyValueForSortedRating.Key)
                    {
                        outputHotel = new Tuple<string, int, int>(sortByRate.Key, sortByRate.Value, keyValueForSortedRating.Value);
                        flag = true;
                        return outputHotel;
                    }
                }
                /// Returning a default tuple in case of the no match so as to avoid null exception in Program.cs
                if (flag == false)
                    return new Tuple<string, int, int>("", 0, 0);
            }
            catch (HotelReservationCustomException e)
            {
                Console.WriteLine(e.Message);
            }
            /// Avoiding the "not all code path returns a value"
            /// Logically if the execution reach this point then there is no match for the amply located hotel
            /// However it is very unlikely that execution will reach here
            return new Tuple<string, int, int>("", 0, 0);
        }
    }
}
