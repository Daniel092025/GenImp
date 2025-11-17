# Generetic Implementation

## Interface
> Interface. Eller kontrakten.

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

> En container<T>, for metode til å hente elementer. Her i en mer "Gaming" format. Ergo Inventory

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

> Henter inventory med å følge interfacen.
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

> Prøvd å sveise samme alt i program. Der GUI består av switch case der du velger våpen og potion å legger det i en inventory. Rundet opp med litt ACII og farger. Prøvde også med å legge en metode for en mulighet å spare til en CSV fil. Her måtte AI litt til å hjelpe for å sy det inn.

```Csharp

Console.WriteLine("Vil du lagre våpen (1) eller potions (2)?");
                        string? saveChoice = Console.ReadLine();
                        if (saveChoice == "1")
                        weaponInventory.SaveToCsv("weapons.csv");
                        else if (saveChoice == "2")
                        potionInventory.SaveToCsv("potions.csv");

```

# ReadME

Ett lite program med Generisk Implementasjon, som er i form av ett inventory med litt våpen og potions.
Rundet opp med en simpel GUI og mulighet til å lagre til lokal CSV. 
Følger reglene til interface "IInventory" med hva som er i inventoryen og hvordan det printes IStorable.
Har også prøvd å bli bedre med å pushe til Git, så man får en bedre "historie" på fremgang.

Forventning til at klassen bli brukt i en større sammenheng?
Siden den har en "kontrakt" eller bestemte regler, så kan man evt implementere den i utvidelse og holde styr på de bestemte reglene ved utvidelse av koden. For eksempel hvis jeg skulle ha lagd dette spillet større, og utvide inventory til:
- Holde maks 25 items
- Stacke items (Health potion x5)
- Droppe items
- Tar det helt av? kanskje lagre intentory på en server?