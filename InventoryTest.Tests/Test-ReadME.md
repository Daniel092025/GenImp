# UnitTest
---
### Har laget en del tester på GenImp løsningen min. Der jeg prøver å teste om div funksjoner funker og ikke feiler. 

*Hvordan kjøres testene?*
    - Enkelt så kjører man bare en dotnet test. Da vil den kjøre alle testen på metodene og sjekke om de feiler. Hva som gjør at de feiler og passer står litt lengre ned i Pseudo koden.
    - Og det skal være lett å kjøre hver enkelt test med "▶️" knappene ved koden i "InventoryTests.cs"

*Hvorfor laget jeg disse testene?*
    - Hovedsaklig begynte jeg med enkle tester på å sjekke inventory count å legge til ekstra ting i inventoryen. 
    men måtte utvide å legge til flere tester på dette, da jeg egentlig bare testet en liten del av hovedprogrammet. Så utvidet og utvidet testing...
    - Jeg føler jeg har fått testet ganske mye, spesielt siden GenImp solution min var ganske rett frem. Ikke så veldig komplisert. Jeg kunne kanskje ha prøvd å lage en test mot null value. Men ble litt mange tester.

*Kunne en annen utvikler forstått hvordan de bruker din class / implementasjon via testene dine?*
    - Jeg håper da det? Syns jeg har fått den oversiktlig. Både testene og selve hoved løsningen er rett frem.
    - Men tar jo gjerne tilbakemelding på uoversiktlige ting.





---

## Pseudo

### Test AddCount og Add og GetItem
```csharp
public void AddWeapon_IncreasesInvetoryCount()
    {
        // Arrange
        var inventory = new Inventory<Weapon>();
        var sword = new Weapon("Iron Sword", 45);
        
        // Act
        inventory.AddItem(sword);
        
        // Assert
        Assert.Equal(1, inventory.weaponInventory);
    }
```
+
```csharp
public void AddWeapon_WeaponIsInInventory()
```

### Test RemoveAllItems, tester med å legge til flere items. For å så å fjerne disse.

```csharp
public void Clear_RemovesAllItems()
    {
        var inv = new Inventory<Weapon>();
        inv.AddItem(new Weapon("Iron Sword", 45));
        inv.AddItem(new Weapon("Bow", 20));

        inv.Clear();

        Assert.Equal(0, inv.weaponInventory);
    }
```

### At inventory funker igjennom interfacen
```csharp
public void Inventory_ImplementsIInventory()
{
    IInventory<Weapon> inv = new Inventory<Weapon>();

    inv.AddItem(new Weapon("Bow", 15));

    Assert.Equal(1, inv.Count);
}
```

### Duplikater er tillatt eller ei
```csharp
    public void AddItem_AllowsDuplicates()
    {
        var inv = new Inventory<string>();

        inv.AddItem("Potion");
        inv.AddItem("Potion");

        Assert.Equal(2, inv.Count);
    }
```

### Theory - En fler tester for gjenbrukbare tester. Her tester jeg 3 items på rappen!
```csharp
 [Theory]

    [InlineData("Sword", 25)]
    [InlineData("Bow", 15)]
    [InlineData("Iron Shield", 5)]

    public void AddWeapon_AddsExpectedWeapon(string name, int damage)   
    {
        var inventory = new Inventory<Weapon>();
        var weapon = new Weapon(name, damage);

        inventory.AddItem(weapon);

        Assert.Equal(1, inventory.Count);
        Assert.Equal(name, inventory.GetItem(0).Name);
        Assert.Equal(damage, inventory.GetItem(0).Damage);
    }
```

### GetItem med ugyldig indeks
*Tester at metoden ikke kræsjer stille og feilen håndteres riktig*
```csharp
  public void GetItem_InvalidIndex_ThrowsException()
    {
        var inv = new Inventory<Weapon>();

        inv.AddItem(new Weapon("Sword", 10));

        Assert.Throws<ArgumentOutOfRangeException>(() => inv.GetItem(5));
    }
```

### RemoveItem på et objekt som ikke finnes
*Tester ugyldig fjerning*
```csharp
   public void RemoveItem_ItemNotInInventory_ThrowsInvalidOperationException()
    {
        var inv = new Inventory<Weapon>();

        var sword = new Weapon("Sword", 10);
        var ghost = new Weapon("Ghost Sword", 99);

        inv.AddItem(sword);

        Assert.Throws<InvalidOperationException>(() => inv.RemoveWeapon(ghost));
    }
```


