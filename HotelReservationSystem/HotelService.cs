using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HotelReservationSystem
{
    public class HotelService
    {
        public string REGEX_NORMAL = @"^[Nn][Oo][Rr][Mm][Aa][Ll]$";
        public string REGEX_REWARD = @"^[Rr][Ee][Ww][Aa][Rr][Dd]$";
        public HotelType FindCheapestHotel(string startDate, string endDate, CustomerType type)
        {
            Hotel LakeWood = new Hotel(HotelType.LAKEWOOD, type);
            Hotel BridgeWood = new Hotel(HotelType.BRIDGEWOOD, type);
            Hotel RidgeWood = new Hotel(HotelType.RIDGEWOOD, type);
            //Calculating Rate of Each Hotel Between the given dates
            double LakeWoodRate = LakeWood.FindTotalCost(startDate, endDate);
            double BridgeWoodRate = BridgeWood.FindTotalCost(startDate, endDate);
            double RidgeWoodRate = RidgeWood.FindTotalCost(startDate, endDate);

            double MinRate = Math.Min(LakeWoodRate, Math.Min(BridgeWoodRate, RidgeWoodRate));
            if (MinRate == LakeWoodRate && MinRate == BridgeWoodRate && MinRate == RidgeWoodRate)
                return HotelType.RIDGEWOOD;
            if (MinRate == LakeWoodRate && MinRate == BridgeWoodRate)
                return HotelType.BRIDGEWOOD;
            if (MinRate == BridgeWoodRate && MinRate == RidgeWoodRate)
                return HotelType.RIDGEWOOD;
            if (MinRate == LakeWoodRate && MinRate == BridgeWoodRate)
                return HotelType.RIDGEWOOD;
            if (MinRate == LakeWoodRate)
                return HotelType.LAKEWOOD;
            if (MinRate == BridgeWoodRate)
                return HotelType.BRIDGEWOOD;
            return HotelType.RIDGEWOOD;
        }
        public HotelType FindBestRatedHotel(string startDate, string endDate, CustomerType type)
        {
            Hotel RidgeWood = new Hotel(HotelType.RIDGEWOOD, type);
            Hotel BridgeWood = new Hotel(HotelType.BRIDGEWOOD, type);
            Hotel LakeWood = new Hotel(HotelType.LAKEWOOD, type);

            double MaxRating = Math.Max(RidgeWood.RATING, Math.Max(BridgeWood.RATING, LakeWood.RATING));
            if (MaxRating == RidgeWood.RATING)
                return HotelType.RIDGEWOOD;
            if (MaxRating == BridgeWood.RATING)
                return HotelType.BRIDGEWOOD;
            else
                return HotelType.LAKEWOOD;
        }
        public CustomerType Validate(string customerType)
        {
            if (Regex.IsMatch(customerType, REGEX_NORMAL))
                return CustomerType.NORMAL;
            if (Regex.IsMatch(customerType, REGEX_REWARD))
                return CustomerType.REWARD;
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid customer type");
        }
        public void PrintHotelType(HotelType type)
        {
            if (type.Equals(HotelType.BRIDGEWOOD))
                Console.WriteLine("BridgeWood");
            else if (type.Equals(HotelType.RIDGEWOOD))
                Console.WriteLine("RidgeWood");
            else
                Console.WriteLine("LakeWood");
        }
    }
}
