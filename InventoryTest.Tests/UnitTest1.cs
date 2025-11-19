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
        Assert.Contains(sword, inventory.GetItem);
    }
}