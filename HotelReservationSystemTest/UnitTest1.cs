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
        public void FindCheapestHotelTest()
        {
            HotelService service = new HotelService();
            HotelType hotel = service.FindCheapestHotel("2018-01-01", "2018-01-03");
            HotelType expected = HotelType.LAKEWOOD;
            Assert.AreEqual(hotel, expected);
        }
        [Test]
        public void FindCheapestHotelTest_AfterWeekdayAndWeekendRates()
        {
            HotelService service = new HotelService();
            HotelType hotel = service.FindCheapestHotel("2020-09-11", "2020-09-12");
            HotelType expected = HotelType.LAKEWOOD;
            Assert.AreEqual(hotel, expected);
        }
        [Test]
        public void CheapestBestRatedHotel_ShouldReturnBridgeWood()
        {
            HotelService service = new HotelService();
            HotelType hotel = service.FindCheapestHotel("2020-09-11", "2020-09-12");
            HotelType expected = HotelType.BRIDGEWOOD;
            Assert.AreEqual(hotel, expected);
        }
        [Test]
        public void FindBestRatedHotelTest_ShouldReturnRidgeWood()
        {
            HotelService service = new HotelService();
            HotelType hotel = service.FindBestRatedHotel("2020-09-11", "2020-09-12");
            HotelType expected = HotelType.RIDGEWOOD;
            Assert.AreEqual(hotel, expected);
        }
    }
}