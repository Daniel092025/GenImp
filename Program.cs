using System;
using GameInventory.Classes;
using GameInventory.Models;

namespace GameInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory<Weapon> weaponInventory = new Inventory<Weapon>();
            Inventory<string> potionInventory = new Inventory<string>();

            Console.WriteLine("Velkommen til superduper mini rpg!");
            Console.WriteLine("---------------------------------");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nVelg et alternativ:");
                Console.WriteLine("1. Legg til våpen");
                Console.WriteLine("2. Legg til potion");
                Console.WriteLine("3. Vis inventory");
                Console.WriteLine("4. Avslutt");
                Console.Write("Ditt valg: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWeapon(weaponInventory);
                        break;

                    case "2":
                        AddPotion(potionInventory);
                        break;

                    case "3":
                        ShowAllInventories(weaponInventory, potionInventory);
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Avslutter programmet...");
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg! Prøv igjen.");
                        break;
                }
            }
        }

        static void AddWeapon(Inventory<Weapon> inventory)
        {
            Console.WriteLine("\nVelg våpen:");
            Console.WriteLine("1. Sword (Damage: 25)");
            Console.WriteLine("2. Bow (Damage: 15)");
            Console.Write("👉 Ditt valg: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    inventory.AddItem(new Weapon("Sword", 25));
                    break;
                case "2":
                    inventory.AddItem(new Weapon("Bow", 15));
                    break;
                default:
                    Console.WriteLine("Ugyldig valg, prøv igjen.");
                    break;
            }
        }

        static void AddPotion(Inventory<string> inventory)
        {
            Console.WriteLine("\nVelg potion:");
            Console.WriteLine("1. Health Potion");
            Console.WriteLine("2. Mana Potion");
            Console.Write("👉 Ditt valg: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    inventory.AddItem("Health Potion");
                    break;
                case "2":
                    inventory.AddItem("Mana Potion");
                    break;
                default:
                    Console.WriteLine("Ugyldig valg, prøv igjen.");
                    break;
            }
        }

        static void ShowAllInventories(Inventory<Weapon> weaponInventory, Inventory<string> potionInventory)
        {
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("🗡 Våpen-inventory:");
            weaponInventory.ShowInventory();

            Console.WriteLine("\n🧪 Potion-inventory:");
            potionInventory.ShowInventory();
            Console.WriteLine("-------------------------------");
        }
    }
}
