using Rymdskepp.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rymdskepp.Menu
{
    public class Menu
    {
        public void MenuMethod(Manage manage)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("1. Se alla rymdshepp" +
                    "/n2. Parkera ett nytt rymdshepp" +
                    "n3. Betala och lämna garaget");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowSpaceship(manage);
                        break;

                    case "2":
                        Console.Clear();
                        manage.AddSpaceship();
                        break;

                    //case "3":
                    //    Console.Clear();
                    //    Console.WriteLine("Din totala kostnad för detta besök är: " + manage.PayAndExit(TimeOfParking, DateOfParking));
                    //    break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Välj mellan ett av alternativen 1-3 och tryck Enter");
                        Break.PressToContinue();
                        break;
                }
            }


        }

        public static void ShowSpaceship(Manage manage)
        {
            manage.ListAllSpaceships();
        }

    }
}
