using Rymdskepp.Floors;
using Rymdskepp.Garage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rymdskepp
{
    public class Spaceship
    {
        public string RegistrationNumber { get; set; } = null!;
        public DateTime TimeOfParking { get; set; }

        public DateTime DateOfParking { get; set; }




    public static Spaceship GetNewSpaceship(Manage manage)
    {
        int choice = Validate.GetValidNumber("vilken våning vill du parkera på?", 1, 3);
        string platenumber = string.Empty;
        do
        {
            platenumber = Validate.GetValidPlateNumber();
        } while (Validate.IsPlateNumberBusy(platenumber, manage));
        //string floor1 = Validate.GetValidString("1");
        //string floor2 = Validate.GetValidString("2");
        //string floor3 = Validate.GetValidString("3");

        //switch (choice)
        //{
        //    case 1:
        //        return floor1.newspaceship();

        //    case 2:
        //        return floor2.newspaceship();

        //    case 3:
        //        return floor3.newspaceship();
        //    default:
        //        break;
        //}
        //return null;
        }
    }
}



