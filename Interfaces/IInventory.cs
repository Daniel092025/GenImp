using System;

namespace GameInventory.Interfaces
{
    public interface IInventory<T>
    {
        int Count { get; }
        void AddItem(T item);
        T GetItem(int index);
        void ShowInventory();
    }
}
