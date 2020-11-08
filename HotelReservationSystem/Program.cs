using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hotel Reservation System.");
            Hotel hotel = new Hotel();
            try
            {
                HotelService customerService = new HotelService();
                Console.WriteLine("Choose your customer type \nNORMAL \nREWARD");
                CustomerType customerType = customerService.Validate(Console.ReadLine());
                Console.WriteLine("Enter start date of your stay in YYYY/MM/DD format");
                string startDate = Console.ReadLine();
                Console.WriteLine("Enter end date of your stay in YYYY/MM/DD format");
                string endDate = Console.ReadLine();
                Console.WriteLine("Select your criteria of choice \n1. According to rates \n2. According to ratings");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        hotel.type = customerService.FindCheapestHotel(startDate, endDate, customerType);
                        customerService.PrintHotelType(hotel.type);
                        break;
                    case 2:
                        hotel.type = customerService.FindBestRatedHotel(startDate, endDate, customerType);
                        customerService.PrintHotelType(hotel.type);
                        break;
                    default:
                        throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CHOICE, "Invalid choice");
                }
            }
            catch (HotelReservationException exception)
            {
                Console.WriteLine(exception.Message + "\nTry Again");
            }
        }
    }
}