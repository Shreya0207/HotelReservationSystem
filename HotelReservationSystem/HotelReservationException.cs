using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservationException : Exception
    {
        public enum ExceptionType
        {
            INVALID_HOTEL_TYPE,
            INVALID_DATE
        }
        ExceptionType type;
        public HotelReservationException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
   
