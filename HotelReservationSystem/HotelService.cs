using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelService
    {
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
    }
}



