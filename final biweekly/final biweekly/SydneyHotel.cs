using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydneyHotel
{
    class ReservationManager
    {
        class ReservationDetail
        {
            public string customerName { get; set; }
            public int nights { get; set; }
            public string roomService { get; set; }
            public double totalPrice { get; set; }
        }

        // Calculation of room services
        // Pujan Budathoki
        static double CalculateTotalPrice(int nights, string isRoomService)
        {
            double price = 0;
            if ((nights > 0) && (nights <= 3))
            {
                price = 100 * nights;
            }
            else if ((nights > 3) && (nights <= 10))
            {
                price = 80.5 * nights;
            }
            else if ((nights > 10) && (nights <= 20))
            {
                price = 75.3 * nights;
            }

            // Check for room service and add 10% if requested
            if (isRoomService.ToLower() == "yes")
            {
                return price + price * 0.1;
            }
            else
            {
                return price;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(".................Welcome to Sydney Hotel...............");
            Console.Write("\nEnter no. of Customer: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n--------------------------------------------------------------------\n");

            ReservationDetail[] rd = new ReservationDetail[n];

            for (int i = 0; i < n; i++)
            {
                rd[i] = new ReservationDetail();
                Console.Write("Enter customer name: ");
                rd[i].customerName = Console.ReadLine();

                Console.Write("Enter the number of nights: ");
                rd[i].nights = Convert.ToInt32(Console.ReadLine());
                if (!(rd[i].nights > 0) && (rd[i].nights <= 20))
                {
                    Console.Write("Number of nights in between 1 to 20: ");
                    Console.Write("Enter the number of nights: ");
                    rd[i].nights = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Enter yes/no to indicate whether you want room service: ");
                rd[i].roomService = Console.ReadLine();

                rd[i].totalPrice = CalculateTotalPrice(rd[i].nights, rd[i].roomService);
                Console.WriteLine($"The total price from {rd[i].customerName} is ${rd[i].totalPrice}");
                Console.WriteLine("\n--------------------------------------------------------------------\n");
            }

            var (minPrice, minindex) = rd.Select(x => x.totalPrice).Select((m, i) => (m, i)).Min();
            var (maxPrice, maxindex) = rd.Select(x => x.totalPrice).Select((m, i) => (m, i)).Max();

            ReservationDetail maxrd = rd[maxindex];
            ReservationDetail minrd = rd[minindex];

            Console.WriteLine("\n\t\t\t\tSummary of reservation");
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.WriteLine("Name\t\tNumber of nights\t\tRoom service\t\tCharge");
            Console.WriteLine($"{minrd.customerName}\t\t\t{minrd.nights}\t\t\t{minrd.roomService}\t\t\t{minrd.totalPrice}");
            Console.WriteLine($"{maxrd.customerName}\t\t{maxrd.nights}\t\t\t{maxrd.roomService}\t\t\t{maxrd.totalPrice}");
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            Console.WriteLine($"The customer spending most is {maxrd.customerName} ${maxrd.totalPrice}");
            Console.WriteLine($"The customer spending least is {minrd.customerName} ${minrd.totalPrice}");
            Console.WriteLine($"Press any key to continue....");
            Console.ReadLine();
        }
    }
}