using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory{
    public ItemType type;
    public Sprite sprite;
    public int num;
    public Inventory(Item item, int num){
        this.type = item.type;
        this.sprite = item.GetSprite();
        this.num = num;
    }
}
public class PlayerStats{
    public static bool canMove;
    public static bool canRideHelicopter;
    public static bool isInHouse;
    public static bool isOnGround;
    public static bool isWalking;
    public static int hungry;
    public static int temperature;
    public static int hp;
    static int maxHungry = 100;
    static int maxTemperature = 100;
    static int maxHP = 5;
    public static List<Inventory> inventories;
    public static void Initialize(){
        canMove = true;
        canRideHelicopter = false;
        hungry = maxHungry;
        temperature = maxTemperature;
        hp = maxHP;
        inventories = new List<Inventory>();
    }

    public static float GetHungryRatio(){
        return (float)hungry / maxHungry;
    }
    public static float GetTemperatureRatio(){
        return (float)temperature / maxTemperature;
    }
    public static void AddHungry(int value){
        hungry += value;
        if (hungry >= maxHungry){
            hungry = maxHungry;
        }
    }
    public static void AddTemperature(int value){
        temperature += value;
        {
            if (temperature >= maxTemperature){
                temperature = maxTemperature;
            }
        }
    }
    public static void AddInventory(Item item){
        bool notFound = true;
        foreach (var inventory in inventories){
            if (inventory.type == item.type){
                inventory.num++;
                notFound = false;
            }
        }
        if (notFound){
            var newItem = new Inventory(item, 1);
            inventories.Add(newItem);
        }

        CheckComposingItem();
        InventoryUI.UpdateUI();
    }
    public static bool CheckAndUseItem(ItemType type){
        foreach (var inventory in inventories){
            if (inventory.type == type){
                inventory.num--;
                InventoryUI.UpdateUI();
                return true;
            }
        }
        return false;
    }
    static void CheckComposingItem(){
        Inventory egg = null, wheat = null;
        foreach (var inventory in inventories){
            if (inventory.type == ItemType.Egg){
                egg = inventory;
            }
            if (inventory.type == ItemType.Wheat){
                wheat = inventory;
            }
        }
        if ((egg != null && wheat != null) && (egg.num >= 2 && wheat.num >= 2)){
            egg.num -= 2;
            wheat.num -= 2;
            AddHungry(50);
            AddTemperature(50);
            SFX.PlayEat();
        }
    }
}