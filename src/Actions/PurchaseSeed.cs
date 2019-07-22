using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class PurchaseSeed
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Sesame");
            Console.WriteLine("2. Wildflower");
            Console.WriteLine("3. Sunflower");

            Console.WriteLine();
            Console.WriteLine("What seed are you buying today?");

            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (Int32.Parse(choice))
            {
                case 1:
                    ChoosePlowedField.CollectInput(farm, new Sesame());
                    break;
                case 2:
                    ChooseNaturalField.CollectInput(farm, new Wildflower());
                    break;
                case 3:
                    {
                        Console.Clear();
                        Program.DisplayBanner();
                        Console.WriteLine("1. Natural Field");
                        Console.WriteLine("2. Plowed Field");
                        Console.WriteLine();
                        Console.WriteLine("Choose What type of Field to plant your Sunflowers in:");
                        Console.Write("> ");
                        string fieldType = Console.ReadLine();

                        switch (Int32.Parse(fieldType))
                        {
                            case 1:
                                ChooseNaturalField.CollectInput(farm, new Sunflower());
                                break;
                            case 2:
                                ChoosePlowedField.CollectInput(farm, new Sunflower());
                                break;
                            default:
                                break;

                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}