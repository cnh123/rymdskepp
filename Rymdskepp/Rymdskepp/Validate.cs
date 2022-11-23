using Rymdskepp.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rymdskepp
{
    static class Validate
    {
        public static bool IsPlateNumberBusy(string input, Manage manage)
        {
            List<string> plateNumbers = manage.Garage.Spaceships
                            .Select(x => x.RegistrationNumber.ToUpper()).ToList();

            if (plateNumbers.Contains(input.ToUpper()))
            {
                Console.WriteLine("Registreringsnumret du försökte är för närvarande upptaget. Var snäll att försök med ett annat");
                Break.PressToContinue();
                return true;
            }
            return false;
        }

        //Utilities
        public static string GetValidPlateNumber()
        {
            string input = string.Empty;
            bool inputAccepted = false;

            while (!inputAccepted)
            {
                Console.Clear();
                Console.WriteLine($"Var vänlig och skriv in ett registreringsnummer i detta format: ABC123 eller ABC12A (I, Q, V, Å, Ä & Ö är inte acceptabelt)\n");
                input = Console.ReadLine().ToUpper().Trim();

                if (input.Length == 6
                    && !input.Contains('Å')
                    && !input.Contains('Ä')
                    && !input.Contains('Ö')
                    && !input.Contains('I')
                    && !input.Contains('Q')
                    && !input.Contains('V')
                    )
                {
                    if (
                        Char.IsLetter(input[0])
                        && Char.IsLetter(input[1])
                        && Char.IsLetter(input[2])
                        && Char.IsNumber(input[3])
                        && Char.IsNumber(input[4])
                        && (Char.IsNumber(input[5]) || Char.IsLetter(input[5]))
                        )
                    {
                        Console.Clear();
                        inputAccepted = true;
                        return input;
                    }
                }
            }
            Console.Clear();
            return "";
        }

        public static int GetValidNumber(string info, int min, int max)
        {
            bool inputAccepted = false;
            int validNumber = min - 1;

            while (!inputAccepted || validNumber < min || validNumber > max)
            {
                Console.Clear();
                Console.WriteLine(info);
                Console.WriteLine($"\nEnter a number between {min} and {max}");
                inputAccepted = Int32.TryParse(Console.ReadLine().Trim(), out validNumber);
            }

            Console.Clear();
            return validNumber;
        }



        public static string GetValidString(string info)
        {
            string output = string.Empty;

            while (string.IsNullOrEmpty(output))
            {
                Console.WriteLine(info);
                output = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(output))
                {
                    Console.Clear();
                    Console.WriteLine("Input can not be empty.");
                    Break.PleaseWait(1);
                }
                Console.Clear();
            }
            return output;
        }




        public static string GetValidString(string info, string console, params string[] choices)
        {
            bool inputAccepted = false;
            string output = "";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < choices.Length; i++)
            {
                stringBuilder.Append(choices[i] + "\n");
            }

            while (!inputAccepted)
            {
                Console.WriteLine(info + "\nVälj mellan dessa:\n");
                Console.WriteLine(stringBuilder.ToString());
                output = Console.ReadLine().Trim();

                for (int i = 0; i < choices.Length; i++)
                {
                    if (output.ToLower() == choices[i].ToLower())
                    {
                        inputAccepted = true;
                        Console.Clear();
                        return choices[i];
                    }
                }
                Console.Clear();
            }
            return output;
        }


        public static bool GetYesOrNo(string inputInfo)
        {
            bool inputAccepted = false;

            while (!inputAccepted)
            {
                Console.WriteLine($"{inputInfo} Tryck [Y] gör ja och [N] för nej.");
                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case 'y':
                        Console.Clear();
                        return true;
                    case 'n':
                        Console.Clear();
                        return false;
                    case 'Y':
                        Console.Clear();
                        return true;
                    case 'N':
                        Console.Clear();
                        return false;
                    default:
                        Console.Clear();
                        break;
                }
            }
            return false;
        }
    }
}
