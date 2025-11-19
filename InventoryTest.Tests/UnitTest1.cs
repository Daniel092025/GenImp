namespace InventoryTest.Tests;

using System.Runtime.CompilerServices;
using GameInventory.Classes;
using GameInventory.Models;

public class UnitTest1
{
    [Fact]
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

    [Fact]
    public void AddWeapon_WeaponIsInInventory()
    {
        //Arrange...
        var inventory = new Inventory<Weapon>();
        var sword = new Weapon("Iron Sword", 45);

        // Act
        inventory.AddItem(sword);

        // Assert
        var retrievedWeapon = inventory.GetItem(0);
        Assert.Equal(sword, retrievedWeapon);
    }

    [Fact]
    public void RemoveWeapon_ReduceAmount()
    {
        var inventory = new Inventory<Weapon>();
        var sword = new Weapon("Iron Sword", 45);

        inventory.AddItem(sword);
        inventory.RemoveWeapon(sword);

        Assert.Equal(0, inventory.weaponInventory);
    }

    [Fact]
    public void Clear_RemovesAllItems()
    {
        var inv = new Inventory<Weapon>();
        inv.AddItem(new Weapon("Iron Sword", 45));
        inv.AddItem(new Weapon("Bow", 20));

        inv.Clear();

        Assert.Equal(0, inv.weaponInventory);
    }

}