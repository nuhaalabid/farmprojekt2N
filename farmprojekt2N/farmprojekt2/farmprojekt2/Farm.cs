using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmprojekt2
{
    internal class Farm
    {
        AnimalManager animalManager;
        CropManger cropManager;

        public Farm()
        {
            cropManager = new CropManger();
            animalManager = new AnimalManager();        
        }

        public void MainMenu()
        {
            bool continuing = true;
            while (continuing)
            {
                Console.Clear();
                Console.WriteLine("vad vill kontrollera?");
                Console.WriteLine("1. Animal.");
                Console.WriteLine("2. Crop");
                Console.WriteLine("3. avsluta");
                string imput = Console.ReadLine();

                switch (imput)
                {
                    case "1":
                        animalManager.Menu(cropManager);        
                        break;
                    case "2":
                        cropManager.Menu();
                        break;
                    case "3":
                        continuing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

            }
        }
    }
}

