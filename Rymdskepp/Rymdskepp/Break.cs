using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rymdskepp
{
    static class Break
    {
        public static void PleaseWait(int seconds)
        {
            Console.WriteLine("Var vänlig och vänta...");
            Thread.Sleep(seconds * 1000);
            Console.Clear();
        }

        public static void PressToContinue()
        {
            Console.WriteLine("\nTryck på en knapp för att fortsätta..");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
