using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Rymdskepp.Garage
{
    public class Manage
    {
        int[] parkingLot = new int[45];




        public Garage<Spaceship> Garage { get; set; }

        public Manage(Garage<Spaceship> garage)
        {
            Garage = garage;

        }

        public void AddSpaceship()
        {
            if (Garage.Spaceships.Count < Garage.MaxLimitPerFloor)
            {
                Garage.Spaceships.Add(Spaceship.GetNewSpaceship(this));
                Console.WriteLine("rymdskeppet har nu lagts till");
                Break.PressToContinue();
            }
            else
            {
                Console.WriteLine("tyvärr är denna våning full, var snäll och välj en annan våning.");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("1. våning 1");
                        break;

                    case "2":
                        Console.WriteLine("n/2. våning 2");
                        break;

                    case "3":
                        Console.WriteLine("n/3. våning 3");
                        break;
                }
            }
        }

        public void PayAndExit(DateTime datetime)
        {
            if (Garage.Spaceships.Any())
            {
                StringBuilder stringbuilder = new StringBuilder();
                int index = 1;

                stringbuilder.Append($"här är alla parkerade rymdskepp:\n\n");

                foreach (Spaceship spaceship in Garage)
                {
                    stringbuilder.Append($"{index}. {spaceship}\n");
                    index++;
                }

                stringbuilder.Append($"\nvälj vilket rymdskepp som ska betala och åka härifrån." +
                                     $"\nom inget rymdskepp ska lämna, tryck 0");

                int userinput = Validate.GetValidNumber(stringbuilder.ToString(), 0, Garage.Spaceships.Count) - 1;

                if (userinput < 0)
                {
                    Console.WriteLine("tillbaka till menyn");
                    Break.PleaseWait(3);
                    return;
                }
                else
                {
                    Garage.Spaceships.RemoveAt(userinput);
                    Console.WriteLine("totala kostnaden för " + datetime + " är: ");
                    Break.PleaseWait(3);
                }
            }
            else
            {
                Console.WriteLine("garaget är för tillfället tomt.");
                Break.PleaseWait(2);
            }
        }
        public void ListAllSpaceships()
        {
            if (Garage.Spaceships.Any())
            {
                Console.WriteLine("här är alla rymdskepp som är parkerade i garaget:\n");
                int index = 1;
                foreach (Spaceship spaceship in Garage)
                {
                    Console.WriteLine($"{index}. {spaceship}");
                    index++;
                }
                Break.PressToContinue();
            }
            else
            {
                Console.WriteLine("garaget är för tillfället tomt.");
                Break.PleaseWait(2);
            }


        }

        public void SearchForSpaceship(string licenseplate)
        {
            foreach (Spaceship spaceship in Garage)
            {
                if (spaceship.RegistrationNumber == licenseplate)
                {
                    Console.WriteLine("rymdskeppet du sökte efter finns i garaget.");
                    Break.PressToContinue();
                    return;
                }
            }
            Console.WriteLine("rymdskeppet du sökte efter kunde tyvärr inte hittas i garaget.");
            Break.PleaseWait(2);
        }
    }
}
