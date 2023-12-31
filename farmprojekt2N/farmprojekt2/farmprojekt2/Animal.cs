using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmprojekt2
{
    internal class Animal : Entity
    {
        public string Species { get; set; }
        public string[] AcceptableCropType { get; set; }


        public Animal(int id, string name, string species, string[] acceptableCropType) : base(id, name)
        {
            Species = species;
            AcceptableCropType = acceptableCropType;
        }


        public override void GetDescription()
        {
            string description = $"Id: {Id}, \tName: {GetName()},  \t\t Species: {Species},  \t\tAcceptableCropType: {string.Join(", ", AcceptableCropType)}\n";
            Console.WriteLine(description);

        }


        public Animal Feed(Crop crop)

        {
            if (crop.TakeCrop(1))
            {
                Console.WriteLine($"{Name} ({Species}) has been fed with {crop.Type}.");
            }

            else
            {
                Console.WriteLine($"No more {crop.Type} available to feed {GetName()} ({Species}).");
            }
            return this;


        }
    }
}
