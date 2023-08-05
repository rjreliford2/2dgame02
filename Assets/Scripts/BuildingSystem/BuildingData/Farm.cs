using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Farm : Gatherer
{
    //the amount of food income per second increase per building level
    public static float foodPerSecondPerLevel = 30.0f;
    
    //defines the resource type this building effects
    private static string rType = "food";
    
    //private list tracking the types of resources this building costs for level 1
    public static List<string> costTypes = new List<string>() {"Concrete", "Funds", "Pops"};
    
    //private list tracking the actual cost per resource (matched by index to the costs in the previous array)
    private static List<float> costActual = new List<float>() {200.0f, 300.0f, 30.0f};
    
    //instantiates the farm and adjusts food income per second appropriately
    public Farm(int index)
    {
        this.name = "Farm";
        this.slotNumber = index;
        ReferenceResourceByType.getManagerOfType("food").changeMod(foodPerSecondPerLevel);
    }

    //provides the gatherer class with the resource type this class effects
    //and the amount by which it effects it
    protected override (float, string) getChangeInfo()
    {
        return (foodPerSecondPerLevel, rType);
    }
    
    //helper method from the cost interface returning the cost details
    public static (List<string>, List<float>) getCost()
    {
        return (costTypes, costActual);
    }
}
