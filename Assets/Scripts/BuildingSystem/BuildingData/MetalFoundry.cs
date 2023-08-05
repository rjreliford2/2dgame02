using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MetalFoundry : Gatherer
{
    //the amount of metal income per second increase per building level
    public static float metalPerSecondPerLevel = 10.0f;
    
    //defines the resource type this building effects
    private static string rType = "metal";
    
    //private list tracking the types of resources this building costs for level 1
    public static List<string> costTypes = new List<string>() {"Concrete", "Metal", "Funds", "Pops"};
    
    //private list tracking the actual cost per resource (matched by index to the costs in the previous array)
    private static List<float> costActual = new List<float>() {500.0f, 200.0f, 300.0f, 25.0f };

    //instantiates the metal foundry and adjusts metal income per second appropriately
    public MetalFoundry(int index)
    {
        this.name = "Metal Foundry";
        this.slotNumber = index;
        ReferenceResourceByType.getManagerOfType("metal").changeMod(metalPerSecondPerLevel);
    }

    //provides the gatherer class with the resource type this class effects
    //and the amount by which it effects it
    protected override (float, string) getChangeInfo()
    {
        return (metalPerSecondPerLevel, rType);
    }
    
    //helper method from the cost interface returning the cost details
    public static (List<string>, List<float>) getCost()
    {
        return (costTypes, costActual);
    }
}
