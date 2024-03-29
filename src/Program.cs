﻿using System;
using System.Linq;
using Trestlebridge.Actions;
using Trestlebridge.Models;

namespace Trestlebridge
{
    class Program
    {
        public static void DisplayBanner()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@"
       +---------------------------------------+
       | T  R  E  S  T  L  E  B  R  I  D  G  E |
       +-----------+---------------+-----------+
                   | F  A  R  M  S |
                   +---------------+");
            Console.WriteLine();
        }

        public static void ShowMessage(string message)
        {
            DisplayBanner();
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public static string GetInput(string message)
        {
            Program.DisplayBanner();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.Write("> ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Farm Trestlebridge = new Farm();


            while (true)
            {
                DisplayBanner();
                Console.WriteLine("1. Create Facility");
                Console.WriteLine("2. Purchase Animals");
                Console.WriteLine("3. Purchase Seeds");
                Console.WriteLine("4. Display Farm Status");
                Console.WriteLine("5. Process Resources");
                Console.WriteLine("6. Exit");
                Console.WriteLine();

                Console.WriteLine("Choose a FARMS option");
                Console.Write("> ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    DisplayBanner();
                    CreateFacility.CollectInput(Trestlebridge);
                }
                else if (option == "2")
                {
                    DisplayBanner();
                    PurchaseStock.CollectInput(Trestlebridge);
                }
                else if (option == "3")
                {
                    DisplayBanner();
                    PurchaseSeed.CollectInput(Trestlebridge);
                }
                else if (option == "4")
                {
                    DisplayBanner();
                    Console.WriteLine(Trestlebridge);
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("Press return key to go back to main menu.");
                    Console.ReadLine();
                }
                else if (option == "5")
                {
                    DisplayBanner();
                    ProcessResources.CollectInput(Trestlebridge);
                }
                else if (option == "6")
                {
                    Console.WriteLine("Today is a great day for farming");
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid option: {option}");
                }
            }
        }
    }
}
