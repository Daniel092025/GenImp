using System;

namespace GameInventory.Interfaces
{
    public interface IInventory<T>
    {
        void AddItem(T item);
        T GetItem(int index);
        void ShowInventory();
    }
}
