using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmprojekt2
{
   internal class Crop : Entity
    {
        public string Type { get; set; }
        public int Quantity { get; set; }

        public Crop(int id, string name, string type, int quantity) : base(id, name)
        {
            Type = type;
            Quantity = quantity;
        }
        public override void GetDescription()
        {
            string description = $"Id: {Id}, \tName: {GetName()},  \t\t Type: {Type},  \t\tQuantity: {Quantity}\n";
            Console.WriteLine(description );
        }
        public void AddCrop(int quantity)
        {
            Quantity += quantity;
            Console.WriteLine($"{Name} ({Type}) now has {Quantity} in stock.");
            return;
        }


        public bool TakeCrop(int quantity)
        {
            if (Quantity > 0)
            {
                Quantity--;
                return true;
            }
            else
            { 
                Console.WriteLine("kvantiten är otillräcklig");
                return false;
            }
            
           

        }
    } 
}
