# UnitTest

---

### Har laget en del tester på GenImp løsningen min. Der jeg prøver å teste om div funksjoner funker og ikke feiler. 

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


