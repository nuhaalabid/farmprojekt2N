using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmprojekt2
{
    internal class AnimalManager
    {

        List<Animal> animalsList;

        public AnimalManager()
        {

            animalsList = new List<Animal>();


            animalsList.Add(new Animal(1, "hund", "husdjur", new string[] { "köt" }));
            animalsList.Add(new Animal(2, "ko", "nötkreatur", new string[] { "rotgrönsak" }));
            animalsList.Add(new Animal(3, "får", "Ovis aries", new string[] { "rotgrönsak" }));
            animalsList.Add(new Animal(4, "häst", "Equus ferus caballus", new string[] { "konserverat foder" }));
            animalsList.Add(new Animal(5, "kyckling", "Gallus gallus domesticus", new string[] { "Spannmål" }));
            animalsList.Add(new Animal(6, "Kalkon", "Meleagris gallopavo", new string[] { "Spannmål" }));
            animalsList.Add(new Animal(7, "cat", "husdjur", new string[] { "Köt" }));

        }

        public void Menu(CropManger cropManger)                
        {
            while (true)
            {
                Console.WriteLine("vad vill du göra?");
                Console.WriteLine("1-View Animals");
                Console.WriteLine("2- Add Animal");
                Console.WriteLine("3- Remove Animal");
                Console.WriteLine("4- Feed Animals");
                Console.WriteLine("5- avsluta");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAnimals();
                        break;
                    case "2":
                        AddAnimal();
                        break;
                    case "3":
                        RemoveAnimal();
                        break;
                    case "4":
                        FeedAnimals(cropManger);       
                        break;
                    case "5":

                        return;


                }

            }
        }
        public void ViewAnimals()
        {

            Console.WriteLine("Animals on the farm:");
            foreach (Animal animal in animalsList)
            {
                animal.GetDescription();
            }
        }
        public void AddAnimal()
        {
            Console.WriteLine("Ange ID för djuret:");
            int newid;
            try
            {
                newid = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Felaktigt format för ID. Ange ett heltal.");
                return;
            }

            foreach (Animal animal in animalsList)
            {
                if (animal.Id == newid)
                {
                    Console.WriteLine("Ett djur med ID " + newid + " finns redan.");
                    return;
                }
            }

            Console.WriteLine("Ange namn för djuret:");
            string newName = Console.ReadLine();

            foreach (Animal animal in animalsList)
            {
                if (animal.GetName() == newName)
                {
                    Console.WriteLine("Ett djur med namnet " + newName + " finns redan.");
                    return;
                }
            }

            Console.WriteLine("Ange art för djuret:");
            string species = Console.ReadLine();
            Console.WriteLine("Ange acceptable crop type:");
            string acceptableCropType = Console.ReadLine();
            string[] acceptableTypesArray = acceptableCropType.Split(',');

            animalsList.Add(new Animal(newid, newName, species, acceptableTypesArray));
            Console.WriteLine(newName + "  was successfully added!");


        }
        public void RemoveAnimal()
        {

            Console.WriteLine("Animal som finns i Farm tills nu är :");

            foreach (Animal animal in animalsList)
            {
                animal.GetDescription();
            }

            Console.WriteLine("vilken animal vill du radera");
            int idRemove = int.Parse(Console.ReadLine());

            Animal animalToRemove = GetAnimal(idRemove);

            if (animalToRemove != null)
            {
                animalsList.Remove(animalToRemove);
                Console.WriteLine("Animal with ID " + idRemove + " removed.");
            }
            else
            {
                Console.WriteLine("Inget djur med ID " + idRemove + " hittades.");
            }
        }
        public void FeedAnimals(CropManger cropManger)        
        {
            ViewAnimals();
            Console.WriteLine("Ange ID för djur du vill mata:");
            int animalId = int.Parse(Console.ReadLine());

            cropManger.ViewCrops();
            Console.WriteLine("Ange ID för grödan som du vill använda för att mata djuren:");
            int cropId = int.Parse(Console.ReadLine());

            Crop selectedCrop = cropManger.GetCrops(cropId);
            Animal selectedAnimal = GetAnimal(animalId);

            if (selectedCrop != null && selectedAnimal != null)
            {
                bool cropMatch = false;
                foreach (string cropType in selectedAnimal.AcceptableCropType)
                {
                    if (selectedCrop.Type == cropType)
                    {
                        cropMatch = true;
                        break;
                    }
                }

                if (cropMatch)
                {
                    selectedAnimal.Feed(selectedCrop);
                    Console.WriteLine($"Ny mängd {selectedCrop.Type} efter utfodring: {selectedCrop.Quantity}");
                }
                else
                {
                    Console.WriteLine($"{selectedAnimal.GetName()} kan inte äta {selectedCrop.Type}.");
                }
            }
            else
            {
                Console.WriteLine("Antingen hittades ingen gröda med det angivna ID eller inget djur med det angivna ID.");
            }
        }

        public Animal GetAnimal(int id)
        {
            foreach (Animal animal in animalsList)
            {
                if (animal.Id == id)
                {
                    return animal;
                }
            }
            return null;
        }

        }
       
    }

    

