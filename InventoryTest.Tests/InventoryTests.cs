namespace InventoryTest.Tests;

using System.Runtime.CompilerServices;
using GameInventory.Classes;
using GameInventory.Models;
using GameInventory.Interfaces;
using Microsoft.VisualBasic;

public class InventoryTests
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
        Assert.Equal(1, inventory.Count);
    
    }

    [Fact]
    public void AddWeapon_WeaponIsInInventory()
    {
        //Arrange...
        var inventory = new Inventory<Weapon>();
        var sword = new Weapon("Iron Sword", 45);

        // Act............
        inventory.AddItem(sword);

        // Assert............
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

        Assert.Equal(0, inventory.Count);
    }

    [Fact]
    public void Clear_RemovesAllItems()
    {
        var inv = new Inventory<Weapon>();
        inv.AddItem(new Weapon("Iron Sword", 45));
        inv.AddItem(new Weapon("Bow", 20));

        inv.Clear();

        Assert.Equal(0, inv.Count);
    }

    [Fact]
    public void Inventory_ImplementsIInventory()
    {
        IInventory<Weapon> inv = new Inventory<Weapon>();

        inv.AddItem(new Weapon("Bow", 15));

        Assert.Equal(1, inv.Count);
    }

    [Fact]
    public void AddItem_AllowsDuplicates()
    {
        var inv = new Inventory<string>();

        inv.AddItem("Potion");
        inv.AddItem("Potion");

        Assert.Equal(2, inv.Count);
    }

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

    [Fact]
    public void GetItem_InvalidIndex_ThrowsException()
    {
        var inv = new Inventory<Weapon>();

        inv.AddItem(new Weapon("Sword", 10));

        Assert.Throws<ArgumentOutOfRangeException>(() => inv.GetItem(5));
    }

    [Fact]
    public void RemoveItem_ItemNotInInventory_ThrowsInvalidOperationException()
    {
        var inv = new Inventory<Weapon>();

        var sword = new Weapon("Sword", 10);
        var ghost = new Weapon("Ghost Sword", 99);

        inv.AddItem(sword);

        Assert.Throws<InvalidOperationException>(() => inv.RemoveWeapon(ghost));
    }


}