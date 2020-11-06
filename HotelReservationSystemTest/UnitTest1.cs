using NUnit.Framework;
using HotelReservationSystem;

namespace HotelReservationSystemTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AddHotelTest()
        {
            Hotel hotel = new Hotel(HotelType.RIDGEWOOD, CustomerType.NORMAL);
            double expectedRate = 220;
            Assert.AreEqual(expectedRate, hotel.WEEKDAY_RATE);
        }

        [Test]
        public void CheapestBestRatedHotelForRewardCustomer_ShouldReturnRidgeWood()
        {
            HotelService service = new HotelService();
            HotelType hotel = service.FindCheapestHotel("2020-09-11", "2020-09-12", CustomerType.REWARD);
            HotelType expected = HotelType.RIDGEWOOD;
            Assert.AreEqual(hotel, expected);
        }
    }
}