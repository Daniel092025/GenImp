using System;
using System.Collections.Generic;
using GameInventory.Interfaces;

namespace GameInventory.Classes
{
    public class Inventory<T> : IInventory<T>
    {
        private List<T> items = new List<T>();

        public int Count => items.Count;
        public int weaponInventory => items.Count;

        public void AddItem(T item)
        {
            items.Add(item);
            Console.WriteLine($"{item} ble lagt til i inventory!");
        }

        public void RemoveWeapon(T item)
        {
            items.Remove(item);
            Console.WriteLine($"{item} ble fjernet fra inventory!");
        }

        public void Clear()
        {
            items.Clear();
            Console.WriteLine("Inventory ble tømt!");
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= items.Count)
            {
                throw new IndexOutOfRangeException("Ugyldig indeks. Ingen slik gjenstand.");
            }
            return items[index];
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n Inventory:");
            if (items.Count == 0)
            {
                Console.WriteLine("Inventoryen er tom!");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
        }

        public void SaveToCsv(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in items)
                {
                    writer.WriteLine(item?.ToString());
                }
            }

            Console.WriteLine($"Inventory lagret til fil: {filePath}");
        }
    }
}
