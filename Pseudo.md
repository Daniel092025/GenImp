# Generetic Implementation

## Interface
> Tekstytekst tekst

```csharp
namespace GameInventory.Interfaces
{
    public interface IInventory<T>
    {
        void AddItem(T item);
        T GetItem(int index);
        void ShowInventory();
    }
}
```

> Tekstytekst tekst

```csharp
namespace GameInventory.Interfaces
{
    public interface IStorable
    {
        void SaveToCsv(string filePath);
    }
}
```

## Class

> Tekstytekstytekst
> Container <T>

```csharp
namespace GameInventory.Classes
{
    public class Inventory<T> : IInventory<T>
    {
        private List<T> items = new List<T>();
        }    
}
```

## Program

> Tekst

```Csharp

Kode <mer kode>;

```

ReadME

