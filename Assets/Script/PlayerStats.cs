using System.Collections;
using System.Collections.Generic;

public class PlayerStats{

    public static int hungry;
    public static int temperature;
    public static int hp;
    static int maxHungry = 100;
    static int maxTemperature = 100;
    static int maxHP = 5;
    public static void Initialize(){
        hungry = maxHungry;
        temperature = maxTemperature;
        hp = maxHP;
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
}