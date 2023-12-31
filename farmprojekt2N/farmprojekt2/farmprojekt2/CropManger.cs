using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmprojekt2
{
    internal class CropManger
    {
        List<Crop> listcrop = new List<Crop>();

        public CropManger()
        {
            listcrop.Add(new Crop(1, "Kokt kyckling", "köt", 2));
            listcrop.Add(new Crop(2, "Foderbetor", "rotgrönsak", 12));
            listcrop.Add(new Crop(3, "Hösilage", "konserverat foder", 2));
            listcrop.Add(new Crop(4, "Havre", "Spannmål", 8));
        }

        public void Menu()
        {

            while (true)
            {
              
                Console.WriteLine("vad vill du göra?");
                Console.WriteLine("1-View Crops");
                Console.WriteLine("2- Add Crop");
                Console.WriteLine("3- Remove Crop");
                Console.WriteLine("4- avsluta");
                string imput = Console.ReadLine();

                switch (imput)
                {
                    case "1":
                        ViewCrops();
                        break;
                    case "2":
                        AddCrop();
                        break;
                    case "3":
                        RemoveCrop();
                        break;
                    case "4":
                        return;

                }

            }

        }
        public void ViewCrops()
        {
            Console.WriteLine("list av crop:");
            foreach (Crop crop in listcrop)
            {
               crop.GetDescription();
            }



        }
        public void AddCrop()
        {
            Console.WriteLine("Lägga till en crop:");

            Console.WriteLine("Ange ID för crop:");
            int newid = int.Parse(Console.ReadLine());

            Console.WriteLine("Skriv namn: ");
            string newName = Console.ReadLine();

            Console.WriteLine("Skriv typ: ");
            string type = Console.ReadLine();

            Console.WriteLine("Skriv quantity: ");
            int addQuantity = Convert.ToInt32(Console.ReadLine());
            bool found = false;
            foreach (Crop crop in listcrop)
            {
                if (crop.GetName() == newName)
                {
                    crop.AddCrop(addQuantity);
                    Console.WriteLine($"{newName} ({type}) har uppdaterats med en kvantitet på {addQuantity}.");
                    found = true; // Vi har hittat en matchning.
                    break; // Avsluta loopen eftersom vi redan har uppdaterat grödan.
                }
            }

            if (!found)
            {
                Crop newcrop = new Crop(newid, newName, type, addQuantity);
                listcrop.Add(newcrop);
                Console.WriteLine($"{newName} ({type}) har lagts till med en kvantitet på {addQuantity}.");
            }
        }

        public void RemoveCrop()
        {
            Console.WriteLine("Tillgänglig crop är: ");
            foreach (Crop crop in listcrop)
            {
                crop.GetDescription();
            }
            Console.WriteLine("Skriv crops id som du vill ta bort");
            int id;
            id = Convert.ToInt32(Console.ReadLine());
            Crop cropToRemove = GetCrops(id);

            if (cropToRemove != null)
            {
                listcrop.Remove(cropToRemove);
                Console.WriteLine("Crop borttagen.");
            }
            else
            {
                Console.WriteLine("Denna crops är inte tillgänglig.");
            }

        }

        public Crop GetCrops(int id)
        {

            foreach (Crop crop in listcrop)
            {
                if (crop.Id == id)
                {
                    return crop;
                }
            }
            return null;
        }


       


    }

}
