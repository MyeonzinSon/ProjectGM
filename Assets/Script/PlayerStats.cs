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

    public static int hungry;
    public static int temperature;
    public static int hp;
    static int maxHungry = 100;
    static int maxTemperature = 100;
    static int maxHP = 5;
    public static List<Inventory> inventories;
    public static void Initialize(){
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
    public static void AddInventory(Item input){
        foreach (var item in inventories){
            if (item.type == input.type){
                item.num++;
                return;
            }
        }
        var newItem = new Inventory(input, 1);
        inventories.Add(newItem);
    }
}