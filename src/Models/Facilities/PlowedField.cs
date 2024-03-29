using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<ISeedProducing>
    {
        private int _rows = 13;

        private int _plantsPerRow = 5;

        private Guid _id = Guid.NewGuid();

        public string Name { get; set; }

        public int currentPlants
        {
            get
            {
                return _plants.Count * _plantsPerRow;
            }
        }

        public int AvailableSpots
        {
            get
            {
                return _rows - _plants.Count;
            }
        }

        private List<ISeedProducing> _plants = new List<ISeedProducing>();

        public double Capacity
        {
            get
            {
                return _rows;
            }
        }

        double IFacility<ISeedProducing>.Capacity => throw new NotImplementedException();

        public void AddResource(ISeedProducing plant)
        {
            _plants.Add(plant);
        }

        public void ListByType()
        {
            var groupedPlants = _plants.GroupBy(plant => plant.Type);
            foreach (IGrouping<string, ISeedProducing> plant in groupedPlants)
            {
                Console.WriteLine($"{plant.Key} {plant.Count() * _plantsPerRow}");
            }

        }

        public void AddResource(List<ISeedProducing> plants)
        {
            _plants.AddRange(plants);
        }


        public List<IGrouping<string, ISeedProducing>> CreateGroup()
        {
            return _plants.GroupBy(animal => animal.Type).ToList();
        }

        public void SendToHopper(int numToProcess, string type, Farm farm)
        {
            for (int i = 0; i < numToProcess; i++)
            {
                var selectedPlant = _plants.Find(plant => plant.Type == type);
                farm.SeedHarvester.AddToHopper(selectedPlant);
                _plants.Remove(selectedPlant);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append($"Natural field {Name}");
            var plantGroups = CreateGroup();
            if (_plants.Count > 0)
            {
                output.Append(" (");
                for (int i = 0; i < plantGroups.Count; i++)
                {
                    int count = plantGroups[i].Count();
                    string s = (count > 1) ? "s" : "";
                    output.Append($"{count} {plantGroups[i].Key}{s}");
                    if (i + 1 < plantGroups.Count)
                    {
                        output.Append(", ");
                    }
                    else
                    {
                        output.Append(")\n");
                    }
                }

            }
            else output.Append("\n");

            return output.ToString();
        }
    }
}