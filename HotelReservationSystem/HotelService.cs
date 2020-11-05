using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelService
    {
        public HotelType FindCheapestHotel(string startDate, string endDate)
        {
            Hotel LakeWood = new Hotel(HotelType.LAKEWOOD);
            Hotel BridgeWood = new Hotel(HotelType.BRIDGEWOOD);
            Hotel RidgeWood = new Hotel(HotelType.RIDGEWOOD);
            double LakeWoodRate = LakeWood.FindTotalCost(startDate, endDate);
            double BridgeWoodRate = BridgeWood.FindTotalCost(startDate, endDate);
            double RidgeWoodRate = RidgeWood.FindTotalCost(startDate, endDate);

            if (LakeWoodRate < BridgeWoodRate && LakeWoodRate < RidgeWoodRate)
            {
                return HotelType.LAKEWOOD;
            }
            else if (BridgeWoodRate < LakeWoodRate && BridgeWoodRate < RidgeWoodRate)
            {
                return HotelType.BRIDGEWOOD;
            }
            else
            {
                return HotelType.RIDGEWOOD;
            }
        }
    }
}
