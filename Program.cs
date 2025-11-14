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


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Velkommen til superduper mini rpg!");
            Console.WriteLine("---------------------------------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(""" 
            ░▀█▀░█▀█░█░█░█▀▀░█▀█░▀█▀░█▀█░█▀▄░█░█░░░█▀▄░█▀█░█▀█░█▀█░█▀█░▀▀█░█▀█
            ░░█░░█░█░▀▄▀░█▀▀░█░█░░█░░█░█░█▀▄░░█░░░░█▀▄░█░█░█░█░█▀█░█░█░▄▀░░█▀█
            ░▀▀▀░▀░▀░░▀░░▀▀▀░▀░▀░░▀░░▀▀▀░▀░▀░░▀░░░░▀▀░░▀▀▀░▀░▀░▀░▀░▀░▀░▀▀▀░▀░▀
            """);
            Console.ResetColor();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nVelg et alternativ:");
                Console.WriteLine("1. Legg til våpen");
                Console.WriteLine("2. Legg til potion");
                Console.WriteLine("3. Vis inventory");
                Console.WriteLine("4. Avslutt");
                Console.WriteLine("5. Lagre inventory til CSV");
                Console.Write("Ditt valg: ");
                string? choice = Console.ReadLine();

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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Avslutter programmet...");
                        Console.ResetColor();
                        break;

                    case "5":
                        Console.WriteLine("Vil du lagre våpen (1) eller potions (2)?");
                        string? saveChoice = Console.ReadLine();
                        if (saveChoice == "1")
                        weaponInventory.SaveToCsv("weapons.csv");
                        else if (saveChoice == "2")
                        potionInventory.SaveToCsv("potions.csv");
                        
                        else
                        Console.WriteLine("Ugyldig valg.");
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
            Console.Write("Ditt valg: ");
            string? choice = Console.ReadLine();

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
            Console.Write("Ditt valg: ");
            string? choice = Console.ReadLine();

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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Våpen-inventory:");
            Console.ResetColor();
            weaponInventory.ShowInventory();

            Console.WriteLine("\nPotion-inventory:");
            Console.ForegroundColor = ConsoleColor.Green;
            potionInventory.ShowInventory();
            Console.ResetColor();
            Console.WriteLine("-------------------------------");
        }
    }
}
