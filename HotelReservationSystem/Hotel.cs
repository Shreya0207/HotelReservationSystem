using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        HotelType type;
        public double WEEKDAY_RATE { get; }
        public double WEEKEND_RATE { get; }
        public double RATING { get; }
        public Hotel(HotelType hotelType)
        {
            this.type = hotelType;
            try
            {
                if (hotelType.Equals(HotelType.LAKEWOOD))
                {
                    this.WEEKDAY_RATE = 110;
                    this.WEEKEND_RATE = 90;
                    this.RATING = 3;
                }
                if (hotelType.Equals(HotelType.BRIDGEWOOD))
                {
                    this.WEEKDAY_RATE = 150;
                    this.WEEKEND_RATE = 50;
                    this.RATING = 4;
                }
                if (hotelType.Equals(HotelType.RIDGEWOOD))
                {
                    this.WEEKDAY_RATE = 220;
                    this.WEEKEND_RATE = 150;
                    this.RATING = 5;
                }
            }
            catch (HotelReservationException)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_HOTEL_TYPE, "Invalid Hotel Type");
            }
        }
        public double FindTotalCost(string startDateString, string endDateString)
        {
            double TotalCost = 0;
            try
            {
                DateTime startDate = Convert.ToDateTime(startDateString);
                DateTime endDate = Convert.ToDateTime(endDateString);
                for (; startDate <= endDate; startDate = startDate.AddDays(1))
                {
                    if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
                        TotalCost += WEEKEND_RATE;
                    else
                        TotalCost += WEEKDAY_RATE;
                }
            }
            catch (Exception)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE, "Invalid date entered");
            }
            return TotalCost;
        }
    }
}

