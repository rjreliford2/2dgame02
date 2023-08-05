using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : Building
{
    //defines the amount of resources a warehouse can hold per level
    public static float resourceCapPerLevel = 500.0f;
    
    //private list tracking the types of resources this building costs for level 1
    public static List<string> costTypes = new List<string>() {"Concrete", "Funds"};
    
    //private list tracking the actual cost per resource (matched by index to the costs in the previous array)
    private static List<float> costActual = new List<float>() {800.0f, 300.0f };
    
    //Instantiates the warehouse and changes the resource cap
    public Warehouse(int index)
    {
        this.slotNumber = index;
        this.name = "Warehouse";
        ResourceManager.changeResourceCap(resourceCapPerLevel);
    }

    //increases the structure's level, providing an appropriate capacity increase
    public override void levelUp()
    {
        this.level++;
        ResourceManager.changeResourceCap(resourceCapPerLevel);
    }

    //removes this building's bonuses to capacity
    public override void removeSelf()
    {
        ResourceManager.changeResourceCap(-resourceCapPerLevel*this.level);
    }
    
    //helper method from the cost interface returning the cost details
    public static (List<string>, List<float>) getCost()
    {
        return (costTypes, costActual);
    }
}
